namespace larionov_lab_1_structurs
{
    class TasksInfo
    {
        public const string TASK_6 = "Описать структуру с именем WORKER, содержащую следующие поля:\n" +
        "* фамилия и инициалы работника;\n" +
        "* название занимаемой должности;\n" +
        "* год поступления на работу.\n\n" +
        "Написать программу, выполняющую следующие действия:\n" +
        "* ввод с клавиатуры данных в массив, состоящий из десяти структур типа WORKER; записи должны быть размещены по алфавиту.\n" +
        "* вывод на дисплей фамилий работников, чей стаж работы в организации превышает значение, введенное с клавиатуры;\n" +
        "* если таких работников нет, вывести на дисплей соответствующее сообщение.\n\n\n";

        public const string TASK_16 = "Описать структуру с именем ZNAK, содержащую следующие поля:\n" +
        "* фамилия, имя;\n" +
        "* знак Зодиака;\n" +
        "* день рождения(массив из трех чисел).\n\n" +
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
    }

    class MyQuestion
    {
        public string INPUT_FROM_KEYBOARD = "Хотите ввести исходные данные с клавиатуры? [y/n]: ";

        public bool isQuestion(string textQuestion)
        {
            Console.WriteLine("\n" + textQuestion);
            return Console.ReadLine()?.ToLower() != "n";
        }
    }

    class Task1
    {
        int DEFAULT_COUNT_STRUCT = 10;
        int MAX_COUNT_STRUCT = 100;
        string READ_INIT_DATA_FROM_FILE = "data.txt";

        private struct WORKER
        {
            public string surnameInitials;
            public string position;
            public int yearEmployment;
        };

        private string inputSurnameInitials()
        {
            MyInput myInput = new MyInput();
            string surname = myInput.inputText("Введите фамилию: ");
            string initials = myInput.inputText("Введите инициалы: ");
            return surname + " " + initials;
        }

        private WORKER inputWorker()
        {
            MyInput myInput = new MyInput();
            WORKER worker = new WORKER();

            Console.ResetColor();
            Console.WriteLine("Введите данные сотрудника: ");

            worker.surnameInitials = inputSurnameInitials();
            worker.position = myInput.inputText("Введите название занимаемой должности: ");
            worker.yearEmployment = myInput.inputInt("Введите год поступления на работу: ");

            return worker;
        }

        private List<WORKER> createArrayFromKeyboard()
        {
            MyInput myInput = new MyInput();
            List<WORKER> array = new List<WORKER>();

            int countValues = myInput.inputCount($"\nСколько нужно структур? (Для {DEFAULT_COUNT_STRUCT} нажмите ENTER): \0", MAX_COUNT_STRUCT, DEFAULT_COUNT_STRUCT);

            for (int i = 0; i < countValues; i++)
                array.Add(inputWorker());
            
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

            List<WORKER> result = new List<WORKER>();

            try
            {
                string aStr = "";
                WORKER worker;

                int countStrings = 0, countProcessingStrings = 0;
                StreamReader file = new StreamReader(kFileName);

                while (!file.EndOfStream)
                {
                    ++countStrings;
                    try
                    {
                        var (surnameInitials, position, yearEmployment) = file.ReadLine().Split(", ") switch { var a => (a[0], a[1], a[2]) };

                        worker = new WORKER();
                        worker.surnameInitials = surnameInitials;
                        worker.position = position;
                        worker.yearEmployment = int.Parse(yearEmployment);

                        result.Add(worker);
                        ++countProcessingStrings;
                     
                    }
                    catch (Exception ignore){}

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

            List<WORKER> array = null;

            if (isFromKeyboard)
                array = createArrayFromKeyboard();
            else
                array = readFile(READ_INIT_DATA_FROM_FILE);
        }
    }

    class Task2
    {
        private struct ZNAK
        {
            public string surname_name;
            public string zodiac_sign;
            public int[] birthday;
        };
    }
}
