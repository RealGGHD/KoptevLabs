namespace Lab9.Task1;

public class FileAction
{
    //Private fields
    private const int MinimalParts = 3;
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
            if (parts.Length >= MinimalParts)
            {
                string lastName = parts[0].Trim();
                var grades = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var gradesInt = grades.Select(int.Parse);
                List<int> gradesList = gradesInt.ToList();
                decimal scholarship = decimal.Parse(parts[2].Trim());
                students.Add(new Student(lastName, gradesList, scholarship));
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