// See https://aka.ms/new-console-template for more information

using System.Data.SQLite;

Console.WriteLine("Hello, World!");

// Create a new SQLite database file
SQLiteConnection.CreateFile("TestDatabase.sqlite");
// Connection string to the database
string connectionString = "Data Source=TestDatabase.sqlite;Version=3;";
using var connection = new SQLiteConnection(connectionString);
connection.Open();



// Create a table
string createTableQuery = @"
   CREATE TABLE IF NOT EXISTS TestTable (
       Id INTEGER PRIMARY KEY,
       Name TEXT,
       DateCreated DATETIME DEFAULT CURRENT_TIMESTAMP
   )";
using (var command = new SQLiteCommand(createTableQuery, connection))
{
    command.ExecuteNonQuery();
}
Console.WriteLine("Database and table created successfully!");


// Insert into table fake records
string insertTableQuery = @"
    INSERT INTO TestTable (Name) VALUES ('John Doe');
    INSERT INTO TestTable (Name) VALUES ('Jane Smith');
    INSERT INTO TestTable (Name) VALUES ('Alice Johnson');
";

using (var command = new SQLiteCommand(insertTableQuery, connection))
{
    command.ExecuteNonQuery();
}

// Output to console
string selectTableQuery = @"SELECT * FROM TestTable;";
using (var command = new SQLiteCommand(selectTableQuery, connection))
{
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, DateCreated: {reader["DateCreated"]}");
    }
}