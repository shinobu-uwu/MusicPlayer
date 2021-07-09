using System;
using ManagedBass;
using MusicPlayer.Common;

namespace MusicPlayer.Core
{
    public class Player
    {
        private int _currentStream;
        
        public Song CurrentSong { get; private set; }
        
        public PlayerState State { get; private set; }
        
        public Player()
        {
            if (!Bass.Init())
                throw new Exception("Bass failed to intialize");

            State = PlayerState.Paused;
        }

        ~Player()
        {
            Bass.Free();
        }

        public void Load(string path)
        {
            var stream = Bass.CreateStream(path);

            if (stream == 0)
                throw new Exception("File not supported");

            _currentStream = stream;
            CurrentSong = Song.GetFromFile(path);
        }

        public void PlayPause()
        {
            if (State == PlayerState.Playing)
            {
                Pause();
                return;
            }
            // Player is paused
            Play();
        }

        public void Play()
        {
            State = PlayerState.Playing;
            Bass.ChannelPlay(_currentStream);
        }

        public void Pause()
        {
            State = PlayerState.Paused;
            Bass.ChannelPause(_currentStream);
        }
    }
}