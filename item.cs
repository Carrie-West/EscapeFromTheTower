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

        private string _defaultLocation;
        public string DefaultLocation{
            get{return _defaultLocation;}
            set{_defaultLocation = value;}
        }

        private string _description;
        public string Description{
            get{return _description;}
            set{_description = value;}
        }

        public Item(string name, string onPickup){
            Name = name;
            OnPickup = onPickup;
        }

        

    }
}