using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizFundamentalsLinq
{
    public static class MovieExt
    {
        public static int GetAmountMovieLetters(this Movie movie)
        {
            return movie.Title.Length;
        }
    }
}
