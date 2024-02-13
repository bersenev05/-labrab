using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab1
{
    public class SEStudent
    {
        public string FIO { get; set; }
        public string ProgrammingLanguage { get; set; }
        public override string ToString()
        {
            return FIO + ". Знает " + ProgrammingLanguage;
        }
    }
}
