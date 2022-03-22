using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DZ_LINQ_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;

            Console.WriteLine("Это регистратура.");

            List<Patient> patients = new List<Patient> { new Patient("Иванов Иван", 58, "ОРЗ"), new Patient("Петрович Петр", 77, "Грипп"),
            new Patient("Алексеевский Алексей", 21, "ОРЗ"), new Patient("Пирожков Артур", 50 , "Грипп"), new Patient("Дабудаев Дабуди", 11, "Грипп"),
            new Patient("Экстровертов Интроверт", 15, "Грипп"), new Patient("Балансова Кардан", 27, "ОРЗ"), new Patient("Потеков Шрус", 43, "ОРЗ"),
            new Patient("Салават Юлаев", 28, "Перелом"), new Patient("Кривожопов Олень", 25, "Перелом")};

            while (isWork)
            {
                Console.WriteLine("Для сортировки больных по ФИО введите 1");
                Console.WriteLine("Для сортировки больных по возрасту введите 2");
                Console.WriteLine("Для сортировки больных по заболеванию введите 3");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SorteredName(patients);
                        break;
                    case "2":
                        SorteredAge(patients);
                        break;
                    case "3":
                        SorteredDisease(patients);
                        break;
                }
            }
        }

        static void SorteredName(List<Patient> patients)
        {
            Console.Clear();

            var sorteredNamePatients = patients.OrderBy(patient => patient.Name).ToList();

            ShowSorteredPatients(sorteredNamePatients);
        }

        static void SorteredAge(List<Patient> patients)
        {
            Console.Clear();

            var sorteredAgePatients = patients.OrderBy(patient => patient.Age).ToList();

            ShowSorteredPatients(sorteredAgePatients);
        }

        static void SorteredDisease(List<Patient> patients)
        {
            Console.Clear();
            Console.WriteLine("Введите заболевание: ");

            string userInputDisease = Console.ReadLine();
            var filteredDiseasePatients = patients.Where(patient => patient.Disease == userInputDisease).OrderBy(patient => patient.Disease).ToList();
            
            ShowSorteredPatients(filteredDiseasePatients);
        }

        static void ShowSorteredPatients(List<Patient> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine(patient.Name + " " + patient.Age + " " + patient.Disease);
            }
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Patient
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Disease { get; private set; }

        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }
    }
}
