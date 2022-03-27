interface Event{
    string EventText{
        get;
        set;
    }
}

class PlotEvent : Event{


    public string EventText{
        get;
        set;
    }

    public PlotEvent(string eventText){
        EventText = eventText;

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