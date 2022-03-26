
namespace Rapture{
    class Player{
        private string name = "Player";
        public string Name{
            get{return name;}
            private set{name = value;}
        }

        public int strength = 10;
        public int Strength{
            get{return strength;}
            set{strength = value;}

        }

        public int intelligence= 10;
        public int Intelligence{
            get{return intelligence;}
            set{intelligence = value;}

        }

        public int luck= 10;
        public int Luck{
            get{return luck;}
            set{luck = value;}

        }
        
        public int charisma= 10;
        public int Charisma{
            get{return charisma;}
            set{charisma= value;}

        }



        public Player(string name){
            Name = name;
        
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
        public static Player PlayerInit(){
            Console.WriteLine("Welcome, player! What is your name?");
            string playerName = Console.ReadLine();
            Player player = new Player(name: playerName);
            Console.WriteLine("Now lets learn some more about you. Answer honestly now, I won't know but your conscience will. \n"+
                                "If push comes to shove, I'd rather rely on brute force to solve a problem than wasting time thinking through it. (y/n)");
            string playerChoice = Console.ReadLine().ToLower();

            if (playerChoice == "y"){
                player.Strength++;
            }else if (playerChoice == "n"){
                player.Intelligence++;
            }

            player.GetPlayerState();

            return player;
        }
    }
}