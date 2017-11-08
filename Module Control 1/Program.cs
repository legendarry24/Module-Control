using System;

namespace Module_Control_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Song[] songs = new Song[]
            {
                new Song {Name = "Not Afraid", Author = "Eminem", Genre = Genre.Rap, Length = 3.49f },
                new Song {Name = "Rise", Author = "Skillet", Genre = Genre.Rock },
                new Song {Name = "My immortal", Author = "Evanescence", Genre = Genre.Rock },
                new Song {Name = "Paradize lost", Author =  "Hollywood undead", Genre = Genre.RapCore, Length = 4.35f},
                new Song {Name = "Pain", Author = "Hollywood undead", Genre = Genre.RapCore, Length = 2.51f }               
            };
            Song.PrintAll(ref songs);

            // Task 1
            Console.Write("\nEnter index of song you wanna edit name: ");
            int index = int.Parse(Console.ReadLine());
            Console.Write("Enter new name of song: ");
            string newName = Console.ReadLine();
            songs[index].Name = newName;
            Song.PrintAll(ref songs);

            // Task 2
            Song.TheLongest(ref songs);

            // Task 3
            Console.Write("\nEnter a genre of songs: ");
            var genre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine());
            Song.PrintAll(ref songs, genre);

            // Task 4
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("\n\rPress 'a' to add new song\nPress 'd' to delete song\nPress ESC to quit.");
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.A:
                        Console.Write("\rName*: ");
                        string name = Console.ReadLine();
                        Console.Write("\rAuthor*: ");
                        string author = Console.ReadLine();
                        Console.Write("\rGenre*: ");
                        genre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine());
                        Console.Write("\rLength: ");
                        float len;
                        float? length;
                        if (float.TryParse(Console.ReadLine(), out len))
                        {
                            length = len;
                        }
                        else
                        {
                            length = null;
                        }
                        Song.AddSong(ref songs, name, author, genre, length);
                        Song.PrintAll(ref songs);
                        break;
                    case ConsoleKey.D:
                        Console.Write("\rEnter index of song: ");
                        index = int.Parse(Console.ReadLine());
                        Song.DeleteSong(ref songs, index);
                        Song.PrintAll(ref songs);
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
