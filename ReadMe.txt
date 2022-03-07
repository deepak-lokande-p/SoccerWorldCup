Requirements:
Visual Studio Community Edition (2019 preferable)
Databse: MySql

Programming Language: 
C#

Instructions:
1. Open SoccerWorldCup.sln from Visual Studio

2. In Program.cs, perform the following:
   a. Set the appropriate Connection String:
   (Below string is defined in Program.cs)
   eg. public static string connString = "Server=localhost;Port=3306;Database=soccer;Uid=root;password=DplUTA$123";   
   For connection string enter valid Server, Port, Database, Uid, Password
   
   b. Set the appropriate Input Data File path.
   (Below path is defined in Program.cs)
   eg. string path = @"C:\Users\Deepak Prakash\source\repos\SoccerWorldCup\Input_Data\";
   Enter a valid path that contains all the .csv files

3. Execute the program in Debug Mode.

4. View the output in c# Console.

5. Output of records may also be viewed in MySql Database.

Database Instructions:
1. Use the Db  Scripts provided in the path C:\SoccerWorldCup\Spooling Files\Script Files
2. After connecting to a particular instance in Myql, execute the DB Scripts from the file SampleDB_Scripts.txt one by one
3. The spooling file is located in C:\*\SoccerWorldCup\Spooling Files. Open the file SpoolingFile.txt to view the spooling file.
4. The output of the records inserted in each table can be found in C:\*\repos\SoccerWorldCup\PrintOutput\Output.txt
5. The output can also be viewed in c# console
6. Furthermore, the DB output screenshots can be viewed in C:\*\repos\SoccerWorldCup\PrintOutput\ 
