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
        
}

    class Program
    {
        static void Main()
        {
            Student s1 = new Student(1, "John", 85);
            Student s2 = new Student(2, "Jane");
            Student s3 = new Student(3, "Patrick", 95);
            
            s1.IncreaseGrade(10);
            s2.IncreaseGrade(92);
        
            Console.WriteLine(s1);
            Console.WriteLine($"Стипендія: {s1.HasScholarship()}");
            
            Console.WriteLine(s2);
            Console.WriteLine($"Стипендія: {s2.HasScholarship()}");

            Console.WriteLine(s3);
            Console.WriteLine($"Стипендія: {s3.HasScholarship()}");
            
            Console.WriteLine($"Загальна кількість студентів: {Student.GetStudentCount()}");
        }
    }
    