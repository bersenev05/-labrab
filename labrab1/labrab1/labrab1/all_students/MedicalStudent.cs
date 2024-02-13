using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab1
{
    public class MedicalStudent
    {
        public string Name { get; set; }
        public string Specialization { get; set; }

        public override string ToString()
        {
            return Name + " " + Specialization;
        }
    }
}
