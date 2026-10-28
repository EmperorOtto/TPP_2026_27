using System;
using System.Runtime;
using System.Security.Cryptography;
class Character
{
    string name;
    int hp;
    int power;

    private static int count;
    public static int HowMany()
    {
        System.Console.WriteLine($"Созданных персонажей: {count}");
        return count;
    }
    public static bool isValidStats(int hp, int power)
    {
        return hp > 0 && power > 0;
    }

    public string Name
    {
        get {return name;}
        set {name = value;}
    }
    public int Hp
    {
        get{return hp;}
    }
    public int Power
    {
        get{return power;}
    }
    public Character(string name, int hp, int power)
    {
        count++;
        this.name = name;
        this.hp = hp;
        this.power = power;
    }
    public virtual void Attack(Character target)
    {
        target.TakeDamage(power);
        System.Console.WriteLine($"{name} наносит {power} ед. урона {target.name}\n");
    }
    public void GetStatus()
    {
        System.Console.WriteLine($"*Имя персонажа: {name} \n*Здоровье персонажа: {hp}hp\n");
    }
    public void TakeDamage(int damage)
    {
        this.hp -= damage;
    }
    public bool IsAlive()
    {
        if(hp>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
class Player : Character
{
    public Player(string name, int hp, int power):base(name, hp, power)
    {
    }
    public override void Attack(Character target)
    {
        target.TakeDamage(Power);
        System.Console.WriteLine($"Игрок наносит {Power} ед. урона {target.Name}\n");
    }
}
class Enemy : Character
{
    public Enemy(string name, int hp, int power):base(name, hp, power)
    {
    }
    
    public override void Attack(Character target)
    {
        target.TakeDamage(Power);
        System.Console.WriteLine($"Противник {Name} наносит {Power} ед. урона игроку\n");
    }
}
internal class Program 
{
    static void Main()
    {
    Character Igrok = new Player("fijoahfkha", 100, 15);
    Character Scherbina = new Enemy("Scherbina", 100, 5);
    Character.HowMany();
    while(Igrok.IsAlive() && Scherbina.IsAlive()) {
        Igrok.Attack(Scherbina);
        Scherbina.GetStatus();
        if(Scherbina.IsAlive())
        {
            Scherbina.Attack(Igrok);
        }else {break;}
        Igrok.GetStatus();
    }
        if (Igrok.IsAlive())
        {
            System.Console.WriteLine("Игрок победил! Щербина вынужден простить долги");
        }else{System.Console.WriteLine("Игрок повержен, + 10 долгов");} 
    }
    
} 