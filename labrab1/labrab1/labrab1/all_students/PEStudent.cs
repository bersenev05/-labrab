using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab1
{
    public class PEStudent
    {
        public string FIO { get; set; }
        public string SportDiscipline { get; set; }

        public override string ToString()
        {
            return FIO + " " + SportDiscipline;
        }
    }
}
