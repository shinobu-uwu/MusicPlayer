using System;
using ManagedBass;

namespace MusicPlayer.Core.Engine
{
    public class PlayerEngine : IDisposable
    {
        private int _currentStream;

        public PlayerEngine()
        {
            if (!Bass.Init())
                throw new Exception("Bass failed to intialize");
        }

        public void Load(string path)
        {
            var stream = Bass.CreateStream(path);

            if (stream == 0)
                throw new Exception("File not supported");

            _currentStream = stream;
        }

        public void Play()
        {
            Bass.ChannelPlay(_currentStream);
        }

        public void Pause()
        {
            Bass.ChannelPause(_currentStream);
        }
        
        public void Dispose()
        {
            Bass.Free();
        }
    }
}