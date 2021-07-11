using System;
using System.Linq;
using Eto.Forms;
using MusicPlayer.Common;
using MusicPlayer.Core;

namespace MusicPlayer.UI
{
    public class MainForm : Form
    {
        private Player _player = new Player();
        private Song _currentSong;
        
        public MainForm()
        {
            Title = "Music Player";
            Content = BuildContent();
        }

        private TableLayout BuildContent()
        {
            var layout = new TableLayout();

            var songLabel = new Label();
            
            var playPauseButton = new Button((sender, e) =>
            {
                _player.PlayPause();
                ((Button) sender).Text = GetFormattedPlayPause();
            });
            playPauseButton.Text = GetFormattedPlayPause();
            
            var openButton = new Button((sender, e) =>
            {
                var dialog = new OpenFileDialog() { MultiSelect = false };
                dialog.ShowDialog(this);
                _player.Load(dialog.FileName);
                _player.Play();
                _currentSong = Song.GetFromFile(dialog.FileName);
                songLabel.Text = GetFormattedSong();
                playPauseButton.Text = GetFormattedPlayPause();
            });
            openButton.Text = "Open";

            layout.Rows.Add(new TableRow(songLabel, null));
            layout.Rows.Add(new TableRow(openButton, playPauseButton, null));
            layout.Rows.Add(null);
            
            return layout;
        }

        private string GetFormattedPlayPause()
            => _player.State == PlayerState.Playing ? "Pause" : "Play";

        private string GetFormattedSong()
        {
            if (_currentSong.Artist == "" || _currentSong.Title == "")
                return _currentSong.Path.Split('/').Last();

            return $"{_currentSong.Artist} - {_currentSong.Title}";
        }
    }
}