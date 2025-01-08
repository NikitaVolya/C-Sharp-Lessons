using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3:
//Реалізуйте тип користувача «Студент» з інформацією про ім'я,
//прізвище, вік, назву навчального закладу.
//Для масиву «Студент» реалізуйте наступні запити:
// Отримати весь масив студентів.
// Отримати список студентів з ім'ям Boris.
// Отримати список студентів з прізвищем, яке починається з
//Bro.
// Отримати список студентів, старших 19 років.
// Отримати список студентів, старших 20 років і молодших 23
//років.
// Отримати список студентів, які навчаються в MIT.
// Отримати список студентів, які навчаються в Oxford, і вік
//яких старше 18 років. Результат відсортуйте за віком, за
//спаданням.

namespace Exercice3
{
    class Student
    {
        public string Name { set; get; }
        public string LastName { set; get; }
        public int Age { set; get; }
        public string EducationalInstitution { set; get; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]
             {
                new Student
                {
                    Name = "John",
                    LastName = "Smith",
                    Age = 20,
                    EducationalInstitution = "MIT"
                },
                new Student
                {
                    Name = "Emily",
                    LastName = "Bro",
                    Age = 22,
                    EducationalInstitution = "Oxford"
                },
                new Student
                {
                    Name = "Michael",
                    LastName = "Brown",
                    Age = 19,
                    EducationalInstitution = "Stanford University"
                },
                new Student
                {
                    Name = "Sophia",
                    LastName = "Taylor",
                    Age = 21,
                    EducationalInstitution = "MIT"
                },
                new Student
                {
                    Name = "James",
                    LastName = "Wilson",
                    Age = 21,
                    EducationalInstitution = "Oxford"
                },
                new Student
                {
                    Name = "Olivia",
                    LastName = "Davis",
                    Age = 18,
                    EducationalInstitution = "Oxford"
                },
                new Student
                {
                    Name = "Boris",
                    LastName = "Bronson",
                    Age = 24,
                    EducationalInstitution = "California Institute of Technology"
                },
                new Student
                {
                    Name = "Lily",
                    LastName = "Anderson",
                    Age = 21,
                    EducationalInstitution = "Harvard University"
                }
             };


            var all_students = from s in students
                               select s;
            foreach (var student in all_students)
                Console.WriteLine($"Name: {student.LastName} {student.Name}, Age: {student.Age}, Institution: {student.EducationalInstitution}");
            Console.WriteLine();


            var students_boris = from s in students
                                 where s.Name == "Boris"
                                 select s;
            foreach (var student in students_boris)
                Console.WriteLine($"Name: {student.LastName} {student.Name}, Age: {student.Age}, Institution: {student.EducationalInstitution}");
            Console.WriteLine();

            var students_lastname_boris = from s in students
                                 where s.LastName == "Boris"
                                 select s;
            foreach (var student in students_boris)
                Console.WriteLine($"Name: {student.LastName} {student.Name}, Age: {student.Age}, Institution: {student.EducationalInstitution}");
            Console.WriteLine();


            var students_lastname_bro = from s in students
                                          where s.LastName.StartsWith("Bro")
                                          select s;
            foreach (var student in students_lastname_bro)
                Console.WriteLine($"Name: {student.LastName} {student.Name}, Age: {student.Age}, Institution: {student.EducationalInstitution}");
            Console.WriteLine();


            var older_18 = from s in students
                           where s.Age > 19
                           select s;
            foreach (var student in older_18)
                Console.WriteLine($"Name: {student.LastName} {student.Name}, Age: {student.Age}, Institution: {student.EducationalInstitution}");
            Console.WriteLine();


            var older_20_not_23 = from s in students
                           where s.Age > 20 && s.Age < 23
                           select s;
            foreach (var student in older_20_not_23)
                Console.WriteLine($"Name: {student.LastName} {student.Name}, Age: {student.Age}, Institution: {student.EducationalInstitution}");
            Console.WriteLine();


            var student_in_mit = from s in students
                                 where s.EducationalInstitution == "MIT"
                                 select s;
            foreach (var student in student_in_mit)
                Console.WriteLine($"Name: {student.LastName} {student.Name}, Age: {student.Age}, Institution: {student.EducationalInstitution}");
            Console.WriteLine();


            var stuent_in_oxford_older18 = from s in students.OrderByDescending(s => s.Age)
                                           where s.EducationalInstitution == "Oxford" && s.Age > 18
                                           select s;
            foreach (var student in stuent_in_oxford_older18)
                Console.WriteLine($"Name: {student.LastName} {student.Name}, Age: {student.Age}, Institution: {student.EducationalInstitution}");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
