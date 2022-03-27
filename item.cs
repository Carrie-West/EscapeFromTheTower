namespace Rapture{
    class Item{
        private string _name;
        public string Name{
            get{return _name;}
            set{_name = value;}
        }

        private string _onPickup;
        public string OnPickup{
            get{return _onPickup;}
            set{_onPickup = value;}
        }

        public Item(string name, string onPickup){
            Name = name;
            OnPickup = onPickup;
        }

        

    }
}