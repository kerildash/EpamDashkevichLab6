using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamDashkevichLab6.Models
{
    struct Ticket
    {
        public readonly string _Title;
        public readonly string _Time;
        public readonly bool _Is3d;
        public readonly int _Row;
        public readonly double _Price1;
        public readonly double _Price2;
        public readonly double _Price3;
        public Ticket(string title, string time, bool is3d, int row,
            double price1, double price2, double price3)
        {
            _Title = title;
            _Time = time;
            _Is3d = is3d;
            _Row = row;
            _Price1 = price1;
            _Price2 = price2;
            _Price3 = price3;
        }
    }

    

    class Cinema
    {
        private Ticket[] _Tickets =
        {
            new Ticket("The Matrix Resurrections", "18:20", false, 2,
                9, 7, 8.50),
            new Ticket("Dune", "19:00", true, 8,
                7, 8, 5),
            new Ticket("Петровы в гриппе", "17:20", false, 5,
                5, 6, 6.20),
            new Ticket("One Flew Over the Cuckoo's Nest", "14:50", false, 4,
                3.90, 4.50, 4.50),
            new Ticket("Solaris", "15:00", true, 3,
                4, 3, 3)
        };

        public Tuple<string, string, string, double, bool> CheckTicket(string title, int seat, double price, string time)
        {
            try
            {
                Ticket ticket = Find(title);

                string placeType = $"r. {ticket._Row} s. {seat}";

                string is3d = "";
                if (ticket._Is3d == true)
                {
                    is3d = "3D.";
                }

                string ticketNumber = $"{is3d}{ticket._Row}.{seat}";

                double average = 
                    (ticket._Price1 + ticket._Price2 + ticket._Price3 + price) / 3f;

                bool isTime = false;
                if(time == ticket._Time)
                {
                    isTime = true;
                }

                return Tuple.Create(title, placeType, ticketNumber, average, isTime);
            }
            catch
            {
                return Tuple.Create(title, "N/A", "N/A", price, false);
            }
        }
        Ticket Find(string title)
        {
            foreach (Ticket ticket in _Tickets)
            {
                if (ticket._Title == title)
                {
                    return ticket;
                }
            }
            throw new Exception("Can not find this film");            
        }
    }
}
