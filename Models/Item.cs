namespace ToDoApp.Models;

public class Item{

    public int Id { get; set; }
    public string Type { get; set; }
    public int Stats { get; set; }
    public int Value { get; set; }

    public Item(){
    }

    public Item(int id, string type, int stats, int value){
        Id = id;
        Type = type;
        Stats = stats;
        Value = value; 
    }

    public Item(string type, int stats, int value){
        Type = type;
        Stats = stats;
        Value = value; 
    }

}