using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_331_Project_1
{
    class Engine
    {

        private Player player1;
        private Player player2;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int ConnectN { get; private set; }
        public Board board;


        public Engine(Player p1, Player p2, int width = 7, int height = 6, int connectN = 4)
        {
            player1 = p1;
            player2 = p2;
            Width = width;
            Height = height;
            ConnectN = connectN;
            board = new Board(Width,Height,ConnectN);
        }

        public void playGame(Player p1, Player p2)
        {
            Boolean winner = false;
            int move;
            
            Console.WriteLine(board.ToString());

            //Need to choose randomly who goes first.
            Random random = new Random();
            int randomnumber = random.Next(1, 3);

            while (true)
            {
                Player first;
                Player second;

                if (randomnumber == 1)
                {
                    //Player 1 goes first
                    first = player1;
                    second = player2;
                }
                else {
                    //Player 2 goes first
                    first = player2;
                    second = player1;
                }

                if (first is HumanPlayer) { Console.WriteLine(first.playername + ", Please choose a slot (0-6) to drop your chip:"); }
                else { Console.WriteLine(first.playername + "moves..."); }
                move = first.getmove();
                board.insertPiece(move, new Piece("B"), board._grid);
                Console.WriteLine(board.ToString());
                winner = board.checkWinner(board._grid);
                first.update(move);
                if (winner == true)
                {
                    Console.WriteLine(first.playername + "Won!");
                    break;
                }

                if (second is HumanPlayer) { Console.WriteLine(second.playername+", Please choose a slot (0-6) to drop your chip:"); }
                else { Console.WriteLine(second.playername + "moves..."); }
                move = second.getmove();
                board.insertPiece(move, new Piece("W"), board._grid);
                Console.WriteLine(board.ToString());
                winner = board.checkWinner(board._grid);
                second.update(move);
                if (winner == true)
                {
                    Console.WriteLine(second.playername + "Won!");
                    break;
                }

            }
        }




    }
}
