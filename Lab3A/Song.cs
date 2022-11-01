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
    class Song:Media, ISearchable
    {
        private string album;
        private string artist;

        /// <summary>
        /// Main constructor for Song
        /// </summary>
        /// <param name="songTitle"></param>
        /// <param name="year"></param>
        /// <param name="album"></param>
        /// <param name="artist"></param>
        public Song(string songTitle, int year, string album, string artist):base(songTitle, year)
        {
            this.Title = songTitle;
            this.Year = year;
            this.album = album;
            this.artist = artist;
        }
        /// <summary>
        /// To String method
        /// </summary>
        /// <returns>The title, year, album and artist of the song</returns>
        public override string ToString()
        {
            return $"***************\nSong Title: {base.Title},  ({base.Year})\nAlbum: {album} Artist: {artist}\n***************";
        }
    }
}
