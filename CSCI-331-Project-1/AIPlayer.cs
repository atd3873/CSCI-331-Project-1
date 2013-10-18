using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_331_Project_1
{
    class AIPlayer : Player
    {

        public AIPlayer(String name) {
            playername = name;
        }

        public override String getName()
        {
            return playername;
        }

        public override int getmove() {



            

            return 0;
        }

        public override void update(int move) { 
        
        
        }
    }
}
