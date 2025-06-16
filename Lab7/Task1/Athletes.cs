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
    //Private fields
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public SportType Sport { get; set; }
    public Category Rank { get; set; }
    //Private fields
    private const string LastNameMsg = "Last Name: ";
    private const string BirthDateMsg = "Birth Date: ";
    private const string AgeMsg = "Age: ";
    private const string SportMsg = "Sport: ";
    private const string CategoryMsg = "Category: ";
    private const string DateFormat = "dd.mm.yyyy";
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
        bool bDayHasPassedThisYear;
        var hasBDayMonthPassedInThisYear  = today.Month > BirthDate.Month;
        var isBDayMonth = today.Month == BirthDate.Month;
        var isBDayOrPassed  = today.Day >= BirthDate.Day;
        if (hasBDayMonthPassedInThisYear || (isBDayMonth && isBDayOrPassed))
        {
            bDayHasPassedThisYear = true;
        }
        else
        {
            bDayHasPassedThisYear = false;
        }
        
        if (!bDayHasPassedThisYear)
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
        string birthDateStr = BirthDate.ToString(DateFormat);
        
        Console.WriteLine(LastNameMsg + LastName);
        Console.WriteLine(BirthDateMsg + birthDateStr);
        Console.WriteLine(AgeMsg + age);
        Console.WriteLine(SportMsg + Sport);
        Console.WriteLine(CategoryMsg + Rank + "\n");
    }
}