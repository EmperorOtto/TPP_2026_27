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
    public override string ToString()
    {
        return $"*{Name}: {Hp} HP.*\n";
    }
    public void TakeDamage(int damage)
    {
        if (this.hp < damage)
        {
            this.hp = 0;
        }else{this.hp -= damage;}
        

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
        List<Character> entities = new List<Character>();
        System.Console.Write("Имя игрока: ");
        string nameOfPlayer = Console.ReadLine();
        while(nameOfPlayer=="")
        {
            System.Console.Write("Имя пустое, введите имя еще раз: ");
            nameOfPlayer = Console.ReadLine();
        }
        Character Igrok = new Player(nameOfPlayer, 100, 15);
        Character Scherbina = new Enemy("Scherbina", 100, 5);
        entities.Add(Igrok,Scherbina);
        Character.HowMany();
        System.Console.WriteLine("\nБой начинается!\n");
        while(Igrok.IsAlive() && Scherbina.IsAlive()) {
            Igrok.Attack(Scherbina);
            System.Console.WriteLine(Scherbina.ToString());
            if(Scherbina.IsAlive())
            {
                Scherbina.Attack(Igrok);
            }else {break;}
            System.Console.WriteLine(Igrok.ToString());
            }
                if (Igrok.IsAlive())
            {
                System.Console.WriteLine($"Игрок {nameOfPlayer} победил! Щербина вынужден простить долги");
            }else{System.Console.WriteLine($"Игрок {nameOfPlayer} повержен, + 10 долгов");} 
    }
} 