using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizFundamentalsLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie{ Title = "The Dark Night", Rating = 8.9f, Year = 2008},
                new Movie{ Title = "The King Speach", Rating = 8.0f, Year = 2010},
                new Movie{ Title = "Casablanca", Rating = 8.5f, Year = 1942},
                new Movie{ Title = "Star Wars V", Rating = 8.7f, Year = 1980},
                new Movie{ Title = "The Big Tease", Rating = 8.7f, Year = 1980},
                new Movie{ Title = "Eye of the Beholder", Rating = 8.7f, Year = 1980},
                new Movie{ Title = "Simpatico", Rating = 8.7f, Year = 1980},
                new Movie{ Title = "Scream 3", Rating = 8.7f, Year = 1980},
                new Movie{ Title = "The Color of Friendship", Rating = 8.7f, Year = 1980},
            };

            // create extended method
            //foreach (var item in movies)
            //{
            //    item.GetAmountMovieLetters();
            //}

            //Get movies lower than year 2000
            //var query = from movie in movies
            //            where movie.Year < 2000
            //            select movie;

            //foreach (var movie in query)
            //{
            //    Console.WriteLine($"{movie.Title} : {movie.Year}");
            //}

            // Named Method
            //foreach (var movie in movies.Where(GetOldMovies))
            //{
            //    Console.WriteLine(movie.Title);
            //}

            //// Anonymous method
            //foreach (var movie in movies.Where(delegate (Movie m) { return m.Year > 2000; }))
            //{
            //    Console.WriteLine(movie.Title);
            //}

            //// Lambda Expression
            //foreach (var movie in movies.Where(m => m.Year > 2000))
            //{
            //    Console.WriteLine(movie.Title);
            //}

            //Func<Movie, bool> GetMoviesWithL = m => m.Title.StartsWith("T");

            //foreach (var movie in movies)
            //{
            //    Console.WriteLine(GetMoviesWithL(movie));
            //}

            // obtener todas las peliculas que tenga una longitud mayor a 5 y que se ordenen por titulo
            var query = from movie in movies
                        where movie.Title.Length > 15
                        orderby movie.Title descending
                        select movie;

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }

            var query2 = movies.Where(m => m.Title.Length > 15)
                               .OrderByDescending(m => m.Title)
                               .Select(m => m);

            foreach (var movie in query2)
            {
                Console.WriteLine(movie.Title);
            }

            //var directoryInfo = new DirectoryInfo(@"C:\windows");
            //var files = directoryInfo.GetFiles();

            //Console.WriteLine("--- WHITOUT LINQ ---");
            //SortFilesWithoutLinq(files);

            //Console.WriteLine("\n--- WITH QUERY SYNTAX ---");
            //SortFilesWithQuerySyntax(files);

            //Console.WriteLine("\n--- WITH METHOS SYNTAX ---");
            //SortFilesWithMethodsyntax(files);
        }

        private static bool GetOldMovies(Movie movie)
        {
            return movie.Year > 2000;
        }

        private static void SortFilesWithMethodsyntax(FileInfo[] files)
        {
            var query = files.OrderByDescending(f => f.Length)
                             .Take(5);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} : \t{item.Length}");
            }
        }

        private static void SortFilesWithQuerySyntax(FileInfo[] files)
        {
            var query = from file in files
                        orderby file.Length descending
                        select file;

            foreach (var item in query.Take(5))
            {
                Console.WriteLine($"{item.Name} :\t{item.Length}");
            }
        }

        private static void SortFilesWithoutLinq(FileInfo[] files)
        {
            Array.Sort(files, new FileComparer());

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].FullName} : \t{files[i].Length}");
            }
        }

    }

    class FileComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            if (x.Length < y.Length)
            {
                return 1;
            }
            if (x.Length > y.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
