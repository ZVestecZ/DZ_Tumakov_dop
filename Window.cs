using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Tumakov_dop
{
    internal class Window
    {
        public int WindowNumber { get; }
        public Queue<Resident> Queue { get; } = new Queue<Resident>();
        public Window(int windowNumber)
        {
            WindowNumber = windowNumber;
        }
    }
}
