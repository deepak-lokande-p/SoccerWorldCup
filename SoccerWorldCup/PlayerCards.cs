using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration.Attributes;

namespace SoccerWorldCup
{
    public class PlayerCards
    {
        [Index(0)]
        public int Player_id { get; set; }

        [Index(1)]
        public int Yellow_Cards { get; set; }

        [Index(2)]
        public int Red_Cards { get; set; }
    }
}