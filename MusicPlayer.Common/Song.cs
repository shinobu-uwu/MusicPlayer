using TagLib;

namespace MusicPlayer.Common
{
    public class Song
    {
        public string Path { get; }
        public string Title { get; }
        public string Album { get; }
        public string Artist { get; }

        public Song(string path, string title, string album, string artist)
        {
            Path = path;
            Title = title;
            Album = album;
            Artist = artist;
        }

        public static Song GetFromFile(string path)
        {
            var file = File.Create(path);
            return new Song(path, file.Tag.Title, file.Tag.Album, file.Tag.AlbumArtists[0]);
        }
    }
}