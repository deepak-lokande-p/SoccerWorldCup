using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerWorldCup
{
    public class Players
    {
        [Index(0)]
        public int Player_id { get; set; }

        [Index(1)]
        public string Name { get; set; }

        [Index(2)]
        public string Fname { get; set; }

        [Index(3)]
        public string Lname { get; set; }

        [Index(4)]
        public string DOB { get; set; }
        //public DateTime DOB { get; set; }

        [Index(5)]
        public string Country { get; set; }

        [Index(6)]
        public int Height { get; set; }

        [Index(7)]
        public string Club { get; set; }

        [Index(8)]
        public string Position { get; set; }

        [Index(9)]
        public int Caps_for_Country { get; set; }

        [Index(10)]
        public bool IS_CAPTAIN { get; set; }
    }
}