namespace Lab3;


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
    private readonly int studentID;
    private string name;
    private double avarageGrade;

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

    class Program
    {
        static void Main()
        {
            Student s1 = new Student(1, "John", "85");
            Student s2 = new Student(2, "Jane");
            Student s3 = new Student(3, "Patrick", "95");
        }
    }
    
}