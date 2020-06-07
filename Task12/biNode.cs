using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class biNode
    {
        public biNode Next { get; set; }
        public biNode Prev { get; set; }
        public MyClassLibrary10.Employee Data { get; set; }

        public biNode(MyClassLibrary10.Employee data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}
