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

            Player p1;
            Player p2;

            //Need to put in some user input to choose between Human and AI players

            Console.WriteLine("Player 1: Human or AI? ");
            String response1 = Console.ReadLine();
            Console.WriteLine("Name: ");
            String playername1 = Console.ReadLine();

            if (response1 == "AI")
            {   
                p1 = new AIPlayer(playername1);
            }
            else 
            {
                p1 = new HumanPlayer(playername1);
            }

            Console.WriteLine("Player 2: Human or AI? ");
            String response2 = Console.ReadLine();
            Console.WriteLine("Name: ");
            String playername2 = Console.ReadLine();
            if (response2 == "AI")
            {
                p2 = new AIPlayer(playername2);
            }
            else
            {
                p2 = new HumanPlayer(playername2);
            }

            Engine e = new Engine(p1, p2);
            Console.WriteLine("Game starting...");
            e.playGame(p1, p2);
            Console.ReadLine();
        }
    }
}
