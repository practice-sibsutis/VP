// See https://aka.ms/new-console-template for more information

using System.Data;
using Dapper;
using DapperExample;
using DapperExample.Models.Chinook;
using Microsoft.Data.Sqlite;

string connectionString = "Data Source=../../../../usersdata.db;";
// Connect to the database
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    //QueryFirst
    string sql = "SELECT * FROM Users LIMIT 1";
    {
        Console.WriteLine($"QueryFirst {sql}:");
        User user = connection.QueryFirst<User>(sql);
        Console.WriteLine(user);
        Console.WriteLine();
    }

    //ExecuteScalar
    {
        sql = "select avg(Age) from Users";
        Console.WriteLine($"ExecuteScalar {sql}:");
        double avg = connection.ExecuteScalar<double>(sql);

        Console.WriteLine(avg);
        Console.WriteLine();
    }

    //ExecuteScalarAsync
    {
        sql = "select avg(Age) from Users";
        Console.WriteLine($"ExecuteScalarAsync {sql}:");
        double avg = await connection.ExecuteScalarAsync<double>(sql);

        Console.WriteLine(avg);
        Console.WriteLine();
    }

    //QuerySingle
    {
        sql = "select * from Users where _id = 2";
        Console.WriteLine($"QuerySingle {sql}:");
        User user = connection.QuerySingle<User>(sql);

        Console.WriteLine(user);
        Console.WriteLine();
    }

    //QuerySingleAsync
    {
        sql = "select * from Users where _id = 2";
        Console.WriteLine($"QuerySingleAsync {sql}:");
        User user = await connection.QuerySingleAsync<User>(sql);

        Console.WriteLine(user);
        Console.WriteLine();
    }

    //QuerySingleOrDefault
    {
        sql = "select * from Users where _id = 50";
        Console.WriteLine($"QuerySingleOrDefault {sql}:");
        User? user = connection.QuerySingleOrDefault<User>(sql);

        if (user is not null)
        {
            Console.WriteLine(user);
        }
        else
        {
            Console.WriteLine("User with _id = 50 is null");
        }
        
        Console.WriteLine();
    }

    //QuerySingleOrDefaultAsync
    {
        sql = "select * from Users where _id = 50";
        Console.WriteLine($"QuerySingleOrDefaultAsync {sql}:");
        User? user = await connection.QuerySingleOrDefaultAsync<User>(sql);

        if (user is not null)
        {
            Console.WriteLine(user);
        }
        else
        {
            Console.WriteLine("User with _id = 50 is null");
        }

        Console.WriteLine();
    }

    //QueryFirst
    {
        sql = "select * from Users";
        Console.WriteLine($"QueryFirst {sql}:");
        User user = connection.QueryFirst<User>(sql);

        Console.WriteLine(user);
        Console.WriteLine();
    }

    //QueryFirstAsync
    {
        sql = "select * from Users";
        Console.WriteLine($"QueryFirstAsync {sql}:");
        User user = await connection.QueryFirstAsync<User>(sql);

        Console.WriteLine(user);
        Console.WriteLine();
    }

    //QueryFirstOrDefault
    {
        sql = "select * from Users where age > 50";
        Console.WriteLine($"QueryFirstOrDefault {sql}:");
        User? user = connection.QueryFirstOrDefault<User>(sql);

        if (user is not null)
        {
            Console.WriteLine(user);
        }
        else
        {
            Console.WriteLine("Users with age > 50 is null");
        }

        Console.WriteLine();
    }

    //QueryFirstOrDefaultAsync
    {
        sql = "select * from Users where age > 50";
        Console.WriteLine($"QueryFirstOrDefaultAsync {sql}:");
        User? user = await connection.QueryFirstOrDefaultAsync<User>(sql);

        if (user is not null)
        {
            Console.WriteLine(user);
        }
        else
        {
            Console.WriteLine("Users with age > 50 is null");
        }

        Console.WriteLine();
    }

    //Query
    {
        sql = "select * from Users where age <= @age";
        Console.WriteLine($"Query {sql}:");
        IEnumerable<User> users = connection.Query<User>(sql, new {age = 32});

        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }

    //QueryAsync
    {
        sql = "select * from Users where age <= @age";
        Console.WriteLine($"QueryAsync {sql}:");
        IEnumerable<User> users = await connection.QueryAsync<User>(sql, new { age = 32 });

        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }

    //QueryMultiple
    {
        sql = @"
select * from Users where age <= 28;
select * from Users where age > 28 and age <= 32;
select * from Users where age > 32";

        Console.WriteLine($"QueryMultiple {sql}:");

        using (SqlMapper.GridReader multi = connection.QueryMultiple(sql))
        {
            /*
             * Read, ReadAsync
             * Read<T>, ReadAsync<T>
             * ReadFirst, ReadFirstAsync
             * ReadFirst<T>, ReadFirstAsync<T>
             * ReadFirstOrDefault, ReadFirstOrDefaultAsync
             * ReadFirstOrDefault<T>, ReadFirstOrDefaultAsync<T>
             * ReadSingle, ReadSingleAsync
             * ReadSingle<T>, ReadSingleAsync<T>
             * ReadSingleOrDefault, ReadSingleOrDefaultAsync
             * ReadSingleOrDefault<T>, ReadSingleOrDefaultAsync<T>
             */

            //Read
            IEnumerable<User> users = multi.Read<User>();

            foreach (User user in users)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();

            //ReadFirst
            User user2 = multi.ReadFirst<User>();

            Console.WriteLine(user2);
            Console.WriteLine();

            //ReadFirstOrDefault
            User? user3 = multi.ReadFirstOrDefault<User>();
            Console.WriteLine(user3);
            Console.WriteLine();
        }
    }

    //Select specific columns
    {
        sql = "select Name, Age from Users where Age >= 32";
        Console.WriteLine($"Select specific columns {sql}:");
        User? user = connection.QueryFirstOrDefault<User>(sql);

        if (user is not null)
        {
            Console.WriteLine(user);
        }
        else
        {
            Console.WriteLine("User with age >= 32 is null");
        }
    }

    //Insert
    {
        sql = "insert into Users (Name, Age) values (@Name, @Age)";
        Console.WriteLine($"Insert {sql}:");
        object[] parameters = { new { Name = "Anton", Age = 22 } };
        int count = connection.Execute(sql, parameters);

        Console.WriteLine(count);

        sql = "select * from Users";
        IEnumerable<User> users = connection.Query<User>(sql);

        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }

    //Insert user
    {
        sql = "insert into Users (Name, Age) values (@Name, @Age)";
        Console.WriteLine($"Insert user {sql}:");
        User newUser = new User() { Name = "Anton", Age = 15 };
        int count = connection.Execute(sql, newUser);

        Console.WriteLine(count);

        sql = "select * from Users";
        IEnumerable<User> users = connection.Query<User>(sql);

        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }

    //Insert multiple users
    {
        sql = "insert into Users (Name, Age) values (@Name, @Age)";
        Console.WriteLine($"Insert multiple users {sql}:");
        List<User> newUsers = new List<User>()
        {
            new User(){Name="Anton1", Age = 10},
            new User(){Name="Anton2", Age = 11},
            new User(){Name="Anton3", Age = 12},
        };
        
        int count = connection.Execute(sql, newUsers);

        Console.WriteLine(count);

        sql = "select * from Users";
        IEnumerable<User> users = connection.Query<User>(sql);

        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }

    //Update
    {
        sql = "update Users set age = @age where _id = @_id";
        Console.WriteLine($"Update {sql}:");
        object[] parameters = { new { age = 32, _id = 10 } };
        int count = connection.Execute(sql, parameters);

        Console.WriteLine(count);

        sql = "select * from Users";
        IEnumerable<User> users = connection.Query<User>(sql);

        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }

    //Delete
    {
        sql = "delete from Users where name = @name";
        Console.WriteLine($"Delete {sql}:");
        object[] parameters = { new { name = "Anton" } };
        int count = connection.Execute(sql, parameters);

        Console.WriteLine(count);

        sql = "select * from Users";
        IEnumerable<User> users = connection.Query<User>(sql);

        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }

    //Dynamic parameters
    {
        sql = "select * from Users where age <= @age";
        Console.WriteLine($"Dynamic parameters {sql}:");
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@age", 32, DbType.Int32);
        IEnumerable<User> users = connection.Query<User>(sql, dynamicParameters);

        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }

    //Where in parameters
    {
        sql = "select * from Users where age in @Ages";
        Console.WriteLine($"\'Where in parameters\' {sql}:");
        int[] ages = new[] { 20, 30, 32, 33, 36, 40 };
        IEnumerable<User> users = connection.Query<User>(sql, new { Ages = ages });

        foreach (User user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }
}

