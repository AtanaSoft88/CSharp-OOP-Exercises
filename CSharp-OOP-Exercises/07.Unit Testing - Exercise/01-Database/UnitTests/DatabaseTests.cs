namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database dataBase;

        [SetUp]
        public void Setup()
        {
            dataBase = new Database();
        }

        [Test]  //Constructor test
        public void Ctor_Throws_Exception_When_Capacity_Is_Exceeded()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //dataBase = new Database(Enumerable.Range(1,17).ToArray());
                dataBase = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            });


        }

        [Test]  //Constructor test
        public void Ctor_Can_Add_Valid_Items_To_DB()
        {
            int[] elements = { 1, 2, 3, 4 };
            dataBase = new Database(elements);

            //foreach (var item in elements)
            //{
            //    dataBase.Add(item);
            //}
            Assert.That(dataBase.Count == elements.Length);

        }

        [Test]  //Constructor test
        public void Ensure_Add_Method_Increments_Total_Capacity_DB()
        {
            int num = 5;
            for (int i = 0; i < 5; i++)
            {
                dataBase.Add(i);
            }

            Assert.That(dataBase.Count, Is.EqualTo(num));

        }
        [Test]
        public void When_You_Try_To_Remove_Element_FM_Empty_DB()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                dataBase.Remove();
            }, "The collection is empty!");



        }

        [Test]
        public void Remove_Decreses_DB_Capacity()
        {

            int num = 3;
            for (int i = 0; i < num; i++)
            {
                dataBase.Add(150);
            }
            dataBase.Remove();
            var expectedResultCount = 2;
            Assert.That(dataBase.Count, Is.EqualTo(expectedResultCount));



        }

        [Test]
        public void If_We_Can_Remove_Exactly_Last_Element()
        {
            Database db = new Database();
            int n = 4;
            for (int i = 0; i < n; i++)
            {
                db.Add(i);
                
            }
            int lastElem = n;
            db.Remove();
            int[] elements = db.Fetch();
            Assert.IsFalse(elements.Contains(lastElem));



        }
        [Test]
        public void Fetch_Method_Should_Return_Copy()
        {
            Database db = new Database();
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                db.Add(i);
            }
            db.Remove();
            db.Remove();
            int[] firstCopy = db.Fetch();
            db.Add(1);

            int[] secondCopy = db.Fetch();

            Assert.AreNotEqual(firstCopy, secondCopy);

        }
    }
}
