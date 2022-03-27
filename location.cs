
namespace Rapture{
    class Location{

        private RandomEvent[] _randomEvents;

        public RandomEvent GetRandomEvent(){
            Random random = new Random();
            int index = random.Next(0, _randomEvents.Length);
            return _randomEvents[index];
        }

        private string _name;

        public string Name{
            get{return _name;}
            private set{_name = value;}
        }

        private string _description;

        public string Description{
            get{return _description;}
            private set{_description = value;}
        }

        public Location(string name, string description){
            Name = name;
            Description = description;
            
        }

    }
}