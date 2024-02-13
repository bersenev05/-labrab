using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab1
{
    public class Department<T> where T : class
    {

        string Title;
        string Supervisor;
        public T[] Students = new T[0];

        public Department(string Title = "None", string Supervizor = "None")
        {
            this.Title = Title;
        }

    public void EnrollStudent(T student)
        {
            var students_new = new T[Students.Length+1];

            if (Students.Length > 0)
            {
                Students.CopyTo(students_new, 0);
            }

            students_new[students_new.Length-1] = student;
            Students = students_new;
        }

        public void ExpelStudent(T student_to_delete)
        {
            if (!Students.Contains(student_to_delete) || Students.Length == 0)
            {
                Console.WriteLine("Нечего тут удалять");
                return;
            }

            if (Students.Length == 1)
            {
                Students = new T[0];
                return;
            }

            T[] new_students = new T[Students.Length-1];

            int paste = 0;
            int index = Array.FindIndex(Students, (T person) => { return person == student_to_delete; });
            for (int i = 0; i < Students.Length; i++)
            {
                if (i != index)
                {
                    new_students[paste] = Students[i];
                    paste++;
                }
            }
            Students = new_students;
        }
        public void GetStudentsList()
        {
            Console.WriteLine(this.Title);
            Console.WriteLine("Список студентов:");
            int index = 0;
            foreach (T student in Students)
            {
                index++;
                Console.WriteLine($"{index}: {student}");
            }
            Console.WriteLine();
        }

        public void deleter(int delete)
        {
            Random rnd = new Random();

            for (int i = 0; i < delete; i++)
            {
                int rndint = rnd.Next(Students.Length);
                ExpelStudent(Students[rndint]);
            }

            Console.WriteLine( $"Отчислил {delete} человек из {this.Title}");

        }
    }
}
