using TagLib;

namespace MusicPlayer.Common
{
    public class Song
    {
        public string Path {get; private set; }
        public string Title { get; private set; }
        public string Album { get; private set; }
        public string Artist { get; private set; }

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