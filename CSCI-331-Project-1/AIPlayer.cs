using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSCI_331_Project_1
{
    class AIPlayer : Player
    {

        

        public AIPlayer(String n) {

            playername = n;
        }

        public AIPlayer(String n, Board b, Piece c) {
            playername = n;
            board = b;
            chip = c;
        }

        public override String getName()
        {
            return playername;
        }

        public override int getmove() {

            return board.CPUMove(chip, board._grid);
            
        }

        public override void update(int move) { 
        
        
        }
    }
}
