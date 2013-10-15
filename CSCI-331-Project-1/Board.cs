using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_331_Project_1
{
    class Board
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int NumToWin { get; private set; }

        private Piece[,] _grid;


        public Board(int width = 7, int height = 6, int numToWin = 4)
        {
            Width = width;
            Height = height;
            NumToWin = numToWin;
            _grid = new Piece[Height, Width];
        }

        public Boolean insertPiece(int location, Piece pieceToPlace)
        {
            if (location >= Width)
            {
                return false;
            }

            //top of board is full
            if (_grid[0, location] != null)
            {
                return false;
            }

            //bottom of board is empty
            if (_grid[Height - 1, location] == null)
            {
                _grid[Height - 1, location] = pieceToPlace;
                return true;
            }

            for (int r = 1; r < Height; r++)
            {
                if (_grid[r, location] != null)
                {
                    _grid[r - 1, location] = pieceToPlace;
                    return true;
                }


            }




            return false;

        }





        public String checkWinner()
        {
            string verticalWinner = checkWinnerVertical();
            string horizontalWinner = checkWinnerHorizontal();
            string diagTBWinner = checkWinnerDiagTB();
            string diagBTWinner = checkWinnerDiagBT();
            string tie = checkTie();

            if (verticalWinner != null)
            {
                return verticalWinner;
            }
            if (horizontalWinner != null)
            {
                return horizontalWinner;
            }

            if (diagTBWinner != null)
            {
                return diagTBWinner;
            }
            if (diagTBWinner != null)
            {
                return diagTBWinner;
            }
            if (tie != null)
            {
                return tie;
            }
            return null;

        }


        public String checkWinnerVertical()
        {
            //returns the winner string if theres a winner if not it reurn null

            for (int c = 0; c < Width; c++)
            {
                for (int r = 0; r < Height + 1 - NumToWin; r++)
                {
                    string cur = null;
                    if (_grid[r, c] != null)
                    {
                        cur = _grid[r, c].Team;
                    }
                    int curCount = 0;
                    for (int off = 0; off < NumToWin; off++)
                    {
                        if ((_grid[r + off, c] != null) && (cur != null) && cur.Equals(_grid[r + off, c].Team))
                        {
                            curCount++;
                        }
                        if (curCount == NumToWin)
                        {
                            return cur + " won in column " + c;
                        }
                    }
                }
            }
            return null;
        }

        public String checkWinnerHorizontal()
        {
            //returns the winner string if theres a winner if not it reurn null
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width + 1 - NumToWin; c++)
                {
                    string cur = null;
                    if (_grid[r, c] != null)
                    {
                        cur = _grid[r, c].Team;
                    }
                    int curCount = 0;
                    for (int off = 0; off < NumToWin; off++)
                    {
                        if ((_grid[r, c + off] != null) && (cur != null) && cur.Equals(_grid[r, c + off].Team))
                        {
                            curCount++;
                        }
                        if (curCount == NumToWin)
                        {
                            return cur + " won in row " + r;
                        }
                    }
                }
            }
            return null;
        }

        public String checkWinnerDiagTB()
        {
            //returns the winner string if theres a winner if not it reurn null
            for (int r = 0; r < Height + 1 - NumToWin; r++)
            {
                for (int c = 0; c < Width + 1 - NumToWin; c++)
                {
                    string cur = null;
                    if (_grid[r, c] != null)
                    {
                        cur = _grid[r, c].Team;
                    }
                    int curCount = 0;
                    for (int off = 0; off < NumToWin; off++)
                    {
                        if ((_grid[r + off, c + off] != null) && (cur != null) && cur.Equals(_grid[r + off, c + off].Team))
                        {
                            curCount++;
                        }
                        if (curCount == NumToWin)
                        {
                            return cur + " won on a diagonal";
                        }
                    }
                }
            }
            return null;
        }

        public String checkWinnerDiagBT()
        {
            //returns the winner string if theres a winner if not it reurn null
            for (int r = NumToWin-1; r < Height; r++)
            {
                for (int c = 0; c < Width + 1 - NumToWin; c++)
                {
                    string cur = null;
                    if (_grid[r, c] != null)
                    {
                        cur = _grid[r, c].Team;
                    }
                    int curCount = 0;
                    for (int off = 0; off < NumToWin; off++)
                    {
                        if ((_grid[r - off, c + off] != null) && (cur != null) && cur.Equals(_grid[r - off, c + off].Team))
                        {
                            curCount++;
                        }
                        if (curCount == NumToWin)
                        {
                            return cur + " won on a diagonal";
                        }
                    }
                }
            }
            return null;
        }

        public String checkTie()
        {
            //returns that there was not a winner, if there are still empty spaces it retuns null
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width ; c++)
                {
                    if (_grid[r, c] == null)
                    {
                        return null;
                    }
                 
                 
                }
            }
            return "Its a tie, no one wins";
        }




        public override String ToString()
        {
            String s = "\n";
            String tmp = "";
            for (int r = 0; r < Height; r++)
            {
                tmp = "|";
                for (int c = 0; c < Width; c++)
                {

                    Piece piece = this._grid[r, c];
                    if (piece != null)
                    {
                        tmp = tmp + _grid[r, c].ToString() + "|";

                    }
                    else
                    {
                        tmp = tmp + " |";
                        //tmp = tmp + "(" + r + ", " + c + ")" + "|";
                    }
                }
                tmp = tmp + '\n';
                s = s + tmp;
            }
            //make bottom part 
            tmp = "";
            for (int c = 0; c < Width; c++)
            {
                tmp = tmp + "+-";
            }
            tmp = tmp + "+";
            s = s + tmp + '\n';
            return s;
        }





    }
}
