namespace Lab8.Task1;

public class FileAction
{
    //Private fields
    private const int MinPartsFaculty = 3;
    private const int MinPartsStudent = 4;
    /// <summary>
    /// Read faculties from txt file
    /// </summary>
    public List<Faculty> ReadFaculties(string filename)
    {
        var faculties = new List<Faculty>();
        string path = GetPath(filename);
        string[] lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length >= MinPartsFaculty)
            {
                string name = parts[0].Trim();
                string deanLastName = parts[1].Trim();
                string deanPhone = parts[2].Trim();
                Faculty newFaculty = new Faculty(name, deanLastName, deanPhone);
                faculties.Add(newFaculty);
            }
        }
        return faculties;
    }
    /// <summary>
    /// Read students from txt file
    /// </summary>
    public List<Student> ReadStudents(string filename)
    {
        var students = new List<Student>();
        string path = GetPath(filename);
        string[] lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length >= MinPartsStudent)
            {
                string lastName = parts[0].Trim();
                string facultyName = parts[1].Trim();
                var grades = parts[2].Split(' ', StringSplitOptions.RemoveEmptyEntries); //Remove empty gaps for each element
                var gradesInt = grades.Select(int.Parse);
                List<int> gradesList = gradesInt.ToList();
                decimal scholarship = decimal.Parse(parts[3].Trim());
                students.Add(new Student(lastName, facultyName, gradesList, scholarship));
            }
        }
        return students;
    }
    /// <summary>
    /// Get path of input file located relative to Tools.cs directory
    /// </summary>
    string GetPath(string fileName)
    {
        string basePath = AppContext.BaseDirectory;
        string projectDir = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
        string filePath = $"{fileName}.txt";
        return Path.Combine(projectDir, filePath);
    }
}