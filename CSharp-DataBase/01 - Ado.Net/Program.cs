using System;
using System.Data.SqlClient;
using System.Text;

namespace Exercises_ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = @"Server=XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            // PROBLEM 1 - CREATE DB,TABLES AND INSERT DATA INTO TABLES
            // ==============================================================
            // 01. create db 
            //int rowsAffected = GetDbCreated(connection);   //<-- Method creates DataBase (Uncommend this row if you wish to use)

            //-----------------------------------------------------------------------------------------------------

            //02.Create Tables

            //TableCreator(connection, rowsAffected);        //<-- Method creates tables (Uncommend this row if you wish to use)

            //-----------------------------------------------------------------------------------------------------
            //03 Insert into tables values

            //InsertDataInTables(connection);                //<-- Method inserts data into table (Uncommend this row if you wish to use)


            //===============================================================================================================================
            // PROBLEM 2 -  Villain Names


            string villainInfo = GetNamesAndMinionsCount(connection);
            Console.WriteLine(villainInfo);


            //===============================================================================================================================
            // PROBLEM 3 Minion Names

            int villainIdInput = int.Parse(Console.ReadLine());
            string resultMinionsPrinter = MinionsData(connection, villainIdInput);
            Console.WriteLine(resultMinionsPrinter);

            // PROBLEM 6 DeleteVillain
            var deletedVillian = DeleteVillain(connection, 10);
            Console.WriteLine(deletedVillian);

            // PROBLEM 9 - Increase Age Stored Procedure 

            var ss = IncreaseMinionAge(connection, 5);
            Console.WriteLine(ss);



        }

        private static string MinionsData(SqlConnection sqlConnection,int villainId)
        {
            StringBuilder sb = new StringBuilder();
            
            string queryVillainIdCheck = @"SELECT
	                                            v.Id	
                                             FROM Villains AS v
                                             WHERE v.Id = @Id";
            SqlCommand cmdVillainIdCheck = new SqlCommand(queryVillainIdCheck, sqlConnection);
            cmdVillainIdCheck.Parameters.AddWithValue("@Id", villainId);
            var resultVillainId = cmdVillainIdCheck.ExecuteScalar();  //object - this case can be returned as int or null 
            bool canParseToInt = int.TryParse(resultVillainId?.ToString(), out int answ);
            if (!canParseToInt)
            {
                return sb.AppendLine($"No villain with ID {villainId} exists in the database.").ToString();
            }

            string queryMinionsAvailability = @"SELECT
	                                                COUNT(m.Id) AS [Minion Number]
                                                 FROM 
                                                 MinionsVillains AS mv
                                                LEFT JOIN Minions AS m
                                                 ON mv.MinionId = m.Id
                                                LEFT JOIN Villains AS v 
                                                 ON mv.VillainId = v.Id
                                                 WHERE mv.VillainId = @Id";
            SqlCommand cmdMinionsAvailable = new SqlCommand(queryMinionsAvailability, sqlConnection);
            cmdMinionsAvailable.Parameters.AddWithValue("@Id", villainId);


            string queryInvalidVid = @" SELECT
	                                        Name
                                         FROM Villains
                                         WHERE Id = @Id";
            SqlCommand cmdGetsInvalidViD = new SqlCommand(queryInvalidVid, sqlConnection);
            cmdGetsInvalidViD.Parameters.AddWithValue("@Id", villainId);
            var resultVillainName = (string)cmdGetsInvalidViD.ExecuteScalar();

            var resulstMinionsAvailable = (int)cmdMinionsAvailable.ExecuteScalar();
            if (resulstMinionsAvailable == 0)
            {
                sb.AppendLine($"Villain: {resultVillainName}.");
                sb.AppendLine("(no minions)");
            }
            string queryGetMinions = @"SELECT	
	                                        m.Name,
	                                        m.Age	
                                         FROM Villains AS v
                                         JOIN MinionsVillains AS mv
                                         ON v.Id = mv.VillainId
                                         JOIN Minions AS m
                                         ON mv.MinionId = m.Id
                                         WHERE v.Id = @IdParam
                                         ORDER BY m.Name";
            SqlCommand cmdGetMinions = new SqlCommand(queryGetMinions, sqlConnection);
            cmdGetMinions.Parameters.AddWithValue("@IdParam", villainId);

            SqlDataReader rdr = cmdGetMinions.ExecuteReader();
            int i = 0;
            sb.AppendLine($"Villain: {resultVillainName}");
            while (rdr.Read())
            {
                i++;                
                sb.AppendLine($"{i}. {rdr[0]} {rdr[1]}");
            }
            rdr.Close();
            return sb.ToString().TrimEnd();
        }


        private static string GetNamesAndMinionsCount(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            string querySelectNameCount = @"SELECT
	                                        v.Name,
	                                        COUNT(mv.VillainId) AS [MinionsCount]
                                        FROM Villains AS v
                                        JOIN MinionsVillains AS mv
                                        ON v.Id = mv.VillainId
                                        GROUP BY v.Name,mv.VillainId
                                        HAVING COUNT(mv.VillainId) > 3
                                        ORDER BY [MinionsCount] DESC";

            SqlCommand sqlCommand = new SqlCommand(querySelectNameCount, connection);

          using  SqlDataReader reader = sqlCommand.ExecuteReader();

            if (!reader.HasRows)
            {
                return "No information";
            }

            while (reader.Read())
            {
                sb.AppendLine($"{reader[0]} - {reader[1]}");
            }
            return sb.ToString().TrimEnd();
        }
        //-----------
        //Problem 06
        private static string DeleteVillain(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder output = new StringBuilder();

            string villainNameQuery = @"SELECT [Name]
                                          FROM [Villains]
                                         WHERE [Id] = @VillainId";
            SqlCommand villainNameCmd = new SqlCommand(villainNameQuery, sqlConnection);
            villainNameCmd.Parameters.AddWithValue("@VillainId", villainId);

            string villainName = (string)villainNameCmd.ExecuteScalar();
            if (villainName == null)
            {
                return $"No such villain was found.";
            }

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string releaseMinionsQuery = @"DELETE FROM [MinionsVillains]
                                                 WHERE [VillainId] = @VillainId";
                SqlCommand releaseMinionsCmd =
                    new SqlCommand(releaseMinionsQuery, sqlConnection, sqlTransaction);
                releaseMinionsCmd.Parameters.AddWithValue("@VillainId", villainId);

                int minionsReleased = releaseMinionsCmd.ExecuteNonQuery();

                string deleteVillainQuery = @"DELETE FROM [Villains]
                                                WHERE [Id] = @VillainId";
                SqlCommand deleteVillainCmd =
                    new SqlCommand(deleteVillainQuery, sqlConnection, sqlTransaction);
                deleteVillainCmd.Parameters.AddWithValue("@VillainId", villainId);

                int villainsDeleted = deleteVillainCmd.ExecuteNonQuery();

                if (villainsDeleted != 1)
                {
                    sqlTransaction.Rollback();
                }

                output
                    .AppendLine($"{villainName} was deleted.")
                    .AppendLine($"{minionsReleased} minions were released.");
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.ToString();
            }

            sqlTransaction.Commit();

            return output.ToString().TrimEnd();
        }

        //Problem 09 IncreaseMinionAge
        private static string IncreaseMinionAge(SqlConnection sqlConnection, int minionId)
        {
            StringBuilder output = new StringBuilder();

            string increaseAgeQuery = @"EXEC [dbo].[usp_GetOlder] @MinionId";
            SqlCommand increaseAgeCmd = new SqlCommand(increaseAgeQuery, sqlConnection);
            increaseAgeCmd.Parameters.AddWithValue("@MinionId", minionId);

            increaseAgeCmd.ExecuteNonQuery();

            string minionInfoQuery = @"SELECT [Name],
                                              [Age]
                                         FROM [Minions]
                                        WHERE [Id] = @MinionId";
            SqlCommand minionInfoCmd = new SqlCommand(minionInfoQuery, sqlConnection);
            minionInfoCmd.Parameters.AddWithValue("@MinionId", minionId);

            using SqlDataReader infoReader = minionInfoCmd.ExecuteReader();
            while (infoReader.Read())
            {
                output.AppendLine($"{infoReader["Name"]} – {infoReader["Age"]} years old");
            }

            return output.ToString().TrimEnd();
        }
        //-----------

        private static void InsertDataInTables(SqlConnection connection)
        {
            SqlCommand cmdInsertValues1 = new SqlCommand(@"INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')", connection);

            SqlCommand cmdInsertValues2 = new SqlCommand(@"INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)", connection);

            SqlCommand cmdInsertValues3 = new SqlCommand(@"INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)", connection);

            SqlCommand cmdInsertValues4 = new SqlCommand(@"INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')", connection);

            SqlCommand cmdInsertValues5 = new SqlCommand(@"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)", connection);

            SqlCommand cmdInsertValues6 = new SqlCommand(@"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)", connection);

            Console.WriteLine(cmdInsertValues1.ExecuteNonQuery());
            Console.WriteLine(cmdInsertValues2.ExecuteNonQuery());
            Console.WriteLine(cmdInsertValues3.ExecuteNonQuery());
            Console.WriteLine(cmdInsertValues4.ExecuteNonQuery());
            Console.WriteLine(cmdInsertValues5.ExecuteNonQuery());
            Console.WriteLine(cmdInsertValues6.ExecuteNonQuery());
        }

        private static void TableCreator(SqlConnection connection, int rowsAffected)
        {
            SqlCommand cmdQuery = new SqlCommand(@"CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))", connection);

            SqlCommand cmdQuery1 = new SqlCommand(@"CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))", connection);

            SqlCommand cmdQuery2 = new SqlCommand(@"CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))", connection);

            SqlCommand cmdQuery3 = new SqlCommand(@"CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))", connection);

            SqlCommand cmdQuery4 = new SqlCommand(@"CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))", connection);

            SqlCommand cmdQuery5 = new SqlCommand(@"CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))", connection);

            int rowsAffected1 = cmdQuery5.ExecuteNonQuery();
            Console.WriteLine(rowsAffected1);
        }

        private static int GetDbCreated(SqlConnection connection)
        {
            SqlCommand cmdQuery = new SqlCommand(@"CREATE DATABASE MinionsDB", connection);
            int rowsAffected = cmdQuery.ExecuteNonQuery();
            Console.WriteLine(rowsAffected);
            return rowsAffected;
        }
    }
}

