using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Control_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Song.Songs = new Song[]
            {
                new Song {Name = "Not Afraid", Author = "Eminem", Genre = "Rap", Length = 3.49f },
                new Song {Name = "Rise", Author = "Skillet", Genre = "Rock" },
                new Song {Name = "My immortal", Author = "Evanescence", Genre = "Rock" },
                new Song {Name = "Pain", Author = "Hollywood undead", Genre = "RapCore", Length = 2.51f },
                new Song {Name = "Paradize lost", Author =  "Hollywood undead", Genre = "RapCore", Length = 4.35f}
            };

            foreach (var song in Song.Songs)
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
            // Task 1
            Console.Write("\nEnter index of song you wanna edit name: ");
            int index = int.Parse(Console.ReadLine());
            Console.Write("Enter new name of song: ");
            string newName = Console.ReadLine();
            Song.Songs[index].Name = newName;

            Song.PrintAll();
            // Task 2
            Song.TheLongest();
            // Task 3
            Console.Write("\nEnter genre of songs: ");
            string genre = Console.ReadLine();
            Song.PrintAll(genre);
            Console.ReadKey();
        }
    }
}
