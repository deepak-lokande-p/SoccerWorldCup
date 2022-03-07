using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration.Attributes;

namespace SoccerWorldCup
{
    public class PlayerAssistsGoalTable
    {
        [Index(0)]
        public int Player_id { get; set; }

        [Index(1)]
        public int No_of_Matches { get; set; }

        [Index(2)]
        public int Goals { get; set; }

        [Index(3)]
        public int Assists { get; set; }

        [Index(4)]
        public int Minutes_Played { get; set; }
    }
}