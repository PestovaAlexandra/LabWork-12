using MyClassLibrary10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    public class MyCollection<T>: IDictionaryEnumerator
    {
        public Object Key
        {
            get
            {
                for (int i = 0; i < items[index].Count; i++)
                {
                    return items[index][i].Key;
                }
                return 0;
            }

        }

        public Object Value
        {
            get
            {
                for (int i = 0; i < items[index].Count; i++)
                {
                    return items[index][i].Value;
                }
                return 0;
            }
        }
        public DictionaryEntry Entry
        {
            get { return (DictionaryEntry)Current; }

        }
        public Object Current
        {
            get
            {
                ValidateIndex();
                return items[index];
            }
        }
        private void ValidateIndex()
        {
            if (index < 0 || index >= items.Count)
                throw new InvalidOperationException("Enumerator is before or after the collection.");
        }
        public void Reset()
        {
            index = -1;
        }
        public Boolean MoveNext()
        {
            if (index < items.Count - 1) { index++; return true; }
            return false;
        }
        public IDictionaryEnumerator GetEnumerator()
        {
            // Construct and return an enumerator.
            return items.GetEnumerator();
        }
        IDictionaryEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public Dictionary<int, List<Item>> items;
        int count;
        int index;
        public MyCollection()
        {
            items = new Dictionary<int, List<Item>>();
            count = 0;
        }
        public MyCollection(int capacity)
        {
            items = null;
            count = capacity;
        }
        public MyCollection(Dictionary<int, List<Item>> c)
        {
            items = c;
        }
        public int Count
        {
            get
            {
                return count;
            }
            private set
            {
                count = value;
            }
        }
        /// Коллекция хранимых данных в хеш-таблице в виде пар Хеш-Значения.
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => items?.ToList()?.AsReadOnly();

        /// Создать новый экземпляр класса HashTable.
        //public MyCollection()
        //{
        //    // Инициализируем коллекцию максимальным количество элементов.
        //    items = new Dictionary<int, List<Item>>(maxSize);
        //}

        /// Добавить данные в хеш таблицу.
        ///// <param name="key"> Ключ хранимых данных. </param>
        //    /// <param name="value"> Хранимые данные. </param>
        public void InsertRandom(int сcount)//вставка рандомного объекта
        {
            for (int i = 0; i < сcount; i++)
            {

                // Создаем новый экземпляр данных.
                Item item = new Item();

                // Получаем хеш номер
                int hash = item.Value.GetHashCode();

                // Получаем коллекцию элементов с таким же хешем ключа.
                // Если коллекция не пустая, значит заначения с таким хешем уже существуют,
                // следовательно добавляем элемент в существующую коллекцию.
                // Иначе коллекция пустая, значит значений с таким хешем ключа ранее не было,
                // следовательно создаем новую пустую коллекцию и добавляем данные.
                List<Item> hashTableItem = null;
                if (items.ContainsKey(hash))
                {
                    // Получаем элемент хеш таблицы(список с данным хеш кодом)
                    hashTableItem = items[hash];

                    // Проверяем наличие внутри коллекции значения с полученным ключом.
                    // Если такой элемент найден, то сообщаем об ошибке.
                    bool check = false;
                    check = hashTableItem.Contains(item);
                    
                    // Добавляем элемент данных в коллекцию элементов хеш таблицы.
                    items[hash].Add(item);
                    count++;
                }
                else
                {
                    // Создаем новую коллекцию. Сразу же с элементом
                    hashTableItem = new List<Item>();
                    hashTableItem.Add(item);

                    // Добавляем данные в таблицу.
                    items.Add(hash, hashTableItem);

                    count++;
                }
            }
        }
        public void Insert(Employee value)
        {
            // Создаем новый экземпляр данных.
            Item item = new Item(value);

            // Получаем хеш ключа
            int hash = item.Value.GetHashCode();

            // Получаем коллекцию элементов с таким же хешем ключа.
            // Если коллекция не пустая, значит заначения с таким хешем уже существуют,
            // следовательно добавляем элемент в существующую коллекцию.
            // Иначе коллекция пустая, значит значений с таким хешем ключа ранее не было,
            // следовательно создаем новую пустую коллекцию и добавляем данные.
            List<Item> hashTableItem = null;
            if (items.ContainsKey(hash))
            {
                // Получаем элемент хеш таблицы.
                hashTableItem = items[hash];

                // Проверяем наличие внутри коллекции значения с полученным ключом.
                // Если такой элемент найден, то сообщаем об ошибке.
                bool check = false;
                check = hashTableItem.Contains(item);
                
                // Добавляем элемент данных в коллекцию элементов хеш таблицы.
                items[hash].Add(item);
                count++;
            }
            else
            {
                // Создаем новую коллекцию.
                hashTableItem = new List<Item> { item };

                // Добавляем данные в таблицу.
                items.Add(hash, hashTableItem);
                count++;
            }
        }

        /// Удалить данные из хеш таблицы по ключу.
        /// <param name="key"> Ключ. </param>

        public void Delete(int n)//Удалить несколько элементов по ключу
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("1. Удалить по значению");
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        //case 1:
                        //    {
                        //        Console.WriteLine("Введите ключ");
                        //        int key = int.Parse(Console.ReadLine());
                        //        DeleteOneOnKey(key);
                        //    }
                        //    break;
                        case 1:
                            {
                                Console.WriteLine("Введите значение");
                                Console.WriteLine("Введите имя");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите возраст");
                                int age = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите стаж");
                                int exp = int.Parse(Console.ReadLine());

                                Employee one = new Employee(name, age, exp);

                                Item item = new Item(one);

                                DeleteOneOnValue(item);
                            }
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Введите 1 или 2");
                }
            }
        }
        public void DeleteOneOnValue(Item one)

        {
            // Получаем хеш ключа.
            int hash = one.Key;

            // Если значения с таким хешем нет в таблице, 
            // то завершаем выполнение метода.
            if (!items.ContainsKey(hash))
            {
                Console.WriteLine("Такого элемента в хеш-таблице нет");
                return;
            }

            // Получаем коллекцию элементов по хешу ключа.
            List<Item> hashTableItem = items[hash];

            // Получаем элемент коллекции по ключу.
            T item;
            bool check = false;

            check = hashTableItem.Contains(one);

            // Если элемент коллекции найден, 
            // то удаляем его из коллекции.
            if (check)
            {
                hashTableItem.Remove(one);
                Console.WriteLine("Элемент удален");
                if (hashTableItem.Count == 0)
                    items.Remove(hash);
                count--;
            }
            else
            {
                Console.WriteLine("Элемент не найден.");
            }

        }
        //public void DeleteOneOnKey(int key)

        //{
        //    // Получаем хеш ключа.
        //    int hash = key;

        //    // Если значения с таким хешем нет в таблице, 
        //    // то завершаем выполнение метода.
        //    if (!items.ContainsKey(hash))
        //    {
        //        return;
        //    }

        //    // Получаем коллекцию элементов по хешу ключа.
        //    List<Item> hashTableItem = items[hash];

        //    // Получаем элемент коллекции по ключу.
        //    Item item = hashTableItem.SingleOrDefault(i => i.Key == key);

        //    // Если элемент коллекции найден, 
        //    // то удаляем его из коллекции.
        //    if (item != null)
        //    {
        //        hashTableItem.Remove(item);
        //        Console.WriteLine("Элемент удален");
        //        count--;

        //    }
        //    else
        //    {
        //        Console.WriteLine("Элемент не найден.");
        //    }
        //}

        
        public bool Search(Item one)
        {
            // Получаем хеш ключа.
            int hash = one.Key;

            // Если таблица не содержит такого хеша,
            // то завершаем выполнения метода вернув null.
            if (!items.ContainsKey(hash))
            {
                return false;
            }

            // Если хеш найден, то ищем значение в коллекции по ключу.
            List<Item> hashTableItem = items[hash];

            // Если хеш найден, то ищем значение в коллекции по ключу.
            if (hashTableItem != null)
            {
                // Получаем элемент коллекции по ключу.
                bool check = false;
                check = hashTableItem.Contains(one);

                // Если элемент коллекции найден, 
                // то возвращаем true.
                if (check)
                {
                    return true;
                }
            }

            // Возвращаем false если ничего найдено.
            return false;
        }
        public void Clear()             // Удаление хеш-таблицы
        {
            items.Clear();
            Console.WriteLine("Все элементы удалены");
        }
        public void AllCopy(Dictionary<int, List<Item>> first, ref Dictionary<int, List<Item>>  second)  // Полное клонирование словаря
        {
            
            foreach (int key in first.Keys)
            {
                second.Add(key, first[key]);
            }
        }
        public static void ShowHashTable(MyCollection<T> hashTable, string title)
        {
            // Выводим все имеющие пары хеш-значение
            Console.WriteLine(title);
            foreach (KeyValuePair<int,List<Item>> item in hashTable.Items)
            {
                // Выводим хеш
                Console.WriteLine(item.Key);

                // Выводим все значения хранимые под этим хешем.
                foreach (Item value in item.Value)
                {
                    Console.WriteLine($"\t{value.Key} - {value.Value}");
                }
            }
            Console.WriteLine();
        }
    }

}



