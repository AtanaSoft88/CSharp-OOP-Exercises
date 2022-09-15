using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Demo_Json_Newton
{
    public class Data
    {
        public int Id { get; set; }
        public int SSN { get; set; }
        public string Message { get; set; }


        public List<Data> ListGenerator()
        {
            List<Data> dataList = new List<Data>();
            List<string> randMessages = new List<string>
            {       "Nice day!", "Hope for you!", "Cooldown starts now!", "Are you ready?",
                    "A good job!", "Hope you can swim!", "Coolest party starts now!", "Are you ready for the life?",
                    "Can't belive in miracles?", "Belive or not you are good!", "Coolest strategy!", "Are you serious?",
                    "Why don't you come?", "Belive me or not!", "Cool story ,bro!", "Are you a good man?",
                    " Do you belive in me?", "Start living!", "Goals are hard to be achieved!", "May your dreams come true!",
                    "I belive i can fly", "Stop complaining!", "Can i fly with you?!", "Many man dont deserve to be men!",
                    "I will not be sorry for you!", "Think about me!", "Do you think i can be?!", "Oh wtf are you doing??!",
                    "The cheap gets expesive later!", "Thanks to me!", "Do have a car?", "Oh wtf, you can talk??!",
                    "You turned to be a lazy man!", "Dont be so shy!","A good good day"," Oh ..holly shit are you an idiot?!",
                    "Live now, tommorow is late!" , "One,two,three, now you come to me!","Give me some Ice","Are you ok?!"
            };
            int limitData = randMessages.Count;
            //Adding elements to a List<int> with AddRange()
            //List<int> idList = new List<int>();
            //idList.AddRange(Enumerable.Range(1, 100));

            // Creating new ID list of int (1,100) , and SSN int List (123,1200)

            List<int> idList = Enumerable.Range(1, 100).ToList();
            List<int> SSNList = Enumerable.Range(123, 1200).ToList();


            for (int i = 0; i < limitData; i++)
            {
                int idRandIndex = new Random().Next(0, idList.Count);
                int SSNRandIndex = new Random().Next(0, SSNList.Count);
                int indexMessage = new Random().Next(0, randMessages.Count);
                
                dataList.Add(new Data()
                {
                    Id = idRandIndex,
                    SSN = SSNRandIndex,
                    Message = randMessages[indexMessage]
                });
                randMessages.RemoveAt(indexMessage);
                idList.RemoveAt(idRandIndex);
                SSNList.RemoveAt(SSNRandIndex);
            }
            return dataList;
        }
    }

    
}
