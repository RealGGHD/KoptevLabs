namespace Lab8.Task1;

public class MenuAction
{
    //Private fields
    private const int FirstOption = 1;
    private const int SecondOption = 2;
    private const string ErrorInputMsg = "Error: Invalid input!";
    private const string MenuMsg = "Rename Faculty Name (1) or Award Excellent Student (2)\nWhat would you like to do: ";
    private const string FacultyRenameMsg = "Enter faculty name to rename: ";
    private const string FacultyNewMsg = "Enter new faculty name: ";
    private const string AwardFacultyMsg = "Enter faculty name to award excellent students: ";
    private const string BonusMsg = "Enter bonus amount: ";
    /// <summary>
    /// Menu to rename faculty or award excellent students
    /// </summary>
    public void Print(List<Faculty> faculties, List<Student> students)
    {
        string optionStr = Input(MenuMsg);
        int optionInt = Convert.ToInt32(optionStr); 
        if (optionInt == FirstOption)
        {
            RenameFaculty(faculties);
        }
        else if (optionInt == SecondOption)
        {
            AwardStudent(faculties);
        }
        else
        {
            throw new Exception(ErrorInputMsg);
        }
    }
    /// <summary>
    /// Rename faculty for all students
    /// </summary>
    void RenameFaculty(List<Faculty> faculties)
    {
        string oldFacultyName = Input(FacultyRenameMsg);
        var facultyToRename = faculties.FirstOrDefault(f => f.Name == oldFacultyName);
        if (facultyToRename != null)
        {
            string newFacultyName = Input(FacultyNewMsg);
            facultyToRename.ChangeFacultyName(newFacultyName);
        }
        else
        {
            throw new Exception(ErrorInputMsg);
        }
    }
    /// <summary>
    /// Award excellent students
    /// </summary>
    void AwardStudent(List<Faculty> faculties)
    {
        string facultyForAward = Input(AwardFacultyMsg);
        var facultyToAward = faculties.FirstOrDefault(f => f.Name == facultyForAward);
        if (facultyToAward != null)
        {
            string bonusStr = Input(BonusMsg);
            decimal bonusDec = decimal.Parse(bonusStr);
            facultyToAward.AwardExcellentStudents(bonusDec);
        }
        else
        {
            throw new Exception(ErrorInputMsg);
        }
    }
    /// <summary>
    /// Input and verification
    /// </summary>
    string Input(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();
        bool isNull = string.IsNullOrWhiteSpace(input);
        if (isNull)
        {
            throw new Exception(ErrorInputMsg);
        }
        return input;
    }
}