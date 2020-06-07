using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary10;

namespace Task12
{
    class OList
    {
        public MyClassLibrary10.Employee data;
        public OList next;
        int count;

        public OList()
        {
            data = null;
            next = null;
            count = 0;
        }


        public static MyClassLibrary10.Employee MakeNew()
        {
            MyClassLibrary10.Employee Employee = new MyClassLibrary10.Employee();
            return Employee;
        }

        public static OList AddBeginningLIST(int l) // Добовление в начало однонаправленного списка
        {
            OList beg = new OList();//начало списка
            beg.data = MakeNew(); //созднание нового элемента
            for (int i = 1; i < l; i++)
            {
                //Console.WriteLine(beg.data.ToString());//это мне для проверки
                MyClassLibrary10.Employee tmp = new MyClassLibrary10.Employee(); // Данные для OList
                OList element = new OList(); // Новый узел 
                element.data = tmp; // Заполняем data нового узла              
                element.next = beg; // ссылаемся на предыдущий узел 
                beg = element;      // Присваиваем предыдущему узлу ссылку на текущий
            }
            beg.count = l;
            return beg;
        }

        public static void ShowList(OList list) // Вывод списка
        {
            if (list == null) // Проверка на заполненность 1-го узла
                Console.WriteLine("Список пустой");
            else
            {
                OList tmp = list;
                while (tmp != null) // Проверка на заполненность узла
                {
                    tmp.data.PrintInfo();
                    tmp = tmp.next; // Переход на следующий узел в листе
                }
            }
        }

        public static OList AddEndLIST(int l) // Добавление в конец списка
        {
            OList beg = new OList();
            beg.data = new Worker(); // Первый элемент фундамент
            OList end = beg; // Переменная end нужна, чтобы ссылка пременной beg не стёрлась из памяти
            for (int i = 1; i < l; i++) //сколько элементов вставить
            {
                OList Node = new OList();
                if (i % 2 == 0)
                {
                    Node.data = new MyClassLibrary10.Worker();
                }
                else if (i % 3 == 0)
                {
                    Node.data = new MyClassLibrary10.Engneer();
                }
                else
                {
                    Node.data = new MyClassLibrary10.Employee();
                }

                end.next = Node;
                end = Node;
            }
            beg.count = l;//сколько объектов в списке
            return beg;
        }

        public static OList Add(OList list, int n, MyClassLibrary10.Employee G) // Добавление элемента на позицию n
        {
            if (list == null)
            {
                Console.WriteLine("Список пустой");
                return null;
            }
            else
            {
                if (list.count < n)
                {
                    Console.WriteLine("Выход за пределы списка");
                    return null;
                }
                else
                {
                    if (n == 1)
                    {

                        OList LinksAfterN = list;
                        list = new OList { data = G, next = LinksAfterN };
                        list.count += 1;
                        return list;
                        //OList ListTmp = list;
                        //ListTmp.data = G;


                    }
                    else if (n == list.count)
                    {
                        OList ListTmp = list;
                        for (int i = 1; i < n; i++)
                        {
                            ListTmp = ListTmp.next;
                        }
                        ListTmp.next = new OList { data = G, next = null };
                        return list = ListTmp;
                    }
                    else
                    {
                        OList ListTmp = list; // Для запоминания n-го элемента
                        OList LinksAfterN = list; // Для запоминания связей после n-го элемента

                        for (int i = 0; i < n - 1; i++)
                        {
                            ListTmp = ListTmp.next; // Присваиваем ссылку на следующий элемент
                            LinksAfterN = ListTmp.next; // Присваиваем ссылку на элемент, который нужно запомнить
                        }

                        ListTmp.next = new OList { data = G, next = LinksAfterN };
                        list.count += 1;
                        return list = ListTmp;
                    }

                }

            }
        }


        public static OList Delete2(OList list) // удаление каждого второго объекта
        {

            if (list != null&&list.next!=null)
            {
                OList tmp = list;
                int size = list.count;
                for (int i = 1; i < size&&tmp!=null; i=i+2)
                {
                    //if (i%2==1)
                    //{
                        if (tmp.next.next == null)
                            tmp.next = null;
                        else
                        {
                            tmp.next = tmp.next.next;
                            list.count -= 1;
                        }
                    //}
                    tmp = tmp.next;

                    //tmp = tmp.next;
                }
                return list;
            }
            else
            {
                if (list.next == null)
                {
                    Console.WriteLine("Остался один элемент в списке");
                    return null;
                }
                else
                {
                    Console.WriteLine("Список пустой");
                    return null;
                }
                
            }
        }
    }
}
