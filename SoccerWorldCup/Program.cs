using System;
using MySql.Data.MySqlClient;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using ConsoleTables;

namespace SoccerWorldCup
{
    class Program
    {
        public static string connString = "Server=localhost;Port=3306;Database=soccer;Uid=root;password=DplUTA$123";
        static void Main(string[] args)
        {
            #region PrintConsoleOutput
            //Write Console Output to File
            //FileStream filestream = new FileStream(@"C:\Users\Deepak Prakash\source\repos\SoccerWorldCup\PrintOutput/Output.txt", FileMode.Create);
            //var streamwriter = new StreamWriter(filestream);
            //streamwriter.AutoFlush = true;
            #endregion
            string path = @"C:\Users\Deepak Prakash\source\repos\SoccerWorldCup\Input_Data\";
            List<string> file = new List<string>() { "Country.csv", "Players.csv", "Match_results.csv", "Player_Cards.csv", "Player_Assists_Goals.csv" };

            for (int i = 1; i <= 2; i++)
            {
                switch (i)
                {
                    case 1:
                        //Console.SetOut(streamwriter);
                        Console.WriteLine("1. Enter 1 to Insert Records into Tables Country, Players, Match_results, Player_Cards & Player_Assists_Goals");
                        break;
                    case 2:
                        Console.WriteLine("2. Exit");
                        break;
                    default: break;
                }
            }
            var key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    ReadCsvFiles(path, file);
                    break;

                case 2:
                    break;
                default: break;
            }