//Relationships
connectionString = "Data Source=../../../../chinook.db;";
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    string sql = "select trackid, name, title from tracks inner join albums on albums.albumid = tracks.albumid";

    //One to many
    {
        IEnumerable<Track> tracks = connection.Query<Track, Album, Track>(sql, (track, album) =>
            {
                track.Album = album;
                return track;
            },
            splitOn: "title");


        foreach (Track track in tracks)
        {
            Console.WriteLine($"{track.TrackId} {track.Name} FROM ALBUM {track.Album.Title}");
        }

        Console.WriteLine();
    }

    //Many to many
    {
        sql = @"select t.trackid, t.name, p.playlistid, p.name 
from Playlists p 
inner join playlist_track pt on pt.playlistid = p.playlistid 
inner join tracks t on t.trackid = pt.trackid";

        IEnumerable<Playlist> playlists = connection.Query<Track, Playlist, Playlist>(sql, (track, playlist) =>
            {
                playlist.Tracks ??= new List<Track>();

                playlist.Tracks.Add(track);
                return playlist;
            },
            splitOn: "playlistid");


        foreach (Playlist playlist in playlists)
        {
            Console.WriteLine($"{playlist.Name}");

            foreach (Track playlistTrack in playlist.Tracks)
            {
                Console.Write($"{playlistTrack.Name} ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}