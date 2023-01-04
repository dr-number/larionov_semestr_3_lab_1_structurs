namespace larionov_lab_1_structurs
{
    class TasksInfo
    {
        public const string TASK_6 = "Описать структуру с именем WORKER, содержащую следующие поля:\n" +
        "- фамилия и инициалы работника;\n" +
        "- название занимаемой должности;\n" +
        "- год поступления на работу.\n" +
        "Написать программу, выполняющую следующие действия:\n" +
        "* ввод с клавиатуры данных в массив, состоящий из десяти структур типа WORKER; записи должны быть размещены по алфавиту.\n" +
        "* вывод на дисплей фамилий работников, чей стаж работы в организации превышает значение, введенное с клавиатуры;\n" +
        "* если таких работников нет, вывести на дисплей соответствующее сообщение.\n";


        public const string TASK_16 = "Описать структуру с именем ZNAK, содержащую следующие поля:\n" +
        "- фамилия, имя;\n" +
        "- знак Зодиака;\n" +
        "- день рождения(массив из трех чисел).\n" +
        "Написать программу, выполняющую следующие действия:\n" +
        "* ввод с клавиатуры данных в массив, состоящий из восьми элементов тина ZNAK; записи должны быть упорядочены по датам дней рождения;\n" +
        "* вывод на экран информации о людях, родившихся под знаком, наименование которого введено с клавиатуры;\n" +
        "* если таких нет, выдать на дисплей соответствующее сообщение.";
    }

    class MyInput
    {
        public int inputInt(string text)
        {
            string xStr = "";
            bool isNumber = false;
            int x = 0;

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else
                    break;
            }

            return x;
        }

        public string inputText(string text)
        {
            string xStr = "";

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);
                xStr = Console.ReadLine();

                if (xStr == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пустая строка недопустима!\n");
                }
                else break;
            }

            return xStr;
        }

        public int inputCount(string text, int maxValue, int defaultValue)
        {

            string xStr = "";
            bool isNumber = false;
            int x = 0;

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);

                if (xStr == "")
                    return defaultValue;

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else if (x <= 0 || x > maxValue)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите число в промежутке от 0 до {maxValue} включительно!\n");
                }
                else
                    break;
            }

            return x;
        }

        public int inputInterval(string text, int minValue, int maxValue)
        {

            string xStr = "";
            bool isNumber = false;
            int x = 0;

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else if (x < minValue || x > maxValue)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите число в промежутке от {minValue} до {maxValue} включительно!\n");
                }
                else
                    break;
            }

            return x;
        }
    }

    class MyQuestion
    {
        public string INPUT_FROM_KEYBOARD = "Хотите ввести исходные данные с клавиатуры? [y/n]: ";
        public string WRITE_TO_FILE = "Записать результирующие данные в файл?  [y/n]: ";

        public bool isQuestion(string textQuestion)
        {
            Console.WriteLine("\n" + textQuestion);
            return Console.ReadLine()?.ToLower() != "n";
        }
    }

    class MyFiles
    {
        public bool saveToFile(string fileName, List<String> data)
        {
            StreamWriter file = null;
            bool result = false;
            try
            {
                file = new StreamWriter(fileName);
                foreach (var item in data)
                    file.WriteLine(item);

                file.Close();
                result = true;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка при записи в файл: {e.Message}");
                result = false;
            }
            finally
            {
                try
                {
                    file.Close();
                }
                catch (Exception ignore) {}
            }

            return result;
        }
    }

    class Task1
    {
        int DEFAULT_COUNT_STRUCT = 10;
        int MAX_COUNT_STRUCT = 100;
        string READ_INIT_DATA_FROM_FILE = "workers_data.txt";
        string SAVE_DATA_TO_FILE = "output_workers.txt";

        int EXPERIENCE_DEFAULT = 15;
        int EXPERIENCE_MAX = 50;
        private struct WORKER
        {
            public string surnameInitials;
            public string position;
            public int yearEmployment;
        };

        private List<WORKER> workerSort(List<WORKER> workers)
        {
            if (workers == null)
                return null;

            return workers.OrderBy(item => item.surnameInitials).ToList();
        }

        private void printWorkers(List<WORKER> workers)
        {
            Console.WriteLine("{0,30}|   {1,30}|   {2,30}", "Фамилия и инициалы", "Должность", "Год поступления на работу");

            foreach (var item in workers)
                Console.WriteLine("{0,30}|   {1,30}|   {2,30}", item.surnameInitials, item.position, item.yearEmployment);
        }

        private List<String> workersToString(List<WORKER> workers)
        {
            List<String> result = new List<String>();

            foreach (var item in workers)
                result.Add($"{item.surnameInitials}, {item.position}, {item.yearEmployment}");

            return result;
        }

        private void printSurname(List<WORKER> workers)
        {
            foreach (var item in workers)
                Console.WriteLine(item.surnameInitials.Split(" ")[0]);
        }

        private List<WORKER> getWorkersExperienceMoreThan(List<WORKER> workers, int experience)
        {
            List<WORKER> array = new List<WORKER>();
            int currentYear = DateTime.Now.Year;

            foreach (var item in workers)
                if (currentYear - item.yearEmployment > experience)
                    array.Add(item);

            return array;
        }

        private string inputSurnameInitials()
        {
            MyInput myInput = new MyInput();
            string surname = myInput.inputText("\nВведите фамилию: ");
            string initials = myInput.inputText("\nВведите инициалы: ");
            return surname + " " + initials;
        }

        private WORKER inputWorker(int current, int max)
        {
            MyInput myInput = new MyInput();
            WORKER worker = new WORKER();

            Console.ResetColor();
            Console.WriteLine($"\nВведите данные сотрудника {current} из {max}: ");

            worker.surnameInitials = inputSurnameInitials();
            worker.position = myInput.inputText("\nВведите название занимаемой должности: ");
            worker.yearEmployment = myInput.inputInt("\nВведите год поступления на работу: ");

            return worker;
        }

        private List<WORKER> createArrayFromKeyboard()
        {
            MyInput myInput = new MyInput();
            List<WORKER> array = new List<WORKER>();

            int countValues = myInput.inputCount($"\nСколько нужно структур? (Для {DEFAULT_COUNT_STRUCT} нажмите ENTER): \0", MAX_COUNT_STRUCT, DEFAULT_COUNT_STRUCT);

            for (int i = 0; i < countValues; i++)
                array.Add(inputWorker(i + 1, countValues));
            
            return array;
        }

        private List<WORKER> readFile(string kFileName)
        {
            if (!File.Exists(kFileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл {kFileName} не существует!");
                return null;
            }

            StreamReader file = null;
            List<WORKER> result = new List<WORKER>();

            try
            {
                WORKER worker;
                file = new StreamReader(kFileName);

                while (!file.EndOfStream)
                {
                    try
                    {
                        var (surnameInitials, position, yearEmployment) = file.ReadLine().Split(", ") switch { var a => (a[0], a[1], a[2]) };
                        worker = new WORKER();
                        worker.surnameInitials = surnameInitials;
                        worker.position = position;
                        worker.yearEmployment = int.Parse(yearEmployment);
                        result.Add(worker);
                    }
                    catch (Exception ignore){}

                }
                file.Close();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка при чтении из файла: {e.Message}");
            }
            finally
            {
                try
                {
                    file.Close();
                }
                catch (Exception ignore) { }
            }

            return result;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.TASK_6);

            MyQuestion myQuestion = new MyQuestion();
            bool isFromKeyboard = myQuestion.isQuestion(myQuestion.INPUT_FROM_KEYBOARD);

            List<WORKER> array;

            if (isFromKeyboard)
                array = createArrayFromKeyboard();
            else
                array = readFile(READ_INIT_DATA_FROM_FILE);

            if (array == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет исходных данных!");
                return;
            }

            array = workerSort(array);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Исходные данные: ");
            printWorkers(array);

            MyInput myInput = new MyInput();
            int experience = myInput.inputCount($"\nСколько лет стажа? (Для {EXPERIENCE_DEFAULT} нажмите ENTER)\0: ", EXPERIENCE_MAX, EXPERIENCE_DEFAULT);

            array = workerSort(getWorkersExperienceMoreThan(array, experience));
            Console.ForegroundColor = ConsoleColor.Green;

            bool isSaveToFile = myQuestion.isQuestion(myQuestion.WRITE_TO_FILE);
            bool isEmptyResult = array.Count == 0;
            string title = "";

            if (isEmptyResult)
                title = $"Cотрудники со стажем {experience} лет не найдены!";
            else
                title = $"Фамилии работников ({array.Count} чел.), чей стаж работы в организации превышает {experience} лет: ";

            if (!isSaveToFile)
            {
                if (isEmptyResult)
                    Console.ForegroundColor = ConsoleColor.Red;
                   
                Console.WriteLine(title);
                printSurname(array);
            }
            else
            {
                MyFiles myFiles = new MyFiles();
                List<string> saveData = workersToString(array);
                saveData.Insert(0, title);
                myFiles.saveToFile(SAVE_DATA_TO_FILE, saveData);
            }
        }
    }

    class Task2
    {
        int DEFAULT_COUNT_STRUCT = 8;
        int MAX_COUNT_STRUCT = 100;
        string READ_INIT_DATA_FROM_FILE = "zodiak_data.txt";

        int MIN_MONTH = 1;
        int MAX_MONTH = 12;

        int MIN_DAY = 1;
        int MAX_DAY = 31;

        int MIN_YEAR = 1;
        int MAX_YEAR = 9999;

        string FORMAT_DATE_PRINT = "dd.MM.yyyy";

        private struct ZNAK
        {
            public string surnameName;
            public string zodiacSign;
            public int[] birthday;
        };

        private long dateToMillisecond(int[] birthday)
        {
            return ((DateTimeOffset)new DateTime(birthday[2], birthday[1], birthday[0])).ToUnixTimeMilliseconds();
        }

        private List<ZNAK> signSort(List<ZNAK> signs)
        {
            if (signs == null)
                return null;

            return signs.OrderBy(item => dateToMillisecond(item.birthday)).ToList();
        }

        private void printSigns(List<ZNAK> signs)
        {
            Console.WriteLine("{0,30}|   {1,30}|   {2,30}", "Фамилия мия", "Дата рождения", "Знак зодиака");

            foreach (var item in signs)
                Console.WriteLine(
                    "{0,30}|   {1,30}|   {2,30}", 
                    item.surnameName,
                    new DateTime(item.birthday[2], item.birthday[1], item.birthday[0]).ToString(FORMAT_DATE_PRINT), 
                    item.zodiacSign
               );
        }

        private void printMiniInfo(List<ZNAK> signs)
        {
            foreach (var item in signs)
            {
                Console.WriteLine(
                    "{0,30}|   {1,30}", 
                    item.surnameName,
                    new DateTime(item.birthday[2], item.birthday[1], item.birthday[0]).ToString(FORMAT_DATE_PRINT)
                );
            }
        }

        private List<ZNAK> getPeopleWithSign(List<ZNAK> peoples, string sign)
        {
            List<ZNAK> array = new List<ZNAK>();
            sign = sign.ToLower();

            foreach (var item in peoples)
                if (item.zodiacSign.ToLower() == sign)
                    array.Add(item);

            return array;
        }

        private string inputSurnameName()
        {
            MyInput myInput = new MyInput();
            string surname = myInput.inputText("\nВведите фамилию: ");
            string name = myInput.inputText("\nВведите имя: ");
            return surname + " " + name;
        }

        private int[] inputBirthday()
        {
            MyInput myInput = new MyInput();
            int day = myInput.inputInterval("\nВведите день: ", MIN_DAY, MAX_DAY);
            int month = myInput.inputInterval("\nВведите месяц: ", MIN_MONTH, MAX_MONTH);
            int year = myInput.inputInterval("\nВведите год: ", MIN_YEAR, MAX_YEAR);
            return new int[] { day, month, year };
        }

        private string getZodiacSign(int day, int month)
        {
            if ((day >= 22 && month == 12) || (day <= 20 && month == 1))
                return "Козерог";

            if ((day >= 21 && month == 1) || (day <= 19 && month == 2))
                return "Водолей";

            if ((day >= 20 && month == 2) || (day <= 20 && month == 3))
                return "Рыбы";

            if ((day >= 21 && month == 3) || (day <= 20 && month == 4))
                return "Овен";

            if ((day >= 21 && month == 4) || (day <= 20 && month == 5))
                return "Телец";

            if ((day >= 21 && month == 5) || (day <= 21 && month == 6))
                return "Близнецы";

            if ((day >= 22 && month == 6) || (day <= 22 && month == 7))
                return "Рак";

            if ((day >= 23 && month == 7) || (day <= 23 && month == 8))
                return "Лев";

            if ((day >= 24 && month == 8) || (day <= 23 && month == 9))
                return "Дева";

            if ((day >= 24 && month == 9) || (day <= 23 && month == 10))
                return "Весы";

            if ((day >= 24 && month == 10) || (day <= 22 && month == 11))
                return "Скорпион";

            if ((day >= 23 && month == 11) || (day <= 21 && month == 12))
                return "Стрелец";

            return "Знак зодиака не определен";
        }

        private ZNAK inputPeople(int current, int max)
        {
            ZNAK znak = new ZNAK();
            Console.ResetColor();
            Console.WriteLine($"\nВведите данные человека {current} из {max}: ");

            znak.surnameName = inputSurnameName();
            int[] birthday = inputBirthday();
            znak.birthday = birthday;
            znak.zodiacSign = getZodiacSign(birthday[0], birthday[1]);

            return znak;
        }

        private List<ZNAK> createArrayFromKeyboard()
        {
            MyInput myInput = new MyInput();
            List<ZNAK> array = new List<ZNAK>();

            int countValues = myInput.inputCount($"\nСколько нужно людей? (Для {DEFAULT_COUNT_STRUCT} нажмите ENTER): \0", MAX_COUNT_STRUCT, DEFAULT_COUNT_STRUCT);

            for (int i = 0; i < countValues; i++)
                array.Add(inputPeople(i + 1, countValues));

            return array;
        }

        private List<ZNAK> readFile(string kFileName)
        {
            if (!File.Exists(kFileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл {kFileName} не существует!");
                return null;
            }

            List<ZNAK> result = new List<ZNAK>();

            try
            {
                ZNAK people;
                StreamReader file = new StreamReader(kFileName);

                while (!file.EndOfStream)
                {
                    try
                    {
                        var (surnameName, birthday) = file.ReadLine().Split(", ") switch { var a => (a[0], a[1]) };
                        string[] birthdayStr = birthday.Split(".");
                        int[] birthdayArray = new int[] {
                            int.Parse(birthdayStr[0]),
                            int.Parse(birthdayStr[1]),
                            int.Parse(birthdayStr[2])
                        };
                        people = new ZNAK();
                        people.surnameName = surnameName;
                        people.birthday = birthdayArray;
                        people.zodiacSign = getZodiacSign(birthdayArray[0], birthdayArray[1]);
                        result.Add(people);
                    }
                    catch (Exception ignore) { }

                }
                file.Close();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            return result;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.TASK_6);

            MyQuestion myQuestion = new MyQuestion();
            bool isFromKeyboard = myQuestion.isQuestion(myQuestion.INPUT_FROM_KEYBOARD);

            List<ZNAK> array;

            if (isFromKeyboard)
                array = createArrayFromKeyboard();
            else
                array = readFile(READ_INIT_DATA_FROM_FILE);

            if (array == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет исходных данных!");
                return;
            }

            array = signSort(array);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Исходные данные: ");
            printSigns(array);

            MyInput myInput = new MyInput();
            string signZodiak = myInput.inputText($"\nВведите знак зодиака\0: ");

            array = getPeopleWithSign(array, signZodiak);
            Console.ForegroundColor = ConsoleColor.Green;

            if (array.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Люди со знаком зодиака \"{signZodiak}\" не найдены!");
            }

            Console.WriteLine($"Люди ({array.Count} чел.) со знаком зодиака {signZodiak}: ");
            printMiniInfo(signSort(array));
        }
    }

    class Class1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Варинат №6-16. Ларионов Никита Юрьевич. гр. 210з\n");
            bool isGo = true;

            while (isGo)  
            {
                Console.ResetColor();
                Console.WriteLine("\nВведите номер задачи: ");
                Console.WriteLine("\n1) " + TasksInfo.TASK_6);
                Console.WriteLine("\n2) " + TasksInfo.TASK_16);

                Console.WriteLine("\nДля выхода введите \"0\": ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Task1 task1 = new Task1();
                        task1.init();
                        break;

                    case "2":
                        Task2 task2 = new Task2();
                        task2.init();
                        break;

                    case "0":
                        isGo = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНекорректные данные!");
                        Console.ResetColor();
                        break;

                }

                Console.ResetColor();
                Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                Console.ReadLine();
            }

        }
    }

}
