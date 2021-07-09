using Eto.Forms;
using MusicPlayer.Common;
using MusicPlayer.Core;

namespace MusicPlayer.UI
{
    public class MainForm : Form
    {
        private Player _player = new Player();
        public MainForm()
        {
            Title = "Music Player";
            Content = BuildContent();
        }

        private TableLayout BuildContent()
            => new TableLayout
            {
                Rows =
                {
                    new TableRow(
                        new TableCell(new Button((sender, e) =>
                        {
                            var dialog = new OpenFileDialog { MultiSelect = false };
                            dialog.ShowDialog(this);
                            _player.Load(dialog.FileName);
                            _player.PlayPause();
                        }) { Text = "Open" }),
                        new TableCell(new Button((sender, e) =>
                            {
                                _player.PlayPause();
                                var button = (Button) sender;
                                if (_player.State == PlayerState.Paused)
                                {
                                    button.Text = "Play";
                                    return;
                                }

                                button.Text = "Pause";
                            })),
                        null
                    ),
                    null
                }
            };
    }
}