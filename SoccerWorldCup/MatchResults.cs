using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration.Attributes;

namespace SoccerWorldCup
{
    public class MatchResults
    {
        [Index(0)]
        public int Match_id { get; set; }

        [Index(1)]
        public string Date_of_Match { get; set; }

        [Index(2)]
        public string Start_Time_Of_Match { get; set; }

        [Index(3)]
        public string Team1 { get; set; }

        [Index(4)]
        public string Team2 { get; set; }

        [Index(5)]
        public int Team1_score { get; set; }

        [Index(6)]
        public int Team2_score { get; set; }

        [Index(7)]
        public string Stadium_Name { get; set; }

        [Index(8)]
        public string Host_City { get; set; }
    }
}