            #region PrintOutput
            //Console.SetError(streamwriter);
            #endregion
            Console.ReadLine();
        }
        public static void ReadCsvFiles(string path, List<string> file)
        {
            foreach (var item in file)
            {
                var filePath = path + item;
                using (var streamReader = new StreamReader(filePath))
                {
                    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false
                    };
                    using (var csvreader = new CsvReader(streamReader, csvConfig))
                    {
                        if (item == "Country.csv")
                        {
                            //Country
                            var records = csvreader.GetRecords<Country>().ToList();
                            Console.WriteLine("Country Data has been read from Country.csv");
                            Console.WriteLine("Inserting the Records to Country Table....");
                            InsertRecordsInCountryTables(records, item);
                        }
                        else if (item == "Players.csv")
                        {
                            //Players
                            var records = csvreader.GetRecords<Players>().ToList();
                            Console.WriteLine("Players Data has been read from Players.csv");
                            Console.WriteLine("Inserting the Records to Players Table....");
                            InsertRecordsInPlayersTbl(records, item);
                        }
                        else if (item == "Match_results.csv")
                        {
                            //Match_results
                            var records = csvreader.GetRecords<MatchResults>().ToList();
                            Console.WriteLine("Players Data has been read from Match_results.csv");
                            Console.WriteLine("Inserting the Records to Match_results Table....");
                            InsertRecordsInMatchResultTbl(records, item);
                        }
                        else if (item == "Player_Cards.csv")
                        {
                            //Player_Cards
                            var records = csvreader.GetRecords<PlayerCards>().ToList();
                            Console.WriteLine("Players Data has been read from Player_Cards.csv");
                            Console.WriteLine("Inserting the Records to Player_Cards Table....");
                            InsertRecordsInPlayerCardsTbl(records, item);
                        }
                        else
                        {
                            //Player_Assists_Goals
                            var records = csvreader.GetRecords<PlayerAssistsGoalTable>().ToList();
                            Console.WriteLine("Players Data has been read from Player_Assists_Goals.csv");
                            Console.WriteLine("Inserting the Records to Player_Assists_Goals Table....");
                            InsertRecordsInPlayerAssistsGoalTbl(records, item);
                        }
                    }
                }
            }

        }
        public static void InsertRecordsInCountryTables(List<Country> records, string filename)
        {
            for (int i = 0; i < records.Count(); i++)
            {
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Insert into country values(" +
                                        records[i].Country_Name + "," +
                                        records[i].Population + "," +
                                        records[i].No_of_Worldcup_won + "," +
                                        records[i].Manager + ")";


                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            Console.WriteLine("The Records have been successfully inserted");
            ReadTableData(filename);
        }
        public static void InsertRecordsInPlayersTbl(List<Players> records, string filename)
        {
            for (int i = 0; i < records.Count(); i++)
            {
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Insert into players values(" +
                                        records[i].Player_id + "," +
                                        records[i].Name + "," +
                                        records[i].Fname + "," +
                                        records[i].Lname + "," +
                                        records[i].DOB + "," +
                                        records[i].Country + "," +
                                        records[i].Height + "," +
                                        records[i].Club + "," +
                                        records[i].Position + "," +
                                        records[i].Caps_for_Country + "," +
                                        records[i].IS_CAPTAIN + ")";

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            Console.WriteLine("The Records have been successfully inserted");
            ReadTableData(filename);
        }
        public static void InsertRecordsInMatchResultTbl(List<MatchResults> records, string filename)
        {
            for (int i = 0; i < records.Count(); i++)
            {
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Insert into match_results values(" +
                                        records[i].Match_id + "," +
                                        records[i].Date_of_Match + "," +
                                        records[i].Start_Time_Of_Match + "," +
                                        records[i].Team1 + "," +
                                        records[i].Team2 + "," +
                                        records[i].Team1_score + "," +
                                        records[i].Team2_score + "," +
                                        records[i].Stadium_Name + "," +
                                        records[i].Host_City +
                                         ")";

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            Console.WriteLine("The Records have been successfully inserted");
            ReadTableData(filename);
        }

        public static void InsertRecordsInPlayerCardsTbl(List<PlayerCards> records, string filename)
        {
            for (int i = 0; i < records.Count(); i++)
            {
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Insert into player_cards values(" +
                                        records[i].Player_id + "," +
                                        records[i].Yellow_Cards + "," +
                                        records[i].Red_Cards +
                                         ")";

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            Console.WriteLine("The Records have been successfully inserted");
            ReadTableData(filename);
        }

        public static void InsertRecordsInPlayerAssistsGoalTbl(List<PlayerAssistsGoalTable> records, string filename)
        {
            for (int i = 0; i < records.Count(); i++)
            {
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Insert into player_assists_goals values(" +
                                        records[i].Player_id + "," +
                                        records[i].No_of_Matches + "," +
                                        records[i].Goals + "," +
                                        records[i].Assists + "," +
                                        records[i].Minutes_Played +
                                         ")";

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            Console.WriteLine("The Records have been successfully inserted");
            ReadTableData(filename);
        }

        public static void ReadTableData(string filename)
        {
            Console.WriteLine("Read data from the Tables");
            if (filename == "Country.csv")
            {
                Console.WriteLine("Select * from soccer.country;");
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Select * from country";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Country Table:");
                var table = new ConsoleTable("Country_Name", "Population", "No_of_Worldcup_won", "Manager");
                while (reader.Read())
                {
                    table.AddRow(reader["Country_Name"], reader["Population"], reader["No_of_Worldcup_won"], reader["Manager"]);
                }
                Console.WriteLine(table);
            }
            else if (filename == "Players.csv")
            {
                Console.WriteLine("Select * from soccer.players;");
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Select * from players";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Players Table:");
                var table = new ConsoleTable("Player_id", "Name", "Fname", "Lname", "DOB",
                    "Country", "Height", "Club", "Position", "Caps_for_Country", "IS_CAPTAIN");
                while (reader.Read())
                {
                    table.AddRow(reader["Player_id"], reader["Name"], reader["Fname"], reader["Lname"], reader["DOB"],
                        reader["Country"], reader["Height"], reader["Club"], reader["Position"],
                        reader["Caps_for_Country"], reader["IS_CAPTAIN"]);
                }
                Console.WriteLine(table);
            }
            else if (filename == "Match_results.csv")
            {
                Console.WriteLine("Select * from soccer.match_results;");
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Select * from match_results";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Match_results Table:");
                var table = new ConsoleTable("Match_id", "Date_of_Match", "Start_Time_Of_Match", "Team1", "Team2",
                    "Team1_score", "Team2_score", "Stadium_Name", "Host_City");
                while (reader.Read())
                {
                    table.AddRow(reader["Match_id"], reader["Date_of_Match"], reader["Start_Time_Of_Match"], reader["Team1"], reader["Team2"],
                        reader["Team1_score"], reader["Team2_score"], reader["Stadium_Name"], reader["Host_City"]);
                }
                Console.WriteLine(table);
            }
            else if (filename == "Player_Cards.csv")
            {
                Console.WriteLine("Select * from soccer.Player_Cards;");
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Select * from Player_Cards";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Player_Cards Table:");
                var table = new ConsoleTable("Player_id", "Yellow_Cards", "Red_Cards");
                while (reader.Read())
                {
                    table.AddRow(reader["Player_id"], reader["Yellow_Cards"], reader["Red_Cards"]);
                }
                Console.WriteLine(table);
            }
            else
            {
                Console.WriteLine("Select * from soccer.Player_Assists_Goals;");
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "Select * from player_assists_goals";
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Player_Assists_Goals Table:");
                var table = new ConsoleTable("Player_id", "No_of_Matches", "Goals", "Assists", "Minutes_Played");
                while (reader.Read())
                {
                    table.AddRow(reader["Player_id"], reader["No_of_Matches"], reader["Goals"], reader["Assists"], reader["Minutes_Played"]);
                }
                Console.WriteLine(table);
            }
            Console.WriteLine("------------------------------------------------------------------------------");
        }
    }
}
