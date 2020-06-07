using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary10;

namespace Task12
{
    public class TreeNode
    {
        public Employee data;
        public TreeNode left;
        public TreeNode right;
        public Employee Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }


        public TreeNode(int data)
        {
            this.Data.Age = data;
        }
        public TreeNode(Employee data)
        {
            this.Data = data;
        }

        public TreeNode()
        {
            this.Data = new Employee();
        }

        /*}*/                             // Локальный класс узла дерева
        static Queue<Employee> queueValue = new Queue<Employee>(); // Хранит значения дерева
        static int k = 0;                                    // Для хранения количества элементов с ценой выше 500

        public static TreeNode IdealTree(int size, TreeNode root)
        {
            TreeNode r = new TreeNode();
            int nl;
            int nr;
            if (size == 0)
            {
                root = null;
                return root;
            }
            nl = size / 2;
            nr = size - nl - 1;
            r.Left = IdealTree(nl, r.Left);
            r.Right = IdealTree(nr, r.Right);
            return r;
        }
       
        protected static void TakeValue(TreeNode t)                // Собираем значения с дерева в очередь
        {
            if (t != null)
            {
                queueValue.Enqueue(t.Data);

                TakeValue(t.Left);
                
                TakeValue(t.Right);
            }
        }

        public static void ShowTree(TreeNode p, int l)
        {
            if (p != null)
            {
                ShowTree(p.Right, l + 3);//переход к правому поддереву
                                        //формирование отступа
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.Data.Age.ToString());//печать узла
                ShowTree(p.Left, l + 3);//переход к левому поддереву
            }
        }
        public static TreeNode CreateSearchTree(TreeNode root, TreeNode idealTree)
        {
            queueValue.Clear();

            TakeValue(idealTree);
            
            int j = 0;
            int size = queueValue.Count;
            root = new TreeNode(queueValue.Dequeue());
            for (j=1;j<size;j++)
            {
                Add(ref root, queueValue.Dequeue());
            }

            return root;
        }

        static void Add(ref TreeNode root, Employee d)//добавление элемента в дерево поиска
        {
            TreeNode p = root; //корень дерева
            TreeNode r = null;
            //флаг для проверки существования элемента d в дереве
            bool ok = false;
            if (root==null)
            {

                r = new TreeNode(d);
                //return root;
                return;
            }
            while (p != null && !ok)
            {
                r = p;
                //элемент уже существует
                if (d.Age == p.Data.Age) 
                    ok = true;
                else
            if (d.Age < p.Data.Age)
                    p = p.Left; //пойти в левое поддерево
                else p = p.Right; //пойти в правое поддерево
            }
            if (ok) return /*p*/;//найдено, не добавляем
                             //создаем узел
            TreeNode NewPoint = new TreeNode(d);//выделили память
                                          // если d<r.key, то добавляем его в левое поддерево
            if (d.Age < r.Data.Age) r.Left = NewPoint;
            // если d>r.key, то добавляем его в правое поддерево
            else r.Right = NewPoint;
            //return root;
        }
        public static int min = 101;
        public static int SearchMin(TreeNode p)
        {
            
            if (p != null)
            {
                SearchMin(p.Left);//переход к левому поддереву
                                        //формирование отступа
                if (p.Data.Age<min)
                    min=p.Data.Age;
                SearchMin(p.Right);//переход к правому поддереву
            }
            return min;
        }
    }
}
