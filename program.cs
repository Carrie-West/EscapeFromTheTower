using System;
using System.Text.Json;
using System.Linq;

namespace Rapture{

    class Program{

        


        static void Main(string[] args){
            Console.Clear();
            string title = @"         
    ______________________________________________________________________
   /    _____               _____  _________  _    _   _____    ______    \
  /    |  __ \      /\     |  __ \ \__   __/ | |  | | |  __ \  |  ____|    \
  \    | |__) |    /  \    | |__) |   | |    | |  | | | |__) | | |__       / 
   \   |  _  /    / /\ \   |  ___/    | |    | |  | | |  _  /  |  __|     /
    \  | | \ \   / ____ \  | |        | |    | |__| | | | \ \  | |____   /
     \ |_|  \_\ /_/    \_\ |_|        |_|     \____/  |_|  \_\ |______| /
      \________________________________________________________________/ 
      
      ";


            Console.WriteLine(title);
            List<RandomEvent> randomEvents = RandomInit();
            List<PlotEvent> plotEvents = PlotInit();
            List<Location> locations = LocationInit();
            List<Item> items = ItemInit();
            

            var coach = locations.Single(location => location.Name == "Coach");
            Console.WriteLine("Welcome, player! What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"\nWelcome {name}!\n");

            Console.WriteLine("RAPTURE is a Choose-Your-Own adventure game, where you will investigate the mysterious disappearance of your fellow passengers on an airplane 30,000 feet in the air.\n");
            Player player = Player.PlayerInit(playerName: name);
            


            player.GetPlayerState();

            var start = plotEvents.Single(plotEvent => plotEvent.Name == "Start");

            Console.WriteLine(start.EventText);

            player.Go(coach);
            player.Take(items.Single(items=> items.Name =="Magazine"));
            player.Inventory();
            player.GetPlayerState();
        }

        static List<Location> LocationInit(){
            string fileName = "locations.json";
            string jsonString = File.ReadAllText(fileName);

            List<Location>locations = JsonSerializer.Deserialize<List<Location>>(jsonString);

            return locations;
        }

        static List<Item> ItemInit(){
            string fileName = "items.json";
            string jsonString = File.ReadAllText(fileName);

            List<Item>items = JsonSerializer.Deserialize<List<Item>>(jsonString);

            return items;
        }

        static List<RandomEvent> RandomInit(){
            string fileName = "randomEvents.json";
            string jsonString = File.ReadAllText(fileName);

            List<RandomEvent>events = JsonSerializer.Deserialize<List<RandomEvent>>(jsonString);

            return events;
        }

        static List<PlotEvent> PlotInit(){
            string fileName = "plotEvents.json";
            string jsonString = File.ReadAllText(fileName);

            List<PlotEvent>events = JsonSerializer.Deserialize<List<PlotEvent>>(jsonString);

            return events;
        }
    }

}
