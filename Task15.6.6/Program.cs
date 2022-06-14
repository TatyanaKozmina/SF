var classes = new[]
{
    new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
    new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
    new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
};

var allStudents = GetAllStudents(classes);

Console.WriteLine(string.Join(" ", allStudents));

static string[] GetAllStudents(Classroom[] classes)
{
    var res = classes.Select(s => s.Students.Select(s => s)).Aggregate((x, y) => x.Concat(y));
    return res.ToArray();
}

class Classroom
{
    public List<string> Students = new List<string>();
}
