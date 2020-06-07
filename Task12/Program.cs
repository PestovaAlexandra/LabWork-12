using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary10;

namespace Task12
{
    class Program
    {
        static void SecondMenu()
        {
            Console.WriteLine("1. Работа с односвязным списком\n2. Работа с двусвязным списком\n3. Работа с деревом\n4. Назад");
        }
        static void MainMenu()
        {
            Console.WriteLine("1. 1 Часть\n2. 2 Часть\n3. Выход");
        }
        static void MenuOList()
        {
            Console.WriteLine("1. Создать односаязный список\n2. Удалить элементы с четными номерами\n3. Удалить односвязный список из памяти\n4. Распечатать список\n5. Назад");
        }
        static void MenubiList()
        {
            Console.WriteLine("1. Создать двусвязный список\n2. Добавить элемент с заданным номером  \n3. Удалить двусвязный список из памяти\n4. Распечатать список\n5. Назад");
        }
        static void MenuTree()
        {
            Console.WriteLine("1. Создать идеально сбалансированное дерево\n2. Найти минимальный элемент\n3. Преобразовать дерево поиска в идеально сбалансированное дерево\n4. Удалить дерево из памяти\n5. Назад ");
        }
        static void MyCollectionMenu()
        {
            Console.WriteLine("1. Создать коллекцию\n2. Добавить элементы\n3. Удалить элементы\n4. Поиск элемента по значению\n5. Поверхностное клонирование\n6. Полное клонирование\n7. Удалить из памяти\n8. Распечатать \n9. Назад ");
        }
        static int Natural(out int a)
        {
            a = 0;
            bool ok = true;
            do
            {
                try
                {
                    a = int.Parse((Console.ReadLine()));
                    if (a < 0)
                    {
                        ok = false;
                        Console.WriteLine("Введите натуральное число");
                    }
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число от 1 до 3");
                }
            } while (!ok);
            return a;
        }
        static int Input(out int a, int down, int up)
        {
            a = 0;
            bool ok = true;
            do
            {
                try
                {
                    a = int.Parse((Console.ReadLine()));
                    if (a < 0)
                    {
                        ok = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число от 1 до 3");
                }
            } while (!ok || a < down || a > up);
            return a;
        }
        //static void Show(MyCollection<string> My)
        //{
        //    foreach (string str in My)
        //        Console.WriteLine(str);

        //}
        static void Main(string[] args)
        {
            OList olist = null;
            biList bilist = null;
            TreeNode root = null;
            TreeNode searchRoot = null;
            int choice = 0;
            MyCollection<Item> collection = null;
            do
            {
                MainMenu();
                Input(out choice, 1, 3);
                switch (choice)
                {
                    case 1:// 1 Часть
                        {
                            do
                            {
                                SecondMenu();
                                Input(out choice, 1, 4);
                                switch (choice)
                                {
                                    case 1: // Односвязный
                                        {
                                            do
                                            {
                                                MenuOList();
                                                Input(out choice, 1, 5);
                                                switch (choice)
                                                {
                                                    case 1: // Create and output
                                                        {
                                                            int l = 0;
                                                            olist = new OList();
                                                            Console.WriteLine("Введите количество элементов в списке");
                                                            olist = OList.AddEndLIST(Natural(out l));
                                                            OList.ShowList(olist);
                                                        }
                                                        break;

                                                    case 2: // task
                                                        {
                                                            if (olist == null)
                                                                Console.WriteLine("Односвязный список не создан");
                                                            else
                                                            {
                                                                olist = OList.Delete2(olist);
                                                                OList.ShowList(olist);
                                                            }
                                                        }
                                                        break;

                                                    case 3: // Del
                                                        {
                                                            if (olist == null)
                                                                Console.WriteLine("Односвязный список не создан");
                                                            else
                                                            {
                                                                olist = null;
                                                                Console.WriteLine("Однонаправленный список удалён");
                                                            }

                                                        }
                                                        break;
                                                    case 4:
                                                        {
                                                            OList.ShowList(olist);
                                                        }
                                                        break;
                                                }
                                            } while (choice != 5);
                                            choice = 0;
                                        }
                                        break;
                                    case 2: // Двусвязный
                                        {
                                            do
                                            {
                                                MenubiList();
                                                Input(out choice, 1, 4);
                                                switch (choice)
                                                {
                                                    case 1: // Create and output
                                                        {
                                                            int l = 0;
                                                            Console.WriteLine("Введите количество элементов в двусвязном списке");
                                                            bilist = new biList();
                                                            bilist.Create(Natural(out l));
                                                            biList.WriteList(bilist);
                                                        }
                                                        break;

                                                    case 2: // task
                                                        {
                                                            if (bilist == null)
                                                                Console.WriteLine("Двунаправлленный список не создан");
                                                            else
                                                            {
                                                                Console.WriteLine("Введите номер вставляемого элемента");
                                                                int number = 0;
                                                                bilist.AddNode(Natural(out number));
                                                                biList.WriteList(bilist);
                                                            }
                                                        }
                                                        break;

                                                    case 3: // Del
                                                        {
                                                            if (bilist == null)
                                                                Console.WriteLine("Двунаправлленный список не создан");
                                                            else
                                                            {
                                                                bilist = null;
                                                                Console.WriteLine("Двунаправленный список удалён");
                                                            }


                                                        }
                                                        break;
                                                    case 4:
                                                        {
                                                            OList.ShowList(olist);
                                                        }
                                                        break;
                                                }
                                            } while (choice != 5);
                                            choice = 0;
                                        }
                                        break;
                                    case 3: // Дерево
                                        {
                                            do
                                            {
                                                MenuTree();
                                                choice = Input(out choice, 1, 5);
                                                switch (choice)
                                                {
                                                    case 1:
                                                        {
                                                            int l = 0;
                                                            root = new TreeNode();
                                                            Console.WriteLine("Введите размер дерева");
                                                            root=TreeNode.IdealTree(Natural(out l), root);
                                                            TreeNode.ShowTree(root, 3);
                                                        }
                                                        break;

                                                    case 2:
                                                        {
                                                            if (root == null)
                                                                Console.WriteLine("Дерево не создано");
                                                            else
                                                            {
                                                                Console.WriteLine($"Минимальный элемент {TreeNode.SearchMin(root)}");
                                                            }
                                                        }
                                                        break;

                                                    case 3:
                                                        {
                                                            if (root == null)
                                                                Console.WriteLine("Идеально сбалансированное дерево еще не создано. Создание дерева поиска невозможно.");
                                                            else
                                                            {
                                                                searchRoot = TreeNode.CreateSearchTree(searchRoot, root);
                                                                TreeNode.ShowTree(searchRoot, 3);
                                                            }
                                                        }
                                                        break;

                                                    case 4:
                                                        {
                                                            if (root == null)
                                                                Console.WriteLine("Дерево не создано");
                                                            else
                                                            {
                                                                root = null;
                                                                Console.WriteLine("Дерево удалено");
                                                            }
                                                        }
                                                        break;
                                                }

                                            } while (choice != 5);

                                        }
                                        break;
                                }
                            } while (choice != 4);
                            break;
                        }
                    case 2: // 2 Часть
                        do
                        {
                            MyCollectionMenu();
                            switch (Input(out choice, 1, 10))
                            {
                                case 1: // Creat
                                    {
                                         collection= new MyCollection<Item>();
                                        Console.WriteLine("Хеш-таблица словаря создана");
                                    }
                                    break;
                                case 2: // Insert
                                    {
                                        Console.WriteLine("1. Добавить рандомные элементы(несколько) 2. Добавить определенный элемент(1)");
                                        switch(Input(out choice, 1, 9))
                                        {
                                            case 1: //InsertRandom
                                                {
                                                    if (collection == null)
                                                        Console.WriteLine("Хеш-таблица не создана ");
                                                    else
                                                    {
                                                        Console.WriteLine("Введите количество вставляемых элементов");
                                                        collection.InsertRandom(int.Parse(Console.ReadLine()));
                                                        Console.WriteLine("Элемент добавлен");
                                                    }
                                                    
                                                }
                                                break;
                                            case 2:
                                                {
                                                    if (collection == null)
                                                        Console.WriteLine("Хеш-таблица не создана ");
                                                    else
                                                    {
                                                        Console.WriteLine("Введите значение");
                                                        Console.WriteLine("Введите имя");
                                                        string name = Console.ReadLine();
                                                        Console.WriteLine("Введите возраст");
                                                        int age = int.Parse(Console.ReadLine());
                                                        Console.WriteLine("Введите стаж");
                                                        int exp = int.Parse(Console.ReadLine());

                                                        Employee one = new Employee(name, age, exp);
                                                        collection.Insert(one);
                                                        Console.WriteLine("Элемент добавлен");
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    break;
                                case 3: // Remove
                                    {
                                        if (collection == null)
                                            Console.WriteLine("Хеш-таблица не создана");
                                        else
                                        {
                                            Console.WriteLine("Введите количество удаляемых элементов");
                                            collection.Delete(int.Parse(Console.ReadLine()));
                                        }
                                    }
                                    break;
                                case 4: // Search
                                    {
                                        if ( collection== null)
                                            Console.WriteLine("Хеш-таблица не создана ");
                                        else
                                        {
                                            Employee emp = new Employee("Пестова Александра", 19, 1);
                                            Item newItem = new Item(emp);

                                            if (collection.Search(newItem))
                                                Console.WriteLine("Элемент найден");
                                            else
                                                Console.WriteLine("Элемент не найден");
                                        }
                                    }
                                    break;
                                case 5: // ref clone
                                    {
                                        if (collection == null)
                                            Console.WriteLine("Хеш-таблица не создана ");
                                        else
                                        {
                                            MyCollection<Item> CloneCollection = collection;
                                            Console.WriteLine("Коллекция поверхностно скопирована");
                                            Console.WriteLine("Добавим в клон коллекции элемент \"Меня добавили\". Он также появится и в клонируемой коллекции");
                                            Employee one = new Employee("Меня добавили", 1, 1);
                                            CloneCollection.Insert(one);
                                            MyCollection<Item>.ShowHashTable(CloneCollection, "Клон");
                                            MyCollection<Item>.ShowHashTable(collection, "Основа");
                                        }
                                    }
                                    break;
                                case 6: // full clone 
                                    {
                                        if (collection == null)
                                            Console.WriteLine("Очередь на базе однонаправленного списка не создана ");
                                        else
                                        {
                                            MyCollection<Item> Clone = new MyCollection<Item>();
                                            Clone.AllCopy(collection.items, ref Clone.items);
                                            Console.WriteLine("Коллекция плностью скопирована");
                                            Console.WriteLine("Добавим в клон коллекции элемент \"Меня добавили\". Он не появится и в клонируемой коллекции");
                                            Employee one = new Employee("Меня добавили", 1, 1);
                                            Clone.Insert(one);
                                            MyCollection<Item>.ShowHashTable(Clone, "Клон");
                                            MyCollection<Item>.ShowHashTable(collection, "Основа");
                                        }
                                    }
                                    break;
                                case 7: // del
                                    {
                                        if (collection == null)
                                            Console.WriteLine("хеш-таблица не создана ");
                                        else
                                        {
                                            collection.Clear();
                                            Console.WriteLine("Коллекция удалена");
                                        }
                                    }
                                    break;
                                case 8: //write
                                    {
                                        MyCollection<Item>.ShowHashTable(collection, "Хеш-таблица");
                                    }
                                    break;
                            }

                        } while (choice != 9);
                        break;

                }
            } while (choice != 3);

        }
    }
}
