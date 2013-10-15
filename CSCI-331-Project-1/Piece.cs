using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_331_Project_1
{
    class Piece
    {
        public String Team { get; private set; }

        public Piece(String team)
        {
            Team = team;
        }
        public override string ToString()
        {
            return Team;
        }

    }
}
