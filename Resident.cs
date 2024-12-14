using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Tumakov_dop
{
    internal class Resident
    {
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public Problem Problem { get; set; }
        public int TemperamentScandalousness { get; set; }
        public bool TemperamentSmart { get; set; }

        public Resident(string name, string passportNumber, Problem problem, int temperamentScandalousness, bool temperamentSmart)
        {
            Name = name;
            PassportNumber = passportNumber;
            Problem = problem;
            TemperamentScandalousness = temperamentScandalousness;
            TemperamentSmart = temperamentSmart;
        }
    }
}
