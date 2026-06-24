using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieSearchApp
{
    public class MovieRepository
    {
        private readonly string _dbPath;
        private readonly string _connectionString;

        public MovieRepository()
        {
            var appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "MovieSearchApp"
            );

            Directory.CreateDirectory(appDataPath);

            _dbPath = Path.Combine(appDataPath, "MovieSearchApp.db");
            _connectionString = $"Data Source={_dbPath}";
        }

        public void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
                CREATE TABLE IF NOT EXISTS Movies (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    ActorName TEXT NOT NULL,
                    Genre TEXT,
                    NicePoint TEXT,
                    Rating INTEGER,
                    Url TEXT
                );
            ";

            command.ExecuteNonQuery();
        }

        public List<Movie> GetAll()
        {
            var movies = new List<Movie>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
                SELECT
                    Id,
                    Title,
                    ActorName,
                    Genre,
                    NicePoint,
                    Rating,
                    Url
                FROM Movies
                ORDER BY Id DESC;
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                movies.Add(ReadMovie(reader));
            }

            return movies;
        }

        public List<Movie> Search(
            string title,
            string actorName,
            string genre,
            string nicePoint,
            bool useAndSearch)
        {
            var movies = new List<Movie>();
            var conditions = new List<string>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            AddKeywordConditions(command, conditions, "Title", "title", title);
            AddKeywordConditions(command, conditions, "ActorName", "actorName", actorName);
            AddKeywordConditions(command, conditions, "Genre", "genre", genre);
            AddKeywordConditions(command, conditions, "NicePoint", "nicePoint", nicePoint);

            if (conditions.Count == 0)
            {
                return GetAll();
            }

            var searchOperator = useAndSearch ? " AND " : " OR ";

            command.CommandText =
            $@"
        SELECT
            Id,
            Title,
            ActorName,
            Genre,
            NicePoint,
            Rating,
            Url
        FROM Movies
        WHERE {string.Join(searchOperator, conditions)}
        ORDER BY Id DESC;
    ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                movies.Add(ReadMovie(reader));
            }

            return movies;
        }
        private void AddKeywordConditions(
            SqliteCommand command,
            List<string> conditions,
            string columnName,
            string parameterBaseName,
            string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            var keywords = input
                .Split(
                    new[]
                    {
                ' ',
                '　',
                ',',
                '，',
                '、'
                    },
                    StringSplitOptions.RemoveEmptyEntries
                )
                .Select(keyword => keyword.Trim())
                .Where(keyword => !string.IsNullOrWhiteSpace(keyword))
                .ToList();

            for (int i = 0; i < keywords.Count; i++)
            {
                var parameterName = $"@{parameterBaseName}{i}";

                conditions.Add($"{columnName} LIKE {parameterName}");
                command.Parameters.AddWithValue(parameterName, $"%{keywords[i]}%");
            }
        }
        public void Add(Movie movie)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
                INSERT INTO Movies
                (
                    Title,
                    ActorName,
                    Genre,
                    NicePoint,
                    Rating,
                    Url
                )
                VALUES
                (
                    @title,
                    @actorName,
                    @genre,
                    @nicePoint,
                    @rating,
                    @url
                );
            ";

            command.Parameters.AddWithValue("@title", movie.Title);
            command.Parameters.AddWithValue("@actorName", movie.ActorName);
            command.Parameters.AddWithValue("@genre", movie.Genre);
            command.Parameters.AddWithValue("@nicePoint", movie.NicePoint);
            command.Parameters.AddWithValue("@rating", movie.Rating);
            command.Parameters.AddWithValue("@url", movie.Url);

            command.ExecuteNonQuery();
        }

        public void Update(Movie movie)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
                UPDATE Movies
                SET
                    Title = @title,
                    ActorName = @actorName,
                    Genre = @genre,
                    NicePoint = @nicePoint,
                    Rating = @rating,
                    Url = @url
                WHERE Id = @id;
            ";

            command.Parameters.AddWithValue("@id", movie.Id);
            command.Parameters.AddWithValue("@title", movie.Title);
            command.Parameters.AddWithValue("@actorName", movie.ActorName);
            command.Parameters.AddWithValue("@genre", movie.Genre);
            command.Parameters.AddWithValue("@nicePoint", movie.NicePoint);
            command.Parameters.AddWithValue("@rating", movie.Rating);
            command.Parameters.AddWithValue("@url", movie.Url);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
                DELETE FROM Movies
                WHERE Id = @id;
            ";

            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public List<FrequencyItem> GetActorRanking()
        {
            var movies = GetAll();

            return CreateFrequencyRanking(
                movies.Select(movie => movie.ActorName)
            );
        }

        public List<FrequencyItem> GetGenreRanking()
        {
            var movies = GetAll();

            return CreateFrequencyRanking(
                movies.Select(movie => movie.Genre)
            );
        }

        private List<FrequencyItem> CreateFrequencyRanking(IEnumerable<string> values)
        {
            var dictionary = new Dictionary<string, int>();

            char[] separators =
            {
        ',',
        '，',
        '、',
        '/',
        '／',
        ';',
        '；',
        '|',
        '\n',
        '\r'
    };

            foreach (var value in values)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                var words = value
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.Trim())
                    .Where(word => !string.IsNullOrWhiteSpace(word));

                foreach (var word in words)
                {
                    if (dictionary.ContainsKey(word))
                    {
                        dictionary[word]++;
                    }
                    else
                    {
                        dictionary[word] = 1;
                    }
                }
            }

            return dictionary
                .OrderByDescending(item => item.Value)
                .ThenBy(item => item.Key)
                .Select(item => new FrequencyItem
                {
                    Word = item.Key,
                    Count = item.Value
                })
                .ToList();
        }

        public List<FrequencyItem> GetNicePointRanking()
        {
            var movies = GetAll();

            return CreateFrequencyRanking(
                movies.Select(movie => movie.NicePoint)
            );
        }

        private Movie ReadMovie(SqliteDataReader reader)
        {
            return new Movie
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                ActorName = reader.GetString(2),
                Genre = reader.IsDBNull(3) ? "" : reader.GetString(3),
                NicePoint = reader.IsDBNull(4) ? "" : reader.GetString(4),
                Rating = reader.IsDBNull(5) ? 3 : reader.GetInt32(5),
                Url = reader.IsDBNull(6) ? "" : reader.GetString(6)
            };
        }
    }
}