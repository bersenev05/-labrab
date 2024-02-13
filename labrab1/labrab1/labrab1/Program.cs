

namespace labrab1
{
    public class Program
    {
        static List<string> names = 
            [
                "нурбол",
                "али",
                "самир",
                "ахмад",
            ];

        static List<string> profession =
            [
                "программирование",
                "востоковедение",
                "молекулярная физика",
                "филология",
            ];

        public static void Main(string[] args)
        {

            var MEDICALdepartment = new Department<MedicalStudent>(Supervizor: "Супервайзор медик", Title: "МедИнститут");
            var PEdepartment = new Department<PEStudent>(Supervizor: "Супервайзор физик", Title: "Физический Институт");
            var SESdepartment = new Department<SEStudent>(Supervizor: "Супервайзор кодер", Title: "ИКИТ");

           for(int i = 0; i<=10; i++)
            {
                var rnd = new Random();

                SEStudent student = new SEStudent();
                student.FIO = names[rnd.Next(names.Count)]+ $"{i}";
                student.ProgrammingLanguage = profession[rnd.Next(profession.Count)];
                SESdepartment.EnrollStudent(student);

                MedicalStudent student1 = new MedicalStudent();
                student1.Name = names[rnd.Next(names.Count)] + $"{i}";
                student1.Specialization = profession[rnd.Next(profession.Count)];
                MEDICALdepartment.EnrollStudent(student1);

                PEStudent student2 = new PEStudent();
                student2.FIO = names[rnd.Next(names.Count)] + $"{i}";
                student2.SportDiscipline = profession[rnd.Next(profession.Count)];
                PEdepartment.EnrollStudent(student2);
            }

            SESdepartment.GetStudentsList();
            MEDICALdepartment.GetStudentsList();
            PEdepartment.GetStudentsList();

            SESdepartment.deleter(3);
            MEDICALdepartment.deleter(5);
            PEdepartment.deleter(9);
            Console.WriteLine();

            SESdepartment.GetStudentsList();
            MEDICALdepartment.GetStudentsList();
            PEdepartment.GetStudentsList();


        }
         
    }
}