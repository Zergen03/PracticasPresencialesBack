namespace ToDoApp.Models;

public class Items{

    public int Id { get; set; }
    public string TypeObject { get; set; }
    public int StatsObject { get; set; }
    public int ValueObject { get; set; }

    public Items(int id, string type, int stats, int value){
        Id = id;
        TypeObject = type;
        StatsObject = stats;
        ValueObject = value; 
    }

    public Items(string type, int stats, int value){
        TypeObject = type;
        StatsObject = stats;
        ValueObject = value; 
    }

    public Items(){}
}