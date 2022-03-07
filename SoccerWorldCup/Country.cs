using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerWorldCup
{
    public class Country
    {
        [Index(0)]
        public string Country_Name { get; set; }

        [Index(1)]
        public Decimal Population { get; set; }

        [Index(2)]
        public int No_of_Worldcup_won { get; set; }

        [Index(3)]
        public string Manager { get; set; }
    }
}
