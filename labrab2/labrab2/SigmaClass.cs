using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab2
{

    [Unreadable]
    public class UnreadableClass
    {
        public int number;
        public string stroke;

        public UnreadableClass(int number, string stroke) { 
            this.number = number;
            this.stroke = stroke;

        }
    }

    [NotComparable]
    public class NotcomparableClass
    {
        public int number;
        public string stroke;

        public NotcomparableClass(int number, string stroke)
        {
            this.number = number;
            this.stroke = stroke;

        }
    }

    public class NormalClass
    {
        public int number;
        public string stroke;

        public NormalClass(int number, string stroke)
        {
            this.number = number;
            this.stroke = stroke;

        }
    }




}
