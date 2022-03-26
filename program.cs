using System;

namespace Rapture{

    class Program{
        static void Main(string[] args){
            Player player = Player.PlayerInit();
            Console.WriteLine($"Welcome {player.Name}!");
        }
    }

}
