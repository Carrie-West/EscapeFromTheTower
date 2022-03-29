
namespace Rapture{
    class Location{

        private RandomEvent[] _randomEvents;

        public RandomEvent GetRandomEvent(){
            Random random = new Random();
            int index = random.Next(0, _randomEvents.Length);
            return _randomEvents[index];
        }

        private List<Item> _items = new List<Item>();

        public List<Item> Items{
            get{return _items;}
            set{_items = value;}
        }

        public void RemoveItem(Item itemRemovable){
            _items.RemoveAll(item => item.Name == itemRemovable.Name);
        }

        public void AddItem(Item itemAdded){
            _items.Add(itemAdded);
        }


        private bool _eventPopped = false;

        public bool EventPopped{
            get{return _eventPopped;}
            private set{_eventPopped = value;}
        }

        public void ToggleEventPopped(){
            EventPopped = !EventPopped;
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

        public string paintRoom(){
            string response = Description;
            foreach (Item item in Items){
                response = response + " " + item.Description;
            }
            return response;
        }

        public Location(string name, string description){
            Name = name;
            Description = description;
            EventPopped = false;
        }

    }
}