using Greeting_Mocking;
using Moq;
using System.Text;

namespace MockingTests
{
    [TestFixture]
    public class GreetingTests
    {
        [SetUp]
        public void Setup()
        {

        }
        class MemoryWriter : IWriter
        {
            private StringBuilder sb = new StringBuilder();
            public void Write(string message)
            {
                sb.AppendLine(message);
            }

            public override string ToString()
            {
                return sb.ToString();
            }
        }

        //This test implements external getting data from class: IWriter - which is difficult and not using Mock object
        [Test]
        public void WriterShouldWorkCorrectlyInMorningMsg()
        {
            MemoryWriter writerMemo = new MemoryWriter();
            var writer = new GreetingWriter(writerMemo);
            writer.WriteGreeting(new DateTime(2023,1,1,8,0,0));
            Assert.True(writerMemo.ToString().Contains("morning"));

        }

        //Using Mock object
        [Test]
        public void WriterShouldWorkCorrectlyInEveningMsg()
        {
            //This would work with this MemoryWriter(), now lets use Mock
            //MemoryWriter writerMemo = new MemoryWriter();
            
            string result=null;
            //1) 
            var mockObject = new Mock<IWriter>();
            //2) 
            mockObject.Setup(x => x.Write(It.IsAny<string>()))
                .Callback((string a) => { result = a;});
            //3)   
            var writer = new GreetingWriter(mockObject.Object);
            writer.WriteGreeting(new DateTime(2023, 1, 1, 21, 30, 0));
            Assert.True(result.Contains("evening"));

            //На 1) - Поискваме фейк обект имплементиращ IWriter
            //На 2) взимаме конкретен метод Write от обекта и му казваме че с какъвто и да е параметър (It.IsAny<string>()) - в случая стринг ,защото метода иска стринг , но без значение какво пише в стринг-а - искам връщано поведение от Callback фунцкията,
            // която да пише в променливата "result", онова,което е записала функцията във "string a" и върнала.
            
        }
    }
}