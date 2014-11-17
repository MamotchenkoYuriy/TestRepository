using HW_3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_3.Implements;
using HW_3.Interfaces;
using HW_3.Implaments;
using HW_3.SourseCode;
using HW_3;

namespace HW_3.SourseCode
{
    public class InteractiveConsole
    {
        ArrayList<LibraryItem> list = new ArrayList<LibraryItem>();
        private void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Работа с книгами");
                Console.WriteLine("2 - Работа с журналами");
                Console.WriteLine("3 - Выход");
                int consoleCommand = ReadIntValueFromConsole(1, 3);
                if (consoleCommand == 1)
                {
                    BookMenu();
                }
                else if (consoleCommand == 2)
                {
                    JournalMenu();
                }
                else if (consoleCommand == 3)
                {
                    OutSerialiseMenu();
                    return;
                }
            }
        }

        public void Start()
        {
            Console.WriteLine("Восстановить все??? ");
            Console.WriteLine("1 - Да");
            Console.WriteLine("2 - Нет");
            int number = ReadIntValueFromConsole(1, 2);
            if (number == 1)
            {
                list = new ArrayList<LibraryItem>(Serializer<List<LibraryItem>>.DeSerialize("./SerializeFile.xml"));
                //var deserList = Serializer<List<LibraryItem>>.DeSerialize("./SerializeFile.xml");
            }
            Menu();
        }
        private void OutSerialiseMenu()
        {
            Console.WriteLine("Сохранить все??? ");
            Console.WriteLine("1 - Да");
            Console.WriteLine("2 - Нет");
            int number = ReadIntValueFromConsole(1, 2);
            if (number == 1)
            {
                Serializer<List<LibraryItem>>.Serialize(list.ToList(), "./SerializeFile.xml");
            }
            Menu();
        }


        private void JournalMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Добавить журнал");
                Console.WriteLine("2 - Просмотреть все");
                Console.WriteLine("3 - Удалить журнал");
                Console.WriteLine("4 - Выход");
                int consoleCommand = ReadIntValueFromConsole(1, 4);
                if (consoleCommand == 1)
                {
                    AddJornalMenu();
                }
                else if (consoleCommand == 2)
                {
                    ShowAll<Journal>("Все журналы -->");
                }
                else if (consoleCommand == 3)
                {
                    DeleteBookMenu();
                }
                else if (consoleCommand == 4) break;
            }
        }

        private void AddJornalMenu()
        {
            Console.Clear();
            Console.WriteLine("Введите следующие данные: ");
            Console.WriteLine("Название журнала: ");
            string name = Console.ReadLine();
            Console.WriteLine("Номер выпуска: ");
            int number = ReadIntValueFromConsole();
            Console.WriteLine("Год издания: ");
            int year = ReadIntValueFromConsole();
            list.Add(new Journal() { Name = name, Number = number, Year = year, Id = Generator.Generate(list) });
        }

        #region Book и все что связанно с ним
        private void BookMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Добавить книку");
                Console.WriteLine("2 - Просмотреть все");
                Console.WriteLine("3 - Удалить книгу");
                Console.WriteLine("4 - Выход");
                int consoleCommand = ReadIntValueFromConsole(1, 4);
                if (consoleCommand == 1)
                {
                    AddBookMenu();
                }
                else if (consoleCommand == 2)
                {
                    ShowAll<Book>("Все книги -->");
                }
                else if (consoleCommand == 3)
                {
                    DeleteBookMenu();
                }
                else if (consoleCommand == 4) break;
            }
        }

        private void DeleteBookMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выбирите дейтвие: ");
                Console.WriteLine("1 - Удалить по ID: ");
                Console.WriteLine("2 - Удалить по номеру: ");
                Console.WriteLine("3 - Выход");
                int commandNumber = ReadIntValueFromConsole(1, 3);
                if (commandNumber == 1)
                {
                    Console.WriteLine("Введите ID книги: ");
                    int Id = ReadIntValueFromConsole();
                    list.RemoveById(Id);
                }
                else if (commandNumber == 2)
                {
                    Console.WriteLine("Введите номер книги в консоле");
                    list.RemoveAt(ReadIntValueFromConsole());
                }
                else if (commandNumber == 3)
                {
                    break;
                }
            }
        }
        private void AddBookMenu()
        {
            Console.Clear();
            Console.WriteLine("Введите следующие данные: ");
            Console.WriteLine("Название книги: ");
            string name = Console.ReadLine();
            Console.WriteLine("Автор книги: ");
            string author = Console.ReadLine();
            Console.WriteLine("Год издания: ");
            int year = ReadIntValueFromConsole();
            list.Add(new Book() { Name = name, Author = author, Year = year, Id = Generator.Generate(list) });
        }

        #endregion
        private void ShowAll<T>(string messsage)
        {
            Console.WriteLine(messsage);
            foreach (var item in list.GetOnly<T>())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }




        #region Получение int значение со строки

        private int ReadIntValueFromConsole()
        {
            string errMessage = string.Empty;
            while (true)
            {
                Console.WriteLine(errMessage);
                string strValue = Console.ReadLine();
                try
                {
                    return Convert.ToInt32(strValue);
                }
                catch (Exception err) { errMessage = "Вы ввели не корректное значение!!!"; }
            }
        }

        private int ReadIntValueFromConsole(int min, int max)
        {
            while (true)
            {
                int value = ReadIntValueFromConsole();
                if (Enumerable.Range(1, 10).Contains(value)) { return value; }
            }
        }

        #endregion
    }
}
