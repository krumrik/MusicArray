using System;

public class Program
{
    public enum MusicGenre
    {
        Rock,
        Rap,
        RnB,
        Indie,
        Jazz
    }

    public struct Music
    {
        public string Title;
        public string Artist;
        public string Album;
        public double Length;
        public MusicGenre Genre;

        /*
        public Music(string title, string artist, string album, double length, MusicGenre genre)
        {
            Title = title;
            Artist = artist;
            Album = album;
            Length = length;
            Genre = genre;
        }
        */

        public Music(string title = "", string artist = "", string album = "", double length = 0, MusicGenre genre = MusicGenre.Rock)
        {
            Title = title;
            Artist = artist;
            Album = album;
            Length = length;
            Genre = genre;
        }

        public void SetArtist(string artist)
        {
            Artist = artist;
        }

        public void SetAlbum(string album)
        {
            Album = album;
        }

        public void SetGenre(MusicGenre genre)
        {
            Genre = genre;
        }

        public void SetLength(double length)
        {
            Length = length;
        }

        public string Display()
        {
            return $"Title: {Title}\nArtist: {Artist}\nAlbum: {Album}\nLength: {Length} minutes\nGenre: {Genre}";
        }
    }

    public static void Main()
    {
        Console.WriteLine("How many songs would you like to enter?");
        int size = int.Parse(Console.ReadLine());
        Music[] collection = new Music[size];

        try
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the information for Song {i + 1}:");

                Console.Write("What is the name of the song? ");
                collection[i].Title = Console.ReadLine();

                Console.Write("Who is the artist? ");
                collection[i].SetArtist(Console.ReadLine());

                Console.Write("What album is it on? ");
                collection[i].SetAlbum(Console.ReadLine());

                Console.Write("Enter the length of the song (in minutes): ");
                collection[i].SetLength(double.Parse(Console.ReadLine()));

                Console.WriteLine("What is the genre of the song?");
                foreach (MusicGenre genre in Enum.GetValues(typeof(MusicGenre)))
                {
                    Console.WriteLine($"{(int)genre}. {genre}");
                }
                Console.Write("Enter Genre (choose the corresponding number): ");
                int genreChoice = int.Parse(Console.ReadLine());
                collection[i].SetGenre((MusicGenre)genreChoice);
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(collection[i].Display());
            }
        }
    }
}
