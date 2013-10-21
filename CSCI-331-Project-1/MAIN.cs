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


            Console.WriteLine("Test or Play");
            String answer = Console.ReadLine();


            if (answer != "Play")
            {
                int P1_Wins = 0;
                int P2_Wins = 0;
                int Draws = 0;

                Console.WriteLine("Number of Games?");
                int num_games = Convert.ToInt32(Console.ReadLine());

                p1 = new AIPlayer("AI1");
                p2 = new AIPlayer("AI2");
                p2.random = true;
                Engine e = new Engine(p1, p2);

                for (int i = 0; i < num_games; i++) {

                    int result = e.playGame(p1, p2);
                    switch (result) { 
                    
                        case 0:
                            Draws++;
                            break;
                        case 1:
                            P1_Wins++;
                            break;
                        case 2:
                            P2_Wins++;
                            break;
                    }
                
                }

                Console.WriteLine("Smart AI Wins: " + P1_Wins + " Win Percentage: "+P1_Wins / num_games);
                Console.WriteLine("Random AI Wins: " + P2_Wins + " Win Percentage: " + P2_Wins / num_games);
                Console.WriteLine("Draws: " + Draws + " Draw Percentage: " + Draws / num_games);
                Console.ReadLine();


            }
            else {

                Console.WriteLine("Player 1: Human or AI? ");
                String response1 = Console.ReadLine();
                Console.WriteLine("Name: ");
                String playername1 = Console.ReadLine();

                if (response1 == "AI")
                {

                    p1 = new AIPlayer(playername1);
                    Console.WriteLine("Random? (Y/N)");
                    String input = Console.ReadLine();
                    if (input == "Y" || input == "y")
                    {
                        p1.random = true;
                    }

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

                    Console.WriteLine("Random? (Y/N)");
                    String input = Console.ReadLine();
                    if (input == "Y" || input == "y")
                    {
                        p2.random = true;
                    }
                }
                else
                {
                    p2 = new HumanPlayer(playername2);
                }

                Engine e = new Engine(p1, p2);
                Console.WriteLine("Game starting...");
                e.playGame(p1, p2);
                Console.WriteLine("Press Any Key to Exit.");
                Console.ReadLine();
            
            
            }


            
        }
    }
}
