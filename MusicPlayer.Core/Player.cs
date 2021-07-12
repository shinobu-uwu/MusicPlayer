using System;
using ManagedBass;
using MusicPlayer.Common;
using MusicPlayer.Core.Engine;

namespace MusicPlayer.Core
{
    public class Player
    {
        private PlayerEngine _playerEngine;

        public PlayerState State { get; private set; } = PlayerState.Paused;
        public Song CurrentSong { get; private set; }

        public double Volume
        {
            get => Bass.Volume;
            set => Bass.Volume = value;
        }
        
        public void Load(string path)
        {
           _playerEngine.Load(path);
           CurrentSong = Song.GetFromFile(path);
        }

        public void PlayPause()
        {
            if (State == PlayerState.Playing)
            {
                Pause();
                return;
            }
            
            Play();
        }

        public void Play()
        {
            _playerEngine.Play();
            State = PlayerState.Playing;
        }

        public void Pause()
        {
            _playerEngine.Pause();
            State = PlayerState.Paused;
        }
    }
}