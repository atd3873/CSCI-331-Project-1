using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_331_Project_1
{
    class MAIN
    {
        static void Main(string[] args)
        {

            Player p1 = new HumanPlayer();
            Player p2 = new HumanPlayer();

            Engine e = new Engine(p1, p2);
            Console.WriteLine("game starting");
            e.playGame();
            Console.ReadLine();
        }
    }
}
