using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIPGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            HashSet<string> actualPartyGuests = new HashSet<string>();

            string guestId = Console.ReadLine();

            while (guestId != "PARTY")
            {

                if (char.IsDigit(guestId[0]))
                {
                    VIPGuests.Add(guestId);
                }
                else
                {
                    regularGuests.Add(guestId);
                }

                guestId = Console.ReadLine();
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                actualPartyGuests.Add(command);


                command = Console.ReadLine();
            }
            List<string> absentGuestList = new List<string>();

            foreach (var guest in VIPGuests)
            {
                if (!actualPartyGuests.Contains(guest))
                {
                    absentGuestList.Add(guest);

                }

            }
            foreach (var guest in regularGuests)
            {
                if (!actualPartyGuests.Contains(guest))
                {
                    absentGuestList.Add(guest);
                }
            }
            int totalInvitedToParty = absentGuestList.Count;
            Console.WriteLine(totalInvitedToParty);
            foreach (var item in absentGuestList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
