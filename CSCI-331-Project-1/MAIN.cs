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
            Board b = new Board();
            

            Console.WriteLine(b.ToString());

            b.insertPiece(6, new Piece("Y"));
            Console.WriteLine(b.ToString());
            Console.WriteLine(b.checkWinnerDiagBT());


            Console.ReadLine();
        }
    }
}
