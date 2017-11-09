using System;

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

        public static void PrintAll(Song[] songs)
        {
            foreach (var song in songs)
            {
                Console.WriteLine(song.Length.HasValue
                    ? $"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}, Length = {song.Length}"
                    : $"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}");
            }
        }

        public static void PrintAll(Song[] songs, Genre genre)
        {
            foreach (var song in songs)
            {
                if (song.Genre == genre)
                {
                    Console.WriteLine(song.Length.HasValue
                        ? $"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}, Length = {song.Length}"
                        : $"Name = {song.Name}, Author = {song.Author}, Genre = {song.Genre}");
                }               
            }
        }
        public static void TheLongest(Song[] songs)
        {
            float max = (float)songs[0].Length;
            int indexOfMax = 0;
            for (int i = 1; i < songs.Length; i++)
            {
                if (songs[i].Length > max)          
                {
                    max = (float)songs[i].Length;
                    indexOfMax = i;
                }
                if (i == songs.Length - 1)
                {
                    Console.WriteLine($"\nThe longest song:\n{songs[indexOfMax].Name}, {songs[indexOfMax].Author}," +
                                      $" {songs[indexOfMax].Genre}, {songs[indexOfMax].Length} minutes");
                }
            }
        }

        public static void AddSong(ref Song[] songs, string name, string author, Genre genre, float? length = null)
        {
            int lastIndex = songs.Length;
            Song[] temp = new Song[songs.Length + 1];
            for (int i = 0; i < songs.Length; i++)
            {
                temp[i] = songs[i];
            }
            songs = temp;
            songs[lastIndex] = new Song {Name = name, Author = author, Genre = genre, Length = length};
        }

        public static void DeleteSong(ref Song[] songs, int index)
        {
            Song[] temp = new Song[songs.Length - 1];
            for (int i = 0; i < songs.Length; i++)
            {
                if (i < index)
                {
                    temp[i] = songs[i];
                }
                else if (i > index)
                {
                    temp[i - 1] = songs[i];
                }               
            }
            songs = temp;
        }
    }
}
