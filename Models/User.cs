using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models;
public class User
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string Password { get; set; }
    public int Life { get; set; }
    public int Xp { get; set; }
    [NotMapped]
    public int Lvl { get; set; }
    public int Gold { get; set; }
    public bool IsAdmin { get; set; } = false!;

    public User(int _id, string _name, string _password, int lvl)
    {
        Id = _id;
        Name = _name;
        Password = _password;
        Life = 10;
        Xp = 0;
        Gold = 0;
        Lvl = lvl;
    }

    public User(string _name, string _password)
    {
        Name = _name;
        Password = _password;
        Life = 10;
        Xp = 0;
        Gold = 0;
        Lvl = 1;
    }
    public User() { }


    public override string ToString()
    {
        return $"Name: {Name},\nLife: {Life},\nXp: {Xp},\nGold: {Gold},\nLevel: {Lvl}";
    }
};