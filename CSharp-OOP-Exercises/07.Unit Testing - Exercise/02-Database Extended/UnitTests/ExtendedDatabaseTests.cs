using ExtendedDatabase;
using ExtendedDatabase.Tests;
using NUnit.Framework;
using System;
using TestFixtureAttribute = ExtendedDatabase.Tests.TestFixtureAttribute;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabase
    {
        private Database extendedDB;

        [SetUp]
        public void Setup()
        {
            extendedDB = new Database();
        }

        [Test] // ctor
        public void Constr_Gets_Additional_People_To_DataBase()
        {
            Person[] persons = new Person[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i + 100, $"Nasko{i}");
            }
            extendedDB = new Database(persons);
            Assert.That(extendedDB.Count, Is.EqualTo(persons.Length));
        }
        [Test] // ctor
        public void We_Can_Add_Up_To_16_Elements_In_DB()
        {
            Person[] persons = new Person[16];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i+1 + 100, $"Nasko{i+1}");
            }
            extendedDB = new Database(persons);
            Assert.That(16, Is.EqualTo(extendedDB.Count));
        }

        [Test] // ctor
        public void Throw_Exception_When_DB_Capacity_Exceeded()
        {
            Person[] persons = new Person[20];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i + 1 + 100, $"Nasko{i + 1}");
            }            
            Assert.That(()=> extendedDB = new Database(persons),Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }
        [Test] // Add
        public void Throw_Exception_When_Add_More_Than_16_People_To_DB()
        {
            Person[] persons = new Person[16];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i + 101, $"Nasko{i + 1}");

                
                extendedDB.Add(persons[i]);

            }
            Assert.That(() => extendedDB.Add(new Person(111,"nasko")), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));

        }
        [Test] // Add same Username
        public void Throw_Exception_When_Add_Same_User_IN_DB()
        {
            Person[] persons = new Person[15];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i + 101, $"Nasko{i + 1}");
                
                extendedDB.Add(persons[i]);
            }
              // trying to add 16th person with the same name like 15th person!
            Assert.That(() => extendedDB.Add(new Person(1234, "Nasko15")),Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }
        [Test] // Add same Id
        public void Throw_Exception_When_Add_User_With_Same_ID_In_DB()
        {            
            extendedDB.Add(new Person(2000, "Nasko"));
            // trying to add 16th person with the same Name!
            Assert.Throws<InvalidOperationException>(() => extendedDB.Add(new Person(2000, "Nasko_Original")), "There is already user with this Id!");
            
        }
        // Remove --------------------------------------------------------

        [Test] 
        public void Throw_Exception_When_DB_Is_Empty()
        {
            //First Add someone.
            extendedDB.Add(new Person(123456789,"Nikol"));
            //Then remove someone ( db is empty now).
            extendedDB.Remove();
            //Then check if on next removal of element exception would be thrown.
            Assert.Throws<InvalidOperationException>(() => extendedDB.Remove());

        }

        [Test] 
        public void When_Successfully_Remove_Someone_From_DB()
        {
            Person person = new Person(2000, "Nasko");
            extendedDB.Add(person);
            extendedDB.Remove();
            Assert.That(extendedDB.Count == 0);

        }
        //Find by ID --------------------------------------------------------
        [Test]
        public void Throw_Exception_When_This_ID_Not_Exists()
        {
            Person person = new Person(2000, "Nasko");
            Person person1 = new Person(2001, "Pesho");
            Person person2 = new Person(2002, "Gosho");
            extendedDB.Add(person);
            extendedDB.Add(person1);
            extendedDB.Add(person2);
            Assert.Throws<InvalidOperationException>(()=> extendedDB.FindById(8888),"No user is present by this ID!");

        }

        //Pay attention here! Possible mistake
        [Test]
        public void When_This_ID_Exists_Return_That_Person()
        {
            Person person = new Person(123,"Nasko");
            extendedDB.Add(person);

            Person testThatId = extendedDB.FindById(person.Id);
            Assert.That(testThatId, Is.EqualTo(person));
        }
        [Test]
        public void When_ID_Is_Negative()
        { 
            
            Person person1 = new Person(2002, "Pesho");
            Person person2 = new Person(2003, "Gosho");
            
            extendedDB.Add(person1);
            extendedDB.Add(person2);

            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDB.FindById(-5), "Id should be a positive number!");

        }
        //Find By Username ------------------------------------------
        
        [Test]
        public void Trying_To_Find_By_Invalid_Username()
        {
            extendedDB.Add(new Person(1500, "Misho"));
            extendedDB.Add(new Person(1800, "Kiko"));
            Assert.Throws<InvalidOperationException>(() => extendedDB.FindByUsername("Metodi Enkov"), "No user is present by this username!");

        }
        //[TestCase()] -> we pass argument inside + argument inside method ,after we have the bonus option to catch exception for several cases!
        //For example when:  // userTest == "" , // and userTest == null
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_Trying_To_Find_By_Username_But_Is_Null_Or_Empty(string userTest)
        {                       

            Assert.Throws<ArgumentNullException>(() => extendedDB.FindByUsername(userTest), "Username parameter is null!");
            

        }

        //Pay attention here! Possible mistake
        [Test]
        public void When_This_Username_Exists_Return_That_Person()
        {
            Person person = new Person(1111,"Nasko");
            extendedDB.Add(person);

            Person namePersonFromDataBase = extendedDB.FindByUsername(person.UserName);
            Assert.That(person, Is.EqualTo(namePersonFromDataBase));
            
        }
    }
}