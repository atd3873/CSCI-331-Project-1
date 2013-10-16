using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_331_Project_1
{
    class HumanPlayer : Player
    {
        public int getmove()
        {
           return  Convert.ToInt16(Console.ReadLine());
        }

        public void update(int move)
        {
        }

    }
}
