using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe BLineTCT = new TicTacToe();
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.WriteLine("\n******* Game of Tic-Tac-Toe*******\n");
            Console.WriteLine(" Developed By: Saroj Poudyal sarojpoudyal13@gmail.com");
            Console.Write("\n=================================================================================================");
            Console.WriteLine("\n\n Press any key to play or Press 'H' for help.");

            String input = Console.ReadLine().ToString();
            if (input.ToUpper() == "H")
            {
                //print help - Pulled from Wikipedia :)
                Console.Write("\n\n=====================================================================================================================================\n\n");
                Console.Write("\n Tic-tac-toe is a game for two players, X and O, who take turns marking their marks in a 3×3 grid.\n");
                Console.Write("\n The player who succeeds in placing three respective marks in a horizontal, vertical, or diagonal row wins the game.\n");
                Console.Write("\n The game supports one player playing against an automated computer player. The automated computer player picks moves at random --no A.I.\n");
                Console.Write("\n picture of the 3X3 grid displayed below:\n\n");

                BLineTCT.DrawBoard("Help");

                Console.Write("\n\n=====================================================================================================================================\n\n");

                Console.Write("\n  Press any key to play the game. \n");
                Console.ReadLine();
            }
            Console.Clear();
            Console.Write("\n Enter your Name:");
            BLineTCT.humanName = Console.ReadLine().ToString();
            if (BLineTCT.humanName == "")
                BLineTCT.humanName = "Human";

            Console.Write("\n\n {0} since you are human, you always get to go first, pick Nought (O) or Cross (X) as your sign.", BLineTCT.humanName);
            Console.Write("\n\n Press 'O' for Nought (O) or 'X' for Cross (X): ");
            input = Console.ReadLine().ToString();
            while (input.ToUpper() != "O" && input.ToUpper() != "X")
            {
                Console.Write("\n Wrong input, you can only pick 'O' or 'X', Try again: ");
                input = Console.ReadLine().ToString();
            }

            BLineTCT.humanSign = input.ToUpper().ToCharArray()[0];
            if (input.ToUpper() == "O")
                BLineTCT.computerSign = 'X';
            else
                BLineTCT.computerSign = 'O';

            BLineTCT.WinnerFound = false;
            while (!BLineTCT.WinnerFound)
            {
                Console.Clear();
                BLineTCT.DrawBoard("Help");
                if (!BLineTCT.WinnerFound)
                {
                    BLineTCT.HumanMove();
                }
                if (!BLineTCT.WinnerFound)
                {
                    BLineTCT.ComputerMove();
                }
            }
            Console.WriteLine(" Game over.Press any key to continue.");
            Console.ReadLine();
        }
    }
}
