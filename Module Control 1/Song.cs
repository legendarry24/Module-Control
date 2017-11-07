using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Control_1
{
    struct Song
    {
        public string Name;
        public string Author;
        public string Genre;
        public float? Length;
        public static Song[] Songs;

        public static void PrintAll()
        {
            foreach (var song in Songs)
            {
                if (song.Length.HasValue)
                {
                    Console.WriteLine($"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}, Length = {song.Length}");
                }
                else
                {
                    Console.WriteLine($"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}");
                }
            }
        }

        public static void PrintAll(string genre)
        {
            foreach (var song in Songs)
            {
                if (song.Genre == genre)
                {
                    if (song.Length.HasValue)
                    {
                        Console.WriteLine($"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}, Length = {song.Length}");
                    } else
                    {
                        Console.WriteLine($"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}");
                    }
                }               
            }
        }
        public static void TheLongest()
        {
            float max = (float)Songs[0].Length;
            for (int i = 1; i <= Songs.Length; i++)
            {
                if (i == Songs.Length)
                {
                    Console.WriteLine($"The longest song:\n {Songs[i - 1].Name}, {Songs[i - 1].Author}, {Songs[i - 1].Genre}, {Songs[i - 1].Length}");
                    break;
                }
                if (Songs[i].Length > max)          
                {
                    max = (float)Songs[i].Length;
                }
            }
        }
    }
}
