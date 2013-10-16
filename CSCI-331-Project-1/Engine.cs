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
        private Board board;


        public Engine(Player p1, Player p2, int width = 7, int height = 6, int connectN = 4)
        {
            player1 = p1;
            player2 = p2;
            Width = width;
            Height = height;
            ConnectN = connectN;
            board = new Board(Width,Height,ConnectN);
        }

        public void playGame()
        {
            string winner = null;
            int move;
            while (true)
            {
                move = player1.getmove();
                board.insertPiece(move, new Piece("B"));
                Console.WriteLine(board.ToString());
                winner = board.checkWinner();
                player2.update(move);
                if (winner != null)
                {
                    Console.WriteLine(winner);
                    break;
                }



                move = player2.getmove();
                board.insertPiece(move, new Piece("W"));
                Console.WriteLine(board.ToString());
                winner = board.checkWinner();
                player1.update(move);
                if (winner != null)
                {
                    Console.WriteLine(winner);
                    break;
                }

            }
        }




    }
}
