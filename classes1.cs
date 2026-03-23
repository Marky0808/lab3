namespace Lab3;
using System.IO;
using System.Text.Json;


// 3. Студент. Університет зберігає інформацію про студентів:
// унікальний студентський номер, ім’я та середній бал.
// Номер після створення змінювати не можна. Потрібно також знати кількість створених студентів.
// Створіть клас Student з прихованими полями (private). Студентський номер має бути незмінним (readonly).
// Для підрахунку студентів використайте спільне поле (static).
// Передбачте створення студента з початковим балом і без нього (бал = 0).
// Реалізуйте метод для підвищення середнього балу (бал не може перевищувати 100) та метод перевірки,
// чи студент отримує стипендію (бал ≥ 90). Середній бал отримувати через властивість тільки для читання (property get).
// Додайте статичний метод для отримання кількості студентів (static method) і перевизначте ToString() (override).
// У Main() створіть кілька студентів і протестуйте логіку.
public class Student
{
    private readonly int studentId;
    private string name;
    private double averageGrade;

    public static int studentCount = 0;
    
    public Student(int id, string name, double grade)
    {
        this.studentId = id;
        this.name = name;
        this.averageGrade = Math.Min(grade, 100);
        studentCount++;
    }
    
    public Student(int id, string name)
    {
        this.studentId = id;
        this.name = name;
        this.averageGrade = 0;
        studentCount++;
    }
    
    public double AverageGrade
    {
        get { return averageGrade; }
    }
    
    public void IncreaseGrade(double value)
    {
        if (value > 0)
        {
            averageGrade += value;
            if (averageGrade > 100)
                averageGrade = 100;
        }
    }
    
    public bool HasScholarship()
    {
        return averageGrade >= 90;
    }
    
    public static int GetStudentCount()
    {
        return studentCount;
    }
    
    public override string ToString()
    {
        return $"ID: {studentId}, Name: {name}, Average: {averageGrade}";
    }
    
    private class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
    }
    
    public void SaveToJson(string filePath)
    {
        StudentDTO dto = new StudentDTO
        {
            Id = this.studentId,
            Name = this.name,
            Grade = this.averageGrade
        };
        
        string json = JsonSerializer.Serialize(dto, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }
    
    public static Student LoadFromJson(string filePath)
    {
        string json = File.ReadAllText(filePath);
        StudentDTO dto = JsonSerializer.Deserialize<StudentDTO>(json);

        return new Student(dto.Id, dto.Name, dto.Grade);
    }
}

    class Program
    {
        static void Main()
        {
            Student s1 = new Student(1, "John", 85);
            
            string path = "student.json";
            s1.SaveToJson(path);

            Console.WriteLine("Студент збережений у файл.");
        
            Student loadedStudent = Student.LoadFromJson(path);

            Console.WriteLine("Завантажений студент:");
            Console.WriteLine(loadedStudent);
            
            loadedStudent.IncreaseGrade(5);
            Console.WriteLine("Після підвищення балу:");
            Console.WriteLine(loadedStudent);
            Console.WriteLine($"Стипендія: {loadedStudent.HasScholarship()}");
            
            Console.WriteLine($"Загальна кількість студентів: {Student.GetStudentCount()}");
        }
    }
    