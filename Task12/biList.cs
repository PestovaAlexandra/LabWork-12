using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class biList
    {
        biNode head;
        biNode tail;
        int count;
        public void Create(int l) // Создаём двунаправленный список
        {
            biNode node = null;//новый элемент
            for (int i = 0; i < l; i++) //сколько элементов добавить
            {
                if (i % 2 == 0)
                {
                    node = new biNode(new MyClassLibrary10.Worker());
                }
                else if (i % 3 == 0)
                {
                    node = new biNode(new MyClassLibrary10.Engneer());
                }
                else
                {
                    node = new biNode(new MyClassLibrary10.Employee());
                }

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    node.Prev = tail;
                }
                tail = node;
                count++;
            }
        }
        //Добавить в список элемент с заданным номером
        public void AddNode(int number)
        {
            biNode p;
            biNode tmp = this.head;
            if (tmp==null)
            {
                tmp = new biNode(new MyClassLibrary10.Worker());
                this.head = tmp;
                return;
            }
            if(this.count<number)
            {
                p = new biNode(new MyClassLibrary10.Worker());
                this.tail.Next = p;
                p.Prev = this.tail;
                p.Next = null;
                this.tail = p;
                return;
            }
            if (this.count >= number)
            {
                p = new biNode(new MyClassLibrary10.Worker());

                if(number==1)
                {
                    p.Next = this.head;
                    this.head.Prev = p;
                    p.Prev = null;
                    this.head = p;
                    return;
                }
                
                for (int i=1;i<number-1;i++)
                {
                    tmp = tmp.Next;
                }
                p.Next = tmp.Next;
                tmp.Next = p;
                p.Prev = tmp;
                if(p.Next!=null)
                p.Next.Prev = p;
            }
        }
        // Печать списка
        public static void WriteList(biList list)
        {
            if (list == null)
                Console.WriteLine("Пусто");
            else
            {
                biNode tmp = list.head;
                while (tmp != null)
                {
                    tmp.Data.PrintInfo();
                    tmp = tmp.Next;
                }
            }
        }
    }
}
