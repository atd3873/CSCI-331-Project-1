using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCI_331_Project_1
{
    abstract class Player
    {

        public String playername;
        public Board board;
        public Piece chip;


        abstract public String getName();

        abstract public int getmove();

        abstract public void update(int move);
    }
}
