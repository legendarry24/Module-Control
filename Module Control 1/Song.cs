using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Control_1
{
    enum Genre
    {
        Rap, Rock, RapCore, Pop, Alternative
    }
    struct Song
    {
        public string Name;
        public string Author;
        public Genre Genre;
        public float? Length;
        public static Song[] Songs;

        public static void PrintAll()
        {
            foreach (var song in Songs)
            {
                Console.WriteLine(song.Length.HasValue
                    ? $"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}, Length = {song.Length}"
                    : $"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}");
            }
        }

        public static void PrintAll(Genre genre)
        {
            foreach (var song in Songs)
            {
                if (song.Genre == genre)
                {
                    Console.WriteLine(song.Length.HasValue
                        ? $"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}, Length = {song.Length}"
                        : $"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}");
                }               
            }
        }
        public static void TheLongest()
        {
            float max = (float)Songs[0].Length;
            int indexOfMax = 0;
            for (int i = 1; i < Songs.Length; i++)
            {
                if (Songs[i].Length > max)          
                {
                    max = (float)Songs[i].Length;
                    indexOfMax = i;
                }
                if (i == Songs.Length - 1)
                {
                    Console.WriteLine($"\nThe longest song:\n{Songs[indexOfMax].Name}, {Songs[indexOfMax].Author}," +
                                      $" {Songs[indexOfMax].Genre}, {Songs[indexOfMax].Length} minutes");
                }
            }
        }

        public static void AddSong(string name, string author, Genre genre, float? length = null)
        {
            int lastIndex = Songs.Length;
            Song[] temp = new Song[Songs.Length + 1];
            for (int i = 0; i < Songs.Length; i++)
            {
                temp[i] = Songs[i];
            }
            Songs = temp;
            Songs[lastIndex] = new Song {Name = name, Author = author, Genre = genre, Length = length};
        }

        public static void DeleteSong(int index)
        {
            Song[] temp = new Song[Songs.Length - 1];
            for (int i = 0; i < Songs.Length; i++)
            {
                if (i < index)
                {
                    temp[i] = Songs[i];
                }
                else if (i > index)
                {
                    temp[i - 1] = Songs[i];
                }               
            }
            Songs = temp;
        }
    }
}
