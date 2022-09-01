using System;
using System.Text.Json;
using System.Linq;

namespace Rapture{

    class Program{

        


        static void Main(string[] args){
            Console.Clear();
            string title = @"         
             ______  _____  _____          _____  ______   ______ _____   ____  __  __   _______ _    _ ______   _______ ______          ________ _____  
            |  ____|/ ____|/ ____|   /\   |  __ \|  ____| |  ____|  __ \ / __ \|  \/  | |__   __| |  | |  ____| |__   __/ __ \ \        / /  ____|  __ \ 
            | |__  | (___ | |       /  \  | |__) | |__    | |__  | |__) | |  | | \  / |    | |  | |__| | |__       | | | |  | \ \  /\  / /| |__  | |__) |
            |  __|  \___ \| |      / /\ \ |  ___/|  __|   |  __| |  _  /| |  | | |\/| |    | |  |  __  |  __|      | | | |  | |\ \/  \/ / |  __| |  _  / 
            | |____ ____) | |____ / ____ \| |    | |____  | |    | | \ \| |__| | |  | |    | |  | |  | | |____     | | | |__| | \  /\  /  | |____| | \ \ 
            |______|_____/ \_____/_/    \_\_|    |______| |_|    |_|  \_\\____/|_|  |_|    |_|  |_|  |_|______|    |_|  \____/   \/  \/   |______|_|  \_\
                                                                                                                                              
                                                                                                                                              
      
      ";


            Console.WriteLine(title);
            List<RandomEvent> randomEvents = RandomInit();
            List<PlotEvent> plotEvents = PlotInit();
            List<Location> locations = LocationInit();
            List<Item> items = ItemInit();

            foreach (Location location in locations){
                location.Items = items.Where(item => item.DefaultLocation == location.Name).ToList();
                
            }

            
            Console.WriteLine("Welcome, player! What is your name?");
            Console.Write(">");
            string name = Console.ReadLine();
            Console.WriteLine($"\nWelcome {name}!\n");

            Console.WriteLine("ESCAPE FROM THE TOWER is a Choose-Your-Own adventure game, where you will have to use your wits and skills to get through a dangerous descent to freedom.\n");
            Player player = Player.PlayerInit(playerName: name);
            


            player.GetPlayerState();

            TriggerPlotEvent(plotEvents);

            
            var top = locations.Single(location => location.Name == "Top Floor");
            player.location = top;
            player.SilentTake(items.Single(item => item.Name.ToLower() == "blindfold"));
            player.SilentTake(items.Single(item => item.Name.ToLower() == "cuffs"));
            

            //while true only for testing purposes
            while (true){
                Console.Write("\n>");
                HandleCommand(Console.ReadLine(), player, items, locations, randomEvents);
            }

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

        static List<PlotEvent> TriggerPlotEvent(List<PlotEvent> plot){
            PlotEvent development = plot[0];

            Console.Write(development.EventText + "\n");

            plot.RemoveAt(0);

            return plot;

        }
    
        static void HandleCommand(string command, Player player, List<Item> items, List<Location> locations, List<RandomEvent> randomEvents){
            string[] components = command.Split(" ");

            switch(components[0].ToLower()){
                case "take":
                    string itemName = components[1].ToLower();
                    if (player.location.Items.Any(item => item.Name.ToLower() == itemName)){
                        player.Take(items.Single(item => item.Name.ToLower() == itemName));
                    }else{
                        Console.WriteLine("Sorry, I don't see that anywhere around here.");
                    }
                    break;
                case "roll":

                    if (player.location.EventPopped == false){
                        var random = new Random();
                        List<RandomEvent> rando = randomEvents.Where(rando => rando.Luck < player.Luck).ToList();

                        player.EventPop(rando[random.Next(rando.Count)]);
                    }else{
                        Console.WriteLine("Sorry, looks like you've run this place dry. At least while you're here looking.");
                    }

                    break;
                case "remove":
                    itemName = components[1].ToLower();
                    if (player.items.Any(item => item.Name.ToLower() == itemName)){
                        player.Remove(itemName);
                    }else{
                        Console.WriteLine("Sorry, I don't see you holding that.");
                    }
                    break;
                case "go":
                    string locationName = components[1].ToLower();
                    if (locations.Any(location => location.Name.ToLower() == locationName) && locationName != player.location.Name.ToLower()){
                        player.Go(locations.Single(location => location.Name.ToLower() == locationName));
                    }else{
                        Console.WriteLine("Sorry, can't go there.");
                    }
                    break;
                case "look":
                    if (player.conditions.Contains("Blinded") == true){
                        Console.WriteLine("You can't. You can try to FEEL AROUND though, I guess.");
                    }else{
                        player.LookAround();
                    }
                    break;
                case "feel":
                    if (player.conditions.Contains("Restrained") == true){
                        Console.WriteLine("You are currently restrained.");
                    }else{
                        player.FeelAround();
                    }
                    break;
                case "stats":
                    player.GetPlayerState();
                    break;
                case "inventory":
                    player.Inventory();
                    break;
                case "help":
                    Console.Write("      COMMANDS\n"+
                    "--------------------\n"+
                    "take (item) - grab an item\n"+
                    "drop (item) - leave an item\n"+
                    "inventory - print out your current inventory\n"+
                    "go (location) - move to a different area\n"+
                    "roll - trigger a random event (once per room)\n"+
                    "stats - print out your stats");
                    break;
                default:
                    Console.WriteLine("I don't quite understand what you're getting at. Try HELP for command options.");
                    break;
            }
        }

    }

}
