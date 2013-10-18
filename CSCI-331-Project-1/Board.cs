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

        public Piece[,] _grid;

        //public int[,] board = new int[,] {{0,0,0,0,0,0,0},{0,0,0,0,0,0,0},{0,0,0,0,0,0,0},{0,0,0,0,0,0,0},{0,0,0,0,0,0,0},{0,0,0,0,0,0,0}};


        public Board(int width = 7, int height = 6, int numToWin = 4)
        {
            Width = width;
            Height = height;
            NumToWin = numToWin;
            _grid = new Piece[Height, Width];
        }

        public Boolean insertPiece(int location, Piece pieceToPlace, Piece[,]board)
        {
            if (location >= Width)
            {
                return false;
            }

            //top of board is full
            if (board[0, location] != null)
            {
                return false;
            }

            //bottom of board is empty
            if (board[Height - 1, location] == null)
            {
                board[Height - 1, location] = pieceToPlace;
                return true;
            }

            for (int r = 1; r < Height; r++)
            {
                if (board[r, location] != null)
                {
                    board[r - 1, location] = pieceToPlace;
                    return true;
                }
            }

            return false;

        }


        public int CPUMove(Piece chip, Piece[,] board){
        
            List<int> moves = PossibleMoves(board);
            for(var i = 0; i<moves.Count(); i++){
		        var move = moves[i];
		        if(CheckForWin(board,chip, move)){
			        return move;
		        }	
		        if(CheckForWin(board,new Piece(chip.Opponent, chip.Team), move)){
			        return move;
		        }	
	        }

            if (board[5, 3] == null) { return 3; }
            else {

                Random random = new Random();
                int randomnumber = random.Next(0, moves.Count());

                return randomnumber;
            
            }

        
        }


        public List<int> PossibleMoves(Piece[,] board) {

            List<int> moves = new List<int>();

            for(int col=0; col<7; col++){
		        
			        if(board[5,col] == null){int move=col; moves.Add(move);break;}	
		        
	        }

            return moves;
        }

        public Piece[,] copyGrid(){
        
            Piece[,] tempboard = new Piece[Height, Width];
            
            for(int col = 0; col < Width; col++){
            
                for(int row = 0; row<Height; row++){
                
                    tempboard[row,col] = _grid[row,col];
                }
            }
            return tempboard;
        
        }


        public Boolean CheckForWin(Piece[,] board, Piece chip, int move){
        
            Piece[,] tempboard = copyGrid();

            insertPiece(move, chip, tempboard);

            Boolean win = checkWinner(tempboard);

            if (win) { return true; } else { return false; }
        
        }


        public Boolean checkWinner(Piece[,] board)
        {
            if (checkWinnerVertical(board) ||
                checkWinnerHorizontal(board) ||
                checkWinnerDiagTB(board) ||
                checkWinnerDiagBT(board))
            {

                return true;
            }
            else {
                return false;
            }
        }


        public Boolean checkWinnerVertical(Piece[,] board)
        {
            //returns the winner string if theres a winner if not it reurn null

            for (int c = 0; c < Width; c++)
            {
                for (int r = 0; r < Height + 1 - NumToWin; r++)
                {
                    string cur = null;
                    if (board[r, c] != null)
                    {
                        cur = board[r, c].Team;
                    }
                    int curCount = 0;
                    for (int off = 0; off < NumToWin; off++)
                    {
                        if ((board[r + off, c] != null) && (cur != null) && cur.Equals(board[r + off, c].Team))
                        {
                            curCount++;
                        }
                        if (curCount == NumToWin)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Boolean checkWinnerHorizontal(Piece[,] board)
        {
            //returns the winner string if theres a winner if not it reurn null
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width + 1 - NumToWin; c++)
                {
                    string cur = null;
                    if (board[r, c] != null)
                    {
                        cur = board[r, c].Team;
                    }
                    int curCount = 0;
                    for (int off = 0; off < NumToWin; off++)
                    {
                        if ((board[r, c + off] != null) && (cur != null) && cur.Equals(board[r, c + off].Team))
                        {
                            curCount++;
                        }
                        if (curCount == NumToWin)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Boolean checkWinnerDiagTB(Piece[,] board)
        {
            //returns the winner string if theres a winner if not it reurn null
            for (int r = 0; r < Height + 1 - NumToWin; r++)
            {
                for (int c = 0; c < Width + 1 - NumToWin; c++)
                {
                    string cur = null;
                    if (board[r, c] != null)
                    {
                        cur = board[r, c].Team;
                    }
                    int curCount = 0;
                    for (int off = 0; off < NumToWin; off++)
                    {
                        if ((board[r + off, c + off] != null) && (cur != null) && cur.Equals(board[r + off, c + off].Team))
                        {
                            curCount++;
                        }
                        if (curCount == NumToWin)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Boolean checkWinnerDiagBT(Piece[,] board)
        {
            //returns the winner string if theres a winner if not it reurn null
            for (int r = NumToWin-1; r < Height; r++)
            {
                for (int c = 0; c < Width + 1 - NumToWin; c++)
                {
                    string cur = null;
                    if (board[r, c] != null)
                    {
                        cur = board[r, c].Team;
                    }
                    int curCount = 0;
                    for (int off = 0; off < NumToWin; off++)
                    {
                        if ((board[r - off, c + off] != null) && (cur != null) && cur.Equals(board[r - off, c + off].Team))
                        {
                            curCount++;
                        }
                        if (curCount == NumToWin)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        //If the board is full return tie string, else return null

        public Boolean checkTie(Piece[,] board)
        {
            //returns that there was not a winner, if there are still empty spaces it retuns null
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width ; c++)
                {
                    if (board[r, c] == null)
                    {
                        return false;
                    }
                 
                 
                }
            }
            return true;
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
