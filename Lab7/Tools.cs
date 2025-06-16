namespace Lab7;
using Task1;

class Tools
{
    //Fields
    private const string AthletesFile = "input";
    /// <summary>
    /// Main method
    /// </summary>
    static void Main()
    {
        FileAction File = new FileAction();
        MenuAction Menu = new MenuAction();
        
        string[] lines = File.GetData(AthletesFile);
        
        List<Athletes> athletesArray = new List<Athletes>();
        
        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            string lastName = parts[0];
            string dateOfBirth = parts[1];
            string sportName = parts[2];
            string rankName = parts[3];
            DateTime birthDate = DateTime.Parse(dateOfBirth);
            SportType sport = Enum.Parse<SportType>(sportName);
            Category rank = Enum.Parse<Category>(rankName);
            
            Athletes athlete = new Athletes(lastName, birthDate, sport, rank);
            athletesArray.Add(athlete);
        }
        
        File.WriteAthletesByCategory(athletesArray);
        
        while (true)
        {
            Menu.Print(athletesArray);
        }
    }
}