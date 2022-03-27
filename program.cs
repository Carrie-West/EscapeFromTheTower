using System;
using System.Text.Json;
using System.Linq;

namespace Rapture{

    class Program{

        


        static void Main(string[] args){
            List<RandomEvent> randomEvents = RandomInit();
            List<PlotEvent> plotEvents = PlotInit();
            List<Location> locations = LocationInit();
            

            var coach = locations.Single(location => location.Name == "Coach");
            Console.WriteLine("Welcome, player! What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"\nWelcome {name}!\n");

            Console.WriteLine("RAPTURE is a Choose-Your-Own adventure game, where you will investigate the mysterious disappearance of your fellow passengers on an airplane 30,000 feet in the air.\n");
            Player player = Player.PlayerInit(playerName: name, location: coach);
            


            player.GetPlayerState();
            Console.WriteLine(plotEvents[0].EventText);
        }

        static List<Location> LocationInit(){
            string fileName = "locations.json";
            string jsonString = File.ReadAllText(fileName);

            List<Location>locations = JsonSerializer.Deserialize<List<Location>>(jsonString);

            return locations;
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
