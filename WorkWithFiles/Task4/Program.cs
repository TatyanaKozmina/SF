using System.Runtime.Serialization.Formatters.Binary;

string dirStudents = @"C:\Students";
string binaryFile = string.Concat(dirStudents, @"\students.dat");
BinaryFormatter binaryFormatter = new();

try
{
    DirectoryInfo di = new(dirStudents);
    if (!di.Exists)
        di.Create();

    #region Create binary data
    Student[] students = new Student[]
    {
        new Student("Иванов", "А1", DateOfBirth()),
        new Student("Петров", "Б4", DateOfBirth()),
        new Student("Сидоренко", "Б4", DateOfBirth()),
        new Student("Асланян", "Д11", DateOfBirth()),
        new Student("Гарифулин", "А1", DateOfBirth()),
        new Student("Кандинский", "Б4", DateOfBirth()),
        new Student("Джанибеков", "Д11", DateOfBirth()),
        new Student("Кушнир", "А1", DateOfBirth()),
        new Student("Штольц", "Д11", DateOfBirth()),
    };

    using (var fs = new FileStream(binaryFile, FileMode.OpenOrCreate))
    {
        binaryFormatter.Serialize(fs, students);
    }
    #endregion Create binary data

    Student[] result;
    using (var fs = new FileStream(binaryFile, FileMode.Open))
    {
        result  = (Student[])binaryFormatter.Deserialize(fs);        
    }

    foreach (var student in result)
    {
        string fileGroupPath = string.Concat(dirStudents, @"\", student.Group, @".txt");
        
        var fileInfo = new FileInfo(fileGroupPath);
        using (StreamWriter sw = fileInfo.AppendText())
        {
            sw.WriteLine($"{student.Name}, {student.DateOfBirth:d}");
        }        
    }

    Console.WriteLine($"Работа закончена. Проверьте папку {dirStudents}");
    Console.ReadLine();    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

static DateTime DateOfBirth()
{
    var rand = new Random();
    return new DateTime(rand.Next(1990, 2007), rand.Next(1, 13), rand.Next(1, 28));
}

[Serializable]
class Student
{
    public string Name;
    public string Group;
    public DateTime DateOfBirth; 

    public Student(string name, string group, DateTime dateOfBirth)
    {
        Name = name;
        Group = group;
        DateOfBirth = dateOfBirth;
    }
}

[Serializable]
class Students
{
    public Student[] Data;
    public Students(Student[] students)
    {
        Data = students;
    }
}
