using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models;
public class User
{
    // private static int _seed = 0;
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public int Life { get; set; }
    public int Xp { get; set; }
    public int Gold { get; set; }

    public User(int _id, string _name, string _password)
    {
        Id = _id;
        Name = _name;
        Password = _password;
        Life = 10;
        Xp = 0;
        Gold = 0;
        // IncraseSeed();
    }

    public User(string _name, string _password)
    {
        Name = _name;
        Password = _password;
        Life = 10;
        Xp = 0;
        Gold = 0;
        // IncraseSeed();
    }

    public User(){}

    // private static void IncraseSeed()
    // {
    //     _seed++;
    // }

    public override string ToString()
    {
        return $"Name: {Name},\nLife: {Life},\nXp: {Xp},\nGold: {Gold}";
    }
};