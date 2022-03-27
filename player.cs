
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



        public Player(string name, Location location){
            Name = name;
            location = location;
        
        }

        public void GetPlayerState(){
            Console.WriteLine($"{Name}\n"+
            "---------------------\n" + 
            $"Strength: {Strength}\n" +
            $"Intelligence: {Intelligence}\n" +
            $"Luck: {Luck}\n" +
            $"Charisma: {Charisma}\n"
            );

        }
        public static Player PlayerInit(string playerName, Location location){
            
            Player player = new Player(name: playerName, location: location);
            Console.WriteLine("Now lets learn some more about you. Answer honestly now, I won't know but your conscience will. \n"+
                                "If push comes to shove, I'd rather rely on brute force to solve a problem than wasting time thinking through it. (y/n)");
            string playerChoice = Console.ReadLine().ToLower();
            if (playerChoice == "y"){
                player.Strength++;
            }else if (playerChoice == "n"){
                player.Intelligence++;
            }

            Console.WriteLine("I can't really talk my way out of situations, but a good hope and a prayer seems to help my chances. (y/n)");
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

            }

        }
    }

}