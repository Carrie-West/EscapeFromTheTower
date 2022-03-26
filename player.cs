
namespace Rapture{
    class Player{
        private string name = "Player";
        public string Name{
            get{return name;}
            private set{name = value;}
     }

        public Player(string name){
            Name = name;
        
        }

        public static Player PlayerInit(){
            Console.WriteLine("Welcome, player! What is your name?");
            string playerName = Console.ReadLine();
            Player player = new Player(name: playerName);
            
            return player;
        }
    }
}