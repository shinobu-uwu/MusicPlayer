using System;
using System.Threading.Tasks;
using ManagedBass;

namespace MusicPlayer.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new MusicPlayer();
            player.Load(args[0]);
            player.PlayPause();

            Console.WriteLine("Press esc to quit, espace to pause and unpause!");
            // Do not block the player thread
            Task.Run(() =>
            {
                while (true)
                {
                    var key = Console.ReadKey();
                    
                    if (key.Key == ConsoleKey.Spacebar)
                        player.PlayPause();
                    else if (key.Key == ConsoleKey.Escape)
                        break;
                }
            }).Wait();
        }
    }
}