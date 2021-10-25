using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;



namespace _09_10_2021
{
    public class Hospital
    {
        public static bool isWillHeal(Grandmother grandmother, Hospital hospital)
        {

            for (int i = 0; i < grandmother.GetDiseases(grandmother).Count; i++)
            {
                for (int j = 0; j < hospital._diseasesHeal.Count; j++)
                {
                    if (grandmother.GetDiseases(grandmother)[i] == hospital._diseasesHeal[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Hospital(int capasity, List<string> diseasesHeal)
        {
            _capasity = capasity;
            _diseasesHeal = diseasesHeal;
        }

        private int _capasity;
        private List<string> _diseasesHeal = new List<string>();
    }
    public class Grandmother
    {
        public List<string> GetDiseases(Grandmother grandmother)
        {
            return grandmother._diseases;
        }
        public Grandmother(List<string> diseases, string name, byte age)
        {
            _age = age;
            _name = name;
            _diseases = diseases;
        }
        private List<string> _diseases = new List<string>();
        private string _name;
        private byte _age;
    }
    public struct Student
    {
        public string name;
        public string surname;
        public int year;
        public string exam;
        public int mark;
    }
    public class Worker
    {
        public static bool IsStupid(Worker worker)
        {
            return worker._isStupid;
        }
        public static ushort GetDegree(Worker worker)
        {
            return worker._degreeImpudence;
        }
        public Worker(string name, string direction, ushort degreeImpudence, bool isStupid)
        {
            _name = name;
            _direction = direction;
            _degreeImpudence = degreeImpudence;
            _isStupid = isStupid;
        }
        private string _name;
        private string _direction;
        private ushort _degreeImpudence;
        private bool _isStupid;
    class Program
    {
        static string game(int[] team1, int[] team2)
        {
            int count1 = 0;
            int count2 = 0;
            for (int n = 0; n < team1.Length; n++)
            {
                if (team1[n] == 5)
                {
                    count1 += 1;
                }
            }
            for (int n = 0; n < team2.Length; n++)
            {
                if (team2[n] == 5)
                {
                    count2 += 1;
                }
            }
            if (count1 == count2)
            {
                return "Drinks All Round! Free Beers on Bjorg!";
            }
            else
            {
                return "Ой, Бьорг - пончик! Ни для кого пива!";
            }
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Домашнее задание 1");
            int n;
            Console.WriteLine("Введите количество человек в команде");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число n");
            }
            int[] team1 = new int[n];
            int[] team2 = new int[n];
            Random rand = new Random();
            Console.WriteLine("Bavarian Beer Bears");
            for (int i=0; i<n; i++)
            {
                team1[i]= rand.Next(0,9);
                Console.WriteLine($"{i+1}- {team1[i]}");   
            }
            Console.WriteLine("Bavarian Beer Bears");
            for (int i = 0; i < n; i++)
            {
                team2[i] = rand.Next(0, 9);
                Console.WriteLine($"{i+1}- {team2[i]}");
            }
            string answer=game(team1 ,team2);
            Console.WriteLine(answer);
            
         
            Console.WriteLine("Задание 2");

            var listImage = new List<string/*Image*/>();
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Индира\source\repos\lesson09_10_2021\09_10_2021\bin\Debug");

            foreach (var file in dir.EnumerateFiles("*.jpg"))
            {
                listImage.Add(/*Image.FromFile*/(file.FullName));

            }
            foreach (var file in dir.EnumerateFiles("*.jpg"))
            {
                listImage.Add(/*Image.FromFile*/(file.FullName));

            }
            foreach (var file in dir.EnumerateFiles("*.jpg"))
            {
                Console.WriteLine(file.FullName);

            }
            foreach (var file in dir.EnumerateFiles("*.jpg"))
            {
                Console.WriteLine(file.FullName);

            }
            for (int i = 0; i < listImage.Count; i++)
            {
                var temp = listImage[i];
                int swapIndex = rand.Next(0, listImage.Count);
                listImage[i] = listImage[swapIndex];
                listImage[swapIndex] = temp;
            }
            Console.WriteLine("\n\n замешанный :\n\n");
            foreach (var image in listImage)
            {
                Console.WriteLine(image);
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Задание 2");
            Console.WriteLine("Exersise 3");
            StreamReader sr = new StreamReader("Student.txt");
            int countStudents = 0;
            while (sr.ReadLine() != null)
            {
                countStudents++;
            }
            sr = new StreamReader("Student.txt");
            var students = new Dictionary<string, Student>();
            for (int i = 1; i < countStudents + 1; i++)
            {
                string[] allInfo = sr.ReadLine().Split(' ');
                Student student = new Student();
                student.name = allInfo[0];
                student.surname = allInfo[1];
                student.year = int.Parse(allInfo[2]);
                student.exam = allInfo[3];
                student.mark = int.Parse(allInfo[4]);
                students.Add($"student #{i}", student);

            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("input command of : output, add, remove, sort, exit");

                string input = Console.ReadLine().ToLower();
                if (input.Equals("output"))
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Key} {student.Value.name} {student.Value.surname} {student.Value.year} {student.Value.exam} {student.Value.mark}");
                    }
                }
                else if (input.Equals("exit"))
                {
                    flag = false;
                }
                else if (input.Equals("add"))
                {
                    Student student = new Student();
                    Console.Write("Input name : ");
                    student.name = Console.ReadLine();
                    Console.Write("Input surname : ");
                    student.surname = Console.ReadLine();
                    Console.Write("Input birthYear : ");
                    while (!int.TryParse(Console.ReadLine(), out student.year))
                    {
                        Console.WriteLine("try to input again!");
                    }
                    Console.Write("input exam : ");
                    student.exam = Console.ReadLine();
                    Console.Write("input mark :");
                    while (!int.TryParse(Console.ReadLine(), out student.mark))
                    {
                        Console.WriteLine("try to input again!");
                    }
                    students.Add($"student #{students.Count + 1}", student);
                }
                else if (input.Equals("remove"))
                {
                    Console.Write("Input name :");
                    string name = Console.ReadLine();
                    Console.Write("Input surname : ");
                    string surname = Console.ReadLine();
                    for (int i = 1; i < students.Count + 1; i++)
                    {
                        if (students["student #" + i].name.Equals(name) && students["student #" + i].surname.Equals(surname))
                        {
                            var tempStudent = students["student #" + i];
                            students["student #" + i] = students["student #" + students.Count];
                            students["student #" + students.Count] = tempStudent;
                            students.Remove($"student #{students.Count}");
                        }
                    }
                }
                else if (input.Equals("sort"))
                {
                    for (int i = 1; i < students.Count + 1; i++)
                    {
                        for (int j = 1; j < students.Count - i + 1; j++)
                        {
                            if (students["student #" + j].mark > students["student #" + (j + 1).ToString()].mark)
                            {
                                var temp = students["student #" + j];
                                students["student #" + j] = students["student #" + (j + 1)];
                                students["student #" + (j + 1)] = temp;

                            }
                        }
                    }
                }

            }
            Console.WriteLine("Exersise 4");
            Console.WriteLine("Сколько работников?");
            int countWorkers;
            while (!int.TryParse(Console.ReadLine(), out countWorkers) || countWorkers < 0)
            {
                Console.Write("Неверный ввод,повторите! ");
            }
            int countTables = countWorkers / 2;
            int capacityTables = 4;
            Console.Clear();
            var listWorkers = new List<Worker>();
            for (int i = 0; i < countWorkers; i++)
            {
                Console.Write("Введите имя работника - ");
                string name = Console.ReadLine();
                Console.Write("Где он работает? - ");
                string direction = Console.ReadLine();
                Console.Write("Введите его степень наглости(только целое значение) - ");
                ushort degreeImpudence;
                while (!ushort.TryParse(Console.ReadLine(), out degreeImpudence) || degreeImpudence < 0)
                {
                    Console.WriteLine("Неверный ввод!");
                }
                bool isStupid;
                Console.WriteLine("Введите тупой ли он? да / нет");
                if (Console.ReadLine().ToLower().Equals("да"))
                {
                    isStupid = true;
                }
                else
                {
                    isStupid = false;
                }
                listWorkers.Add(new Worker(name, direction, degreeImpudence, isStupid));
            }

            for (int i = 0; i < listWorkers.Count; i++)
            {
                for (int j = 0; j < listWorkers.Count - 1; j++)
                {
                    if (Worker.GetDegree(listWorkers[j]) > Worker.GetDegree(listWorkers[j + 1]) && Worker.IsStupid(listWorkers[j]))
                    {
                        var temp = listWorkers[j + Worker.GetDegree(listWorkers[j])];
                        listWorkers[j + Worker.GetDegree(listWorkers[j])] = listWorkers[j];
                        listWorkers[j] = temp;
                    }
                }

            }
            var queue = new Queue<Worker>();
            for (int i = 0; i < listWorkers.Count; i++)
            {
                queue.Enqueue(listWorkers[i]);
            }
            var listTables = new List<Stack<Worker>>();
            for (int i = 0; i < countTables; i++)
            {
                listTables.Add(new Stack<Worker>());
                for (int j = 0; j < capacityTables; j++)
                {
                    listTables[i].Push(queue.Peek());
                }



                Console.ReadKey();
                Console.WriteLine("Task 5");
                Console.WriteLine("Сколько бабушек?");
                int countGrand;
                while (!int.TryParse(Console.ReadLine(), out countGrand) || countGrand < 0)
                {
                    Console.WriteLine("Неверный ввод");
                }

                var grandmothers = new List<Grandmother>();
                for (int k = 0; k < countGrand; k++)
                {
                    Console.WriteLine("Какое имя у бабушки?");
                    string name = Console.ReadLine();
                    byte age;
                    Console.WriteLine("Введите возраст бабушки");
                    while (!byte.TryParse(Console.ReadLine(), out age) || age < 0)
                    {
                        Console.WriteLine("Неверно введен возраст");
                    }
                    Console.WriteLine("Сколько болезней у бабушки?");
                    int countDis;
                    while (!int.TryParse(Console.ReadLine(), out countDis) || countDis < 0)
                    {
                        Console.WriteLine("Неверный ввод!");
                    }
                    var diseases = new List<string>(countDis);
                    for (int j = 0; j < countDis; j++)
                    {
                        Console.WriteLine("Введите название болезни");
                        diseases.Add(Console.ReadLine().ToLower());
                    }
                    grandmothers.Add(new Grandmother(diseases, name, age));

                }
                int capasityInHospital1 = 4;
                var diseasesHealInHospital1 = new List<string> { "катаракта", "чума" };
                Hospital hospital1 = new Hospital(capasityInHospital1, diseasesHealInHospital1);

                int capasityInHospital2 = 6;
                var diseasesHealInHospital2 = new List<string> { "рак", "простуда", "морская болезнь", "излом кишки" };
                Hospital hospital2 = new Hospital(capasityInHospital2, diseasesHealInHospital2);
                List<Hospital> hospitals = new List<Hospital>();
                var queueGrand = new Queue<Grandmother>();
                for (int k = 0; k < grandmothers.Count; k++)
                {
                    for (int j = 0; j < hospitals.Count; j++)
                    {
                        if (Hospital.isWillHeal(grandmothers[k], hospitals[j]))
                        {
                            queueGrand.Enqueue(grandmothers[k]);
                        }
                    }
                }
            }

        }

    }
}
     

    

