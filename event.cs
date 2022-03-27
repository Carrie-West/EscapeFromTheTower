interface Event{
    string EventText{
        get;
        set;
    }
}

class PlotEvent : Event{

    private string _name;

    public string Name{
        get{return _name;}
        private set{_name = value;}

    }
    public string EventText{
        get;
        set;
    }

    public PlotEvent(string eventText, string name){
        EventText = eventText;
        Name = name;

    }
}

class RandomEvent : Event{
    private string _result;

    public string EventText{
        get;
        set;
    }

    public string Result{
        get{return _result;}
        set{_result = value;}

    }

    public RandomEvent(string eventText, string result){
        EventText = eventText;
        Result = result;
    }
}