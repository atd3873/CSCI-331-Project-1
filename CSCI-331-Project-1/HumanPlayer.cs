using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_331_Project_1
{
    class HumanPlayer : Player
    {

        public HumanPlayer(String name) {
            playername = name;
        }

        public override String getName(){

            return playername;
        }

        public override int getmove()
        {
           return  Convert.ToInt16(Console.ReadLine());
        }

        public override void update(int move)
        {
        }

    }
}
