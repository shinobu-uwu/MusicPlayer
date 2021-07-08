using System;
using System.Collections.Generic;
using ManagedBass;
using MusicPlayer.Common;

namespace MusicPlayer.Core
{
    public class MusicPlayer
    {
        private int _currentStream;
        
        public PlayerState State { get; private set; }
        
        public MusicPlayer()
        {
            if (!Bass.Init())
                throw new Exception("Bass failed to intialize");

            State = PlayerState.Paused;
        }

        ~MusicPlayer()
        {
            Bass.Free();
        }

        public void Load(string path)
        {
            var stream = Bass.CreateStream(path);

            if (stream == 0)
                throw new Exception("File not supported");

            _currentStream = stream;
        }

        public void PlayPause()
        {
            if (State == PlayerState.Playing)
            {
                State = PlayerState.Paused;
                Bass.ChannelPause(_currentStream);
                return;
            }
            // Player is paused
            State = PlayerState.Playing;
            Bass.ChannelPlay(_currentStream);
        }
    }
}