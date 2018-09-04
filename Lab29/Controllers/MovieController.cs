using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab29.Models;

namespace Lab29.Controllers
{
    public class MovieController : ApiController
    {
        public List<movie> GetAllMovies()
        {
            moviedbEntities ORM = new moviedbEntities();

            List<movie> movies = ORM.movies.ToList();

            return movies;
        }

        public List<movie> GetMoviesByCategory(string category)
        {
            moviedbEntities ORM = new moviedbEntities();
            
            List<movie> movies = ORM.movies.Where(x => x.category.ToLower() == category.ToLower()).ToList();
            if (movies != null)
            return movies;

            return null;
        }

        public movie GetRandomMovie()
        {
            moviedbEntities ORM = new moviedbEntities();

            List<movie> movies = ORM.movies.ToList();

            Random rnd = new Random();

            if (movies != null)
            return movies[rnd.Next(0, movies.Count)];

            return null;
        }

        public movie GetRandomMovieByCategory(string category)
        {
            moviedbEntities ORM = new moviedbEntities();

            List<movie> movies = ORM.movies.Where(x => x.category.ToLower() == category.ToLower()).ToList();

            Random rnd = new Random();

            if (movies != null)
            return movies[rnd.Next(0, movies.Count)];

            return null;
        }

        public List<string> GetMovieCategories()
        {
            moviedbEntities ORM = new moviedbEntities();

            List<string> categories = ORM.movies.Where(x => x.category != null).Select(x => x.category).Distinct().ToList();
            if (categories != null)
            return categories;

            return null;
        }

        public movie GetMovieByTitle(string title)
        {
            moviedbEntities ORM = new moviedbEntities();

            List<movie> movies = ORM.movies.Where(x => x.title.ToLower() == title.ToLower()).ToList();
            if (movies != null)
            return movies[0];

            return null;
        }

        public List<movie> GetMoviesByKeyword(string keyword)
        {
            moviedbEntities ORM = new moviedbEntities();

            List<movie> movies = ORM.movies.Where(x => x.title.ToLower().Contains(keyword.ToLower())).ToList();

            if (movies != null)
                return movies;

            return null;
        }
    }
}