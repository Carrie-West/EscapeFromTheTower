
namespace Rapture{
    class Player{
        private string _name = "Player";
        public string Name{
            get{return _name;}
            private set{_name = value;}
        }

        public int _strength = 10;
        public int Strength{
            get{return _strength;}
            set{_strength = value;}

        }

        public int _intelligence= 10;
        public int Intelligence{
            get{return _intelligence;}
            set{_intelligence = value;}

        }

        public int _luck= 10;
        public int Luck{
            get{return _luck;}
            set{_luck = value;}

        }
        
        public int _charisma= 10;
        public int Charisma{
            get{return _charisma;}
            set{_charisma= value;}

        }

        public Location location;

        public List<Item> items = new List<Item>();

        public List<String> conditions = new List<String>();





        public Player(string name){
            Name = name;
        
        }


        public static Player PlayerInit(string playerName){
            
            Player player = new Player(name: playerName);
            Console.Write("Now lets learn some more about you. Answer honestly now, I won't know but your conscience will. \n"+
                                "If push comes to shove, I'd rather rely on brute force to solve a problem than wasting time thinking through it. (y/n)\n>");
            string playerChoice = Console.ReadLine().ToLower();
            if (playerChoice == "y"){
                player.Strength++;
            }else if (playerChoice == "n"){
                player.Intelligence++;
            }

            Console.Write("I can't really talk my way out of situations, but a good hope and a prayer seems to help my chances. (y/n)\n>");
            playerChoice = Console.ReadLine().ToLower();
            if (playerChoice == "y"){
                player.Luck++;
            }else if (playerChoice == "n"){
                player.Charisma++;
            }


            return player;
        }

        public void EventStatter(string change){
            string[] components = change.Split(" ");

            string stat = components[0];

            switch(stat){
                case "Strength":
                    this.Strength += int.Parse(components[1]);
                    break;
                case "Intelligence":
                    this.Intelligence += int.Parse(components[1]);
                    break;
                case "Charisma":
                    this.Charisma += int.Parse(components[1]);
                    break;
                case "Luck":
                    this.Luck += int.Parse(components[1]);
                    break;
                case "Blinded":
                    if (components[1] == "Added"){
                        this.conditions.Add("Blinded");
                    }else if (components[1] == "Removed"){
                        this.conditions.Remove("Blinded");
                    }
                    break;
                case "Restrained":
                    if (components[1] == "Added"){
                        this.conditions.Add("Restrained");
                        this.Strength -= 5;
                    }else if (components[1] == "Removed"){
                        this.conditions.Remove("Restrained");
                        this.Strength += 5;
                    }
                    break;
            }

        }
        
        public void Go(Location newLocation){
            if (location != null){
                location.ToggleEventPopped();
            }
            location = newLocation;
            Console.WriteLine(location.Name.ToUpper());
            Console.WriteLine("--------------------");
            Console.WriteLine(location.paintRoom());
        }

        public void LookAround(){
            Console.WriteLine(location.Description);
        }

        public void FeelAround(){
            Console.WriteLine(location.Feel);
        }

        public void Inventory(){
            Console.WriteLine($"{Name}'s Inventory");
            Console.WriteLine("---------------------");
            foreach(Item item in items){
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("---------------------");
        }

        public void Take(Item item){
            Console.WriteLine($"You pick up the {item.Name.ToUpper()}");
            items.Add(item);
            location.RemoveItem(item);
            EventStatter(item.OnPickup);
        }

         public void SilentTake(Item item){
            items.Add(item);
            location.RemoveItem(item);
            EventStatter(item.OnPickup);
        }

        public void Remove(string itemRemoval){
            Item itemRemoved = items.Single(item => item.Name.ToLower() == itemRemoval);
            EventStatter(itemRemoved.OnDrop);
            Console.WriteLine($"You remove the {itemRemoval.ToUpper()}");
            items.RemoveAll(item=> item == itemRemoved);
            
            location.AddItem(itemRemoved);
        }

        public void EventPop(RandomEvent rando){
            Console.WriteLine(rando.EventText);

            EventStatter(rando.Result);

            location.ToggleEventPopped();
        }

        public void GetPlayerState(){
            Console.WriteLine($"\n{Name}\n"+
            "---------------------\n" + 
            $"Strength: {Strength}\n" +
            $"Intelligence: {Intelligence}\n" +
            $"Luck: {Luck}\n" +
            $"Charisma: {Charisma}\n" +
            $"Conditions:"
            );
            foreach(string condition in conditions){
                Console.WriteLine(condition);
            }

        }
    }

}