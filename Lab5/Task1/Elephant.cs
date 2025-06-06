﻿namespace Lab5.Task1;

class Elephant : Animal
{
    //Private fields
    private const int LivingCost = 5;
    /// <summary>
    /// Use animal constructor
    /// </summary>
    public Elephant(string name, int age) : base(name, age)
    {
    }
    /// <summary>
    /// Message and increase energy
    /// </summary>
    public override void Eat()
    {
        Console.WriteLine("Elephant eats grass!");
        IncreaseEnergy(LivingCost);
    }
}