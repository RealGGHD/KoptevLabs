using System.Runtime.InteropServices.Swift;

namespace Lab7.Task1;

public enum SportType
{
    Athletics, 
    Boxing, 
    Swimming, 
    Acrobatics
}

public enum Category
{
    Youth_I,
    Youth_II,
    Youth_III,
    Adult_I,
    Adult_II,
    Adult_III
}

public struct Athletes
{
    //Fields
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public SportType Sport { get; set; }
    public Category Rank { get; set; }
    /// <summary>
    /// Constructor for this struct
    /// </summary>
    public Athletes(string lastName, DateTime birthDate, SportType sport, Category rank)
    {
        LastName = lastName;
        BirthDate = birthDate;
        Sport = sport;
        Rank = rank;
    }
    /// <summary>
    /// Get age based on different between date of birth and today data
    /// </summary>
    public int GetAge()
    {
        DateTime today = DateTime.Today;
        int age = today.Year - BirthDate.Year;
        bool birthdayHasPassedThisYear =
            (today.Month > BirthDate.Month) ||
            (today.Month == BirthDate.Month && today.Day >= BirthDate.Day);
        if (!birthdayHasPassedThisYear)
        {
            age--;
        }
        return age;
    }
    /// <summary>
    /// Print any information about specific athlete
    /// </summary>
    public void PrintInfo()
    {
        int age = GetAge();
        Console.WriteLine("Last Name: " + LastName);
        Console.WriteLine("Birth Date: " + BirthDate.ToString("dd.mm.yyyy"));
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Sport: " + Sport);
        Console.WriteLine("Category: " + Rank + "\n");
    }
}