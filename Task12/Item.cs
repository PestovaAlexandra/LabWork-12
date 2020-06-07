using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary10;

namespace Task12
{
    public class Item: IEquatable<Object>
    {
        // Ключ.
        public int Key { get; private set; }

        // Хранимые данные.
        public Employee Value { get; private set; }

        /// Создать новый экземпляр хранимых данных Item.
        public Item()
        {
            Employee one = new Employee();
            Key = one.GetHashCode();
            Value = one;
        }
        public Item(Employee one)
        {
            Key = one.GetHashCode();
            Value = one;
        }
        /// Приведение объекта к строке.
        /// <returns> Ключ объекта. </returns>
        public override string ToString()
        {
            return Key.ToString();
        }
        public override bool Equals(Object obj)
        {
            try
            {
                Item g = (Item)obj;
                return (g.Value.Name == this.Value.Name && g.Value.Age == this.Value.Age && g.Value.Experience == this.Value.Experience);
            }
            catch
            {
                return false;
            }


        }
    }
}
