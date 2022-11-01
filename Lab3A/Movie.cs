///I, Wanaemi Immanuella Amaegbe, 000785864 certify that this material is my original worl. No other person's work has been used without due acknowledgement.
///Author: Wanaemi Immanuella Amaegbe, 000785864
///Date created: 01-11-2022
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    class Movie:Media, IEncryptable
    {
        private string director;
        private string summary;
        /// <summary>
        /// Main constructor for Movie
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <param name="year"></param>
        /// <param name="director"></param>
        /// <param name="summary"></param>
        public Movie(string movieTitle, int year, string director, string summary):base(movieTitle, year)
        {
            this.Title = movieTitle;
            this.Year = year;
            this.director = director;
            this.summary = summary;
        }
        /// <summary>
        /// Encrypt method to encrypt the summary
        /// </summary>
        /// <returns>The encrypted summary</returns>
        public string Encrypt()
        {
            return !string.IsNullOrEmpty(summary) ?
                 new string(summary.Select(x => (x >= 'a' && x <= 'z') ? (char)((x - 'a' + 13) % 26 + 'a') : ((x >= 'A' && x <= 'Z') ?
                 (char)((x - 'A' + 13) % 26 + 'A') : x)).ToArray()) : summary;
        }
        /// <summary>
        /// Decrypt method to decrypt the summary
        /// </summary>
        /// <returns>The decrypted summary</returns>
        public string Decrypt()
        {
            return !string.IsNullOrEmpty(summary) ?
                    new string(summary.Select(x => (x >= 'a' && x <= 'z') ? (char)((x - 'a' + 13) % 26 + 'a') : ((x >= 'A' && x <= 'Z') ?
                    (char)((x - 'A' + 13) % 26 + 'A') : x)).ToArray()) : summary;

        }
        /// <summary>
        /// To String method
        /// </summary>
        /// <returns>The title, year, and director of the movie</returns>
        public override string ToString()
        {
            return $"***************\nMovie Title: {base.Title},  ({base.Year})\nDirector: {director}\n***************";
        }
    }
}
