using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        char[,] grid = new char[3, 3]; //can make it dynamic by letting user pick the board size, but since its tictac, made it static 3X3
        public string humanName;
        public char humanSign; //player 1's symbol, since always get to go first
        public char computerSign;
        public bool WinnerFound;

        //Method to instruct player 1 to make move
        public void HumanMove()
        {
            Console.WriteLine(" {0} enter X,Y coordinates for your move.", humanName);
            Console.Write("\n  Enter X coordinate: ");

            int xCoordinate = CollectInput();
            Console.Write("\n  Enter Y coordinate: ");
            int yCoordinate = CollectInput();

            if ((grid[xCoordinate, yCoordinate] != humanSign) && (grid[xCoordinate, yCoordinate] != computerSign))
            {
                grid[xCoordinate, yCoordinate] = humanSign;
                DrawBoard("");
            }
            else
            {
                Console.WriteLine("\n ******** Invalid move ********\n\n");
                Console.WriteLine("\n Slot ({0},{1}) is already field, try another slot\n\n", xCoordinate, yCoordinate);
                HumanMove();
            }

            //check for a winner after every move
            if (CheckWinner(humanSign))
            {
                Console.Clear();
                Console.WriteLine(" \n ***{0} YOU ARE THE WINNER***\n", humanName);
                DrawBoard("");
                WinnerFound = true;
            }
        }

        //Automatic logic for computer to make an auto move.
        //As per instuructions, no AI logic implemented, the computer pick the vaccant slot at random
        //The improvement on this method could be to use Probablity analysis at every vaccant slot and make a move on the slot with the highest Probablity
        public void ComputerMove()
        {
            //Random Number generator between 0 and 2
            Random random = new Random();
            int randomXCordinate = random.Next(3);
            int randomYCordinate = random.Next(3);

            //No AI logic here, the coordinates are picked at random, if it fits, it SITS :)
            if ((grid[randomXCordinate, randomYCordinate] != computerSign) && (grid[randomXCordinate, randomYCordinate] != humanSign))
            {
                grid[randomXCordinate, randomYCordinate] = computerSign;
                Console.WriteLine("Computer is making its move. Please Wait.");
                for (int ticks = 0; ticks < 5; ticks++)
                {
                    System.Threading.Thread.Sleep(500);
                    Console.Write(".......");
                }

                DrawBoard("");
            }
            else
            {
                ComputerMove();
            }
            //check for a winner after every move
            if (CheckWinner(computerSign))
            {
                Console.Clear();
                Console.WriteLine("\n***Sorry {0} YOU Loose.***\n", humanName);
                DrawBoard("");
                WinnerFound = true;
            }
        }

        //Method to display moves on the tic tac toe grid.
        public void DrawBoard(string type)
        {
            if (type == "Help")
            {
                Console.Write("\n\n");
                for (int rows = 0; rows < 3; rows++)
                {
                    int col = 0;
                    Console.WriteLine("\t\t\t ({0},{1}) | ({0},{2}) | ({0},{3}) ", rows, col, col + 1, col + 2);
                    if (rows != 2)
                        Console.WriteLine("\t\t\t-------|-------|-------");
                }
                Console.Write("\n\n-----------------------------------------------------------------------");
                Console.Write("\n {0}: {1} Computer: {2}", humanName, humanSign, computerSign);
                Console.Write("\n-----------------------------------------------------------------------");
                Console.Write("\n\n");
            }

            for (int rows = 0; rows < 3; rows++)
            {
                Console.WriteLine("\t\t\t {0} | {1} | {2} ", grid[rows, 0], grid[rows, 1], grid[rows, 2]);
                if (rows != 2)
                    Console.WriteLine("\t\t\t---|---|---");
            }
            Console.Write("\n\n");

        }

        public int CollectInput()
        {
            try
            {
                string input = Console.ReadLine().ToString();
                while (!ValidateInput(input))
                {
                    input = Console.ReadLine().ToString();
                }
                return Convert.ToInt32(input);
            }
            catch
            {
                return -1;
            }

        }
        public bool ValidateInput(String input)
        {
            try
            {
                int cordinate = Convert.ToInt32(input);
                if (cordinate < 0 || cordinate > 2)
                {
                    Console.WriteLine("\nWrong input. Only numbers from 0 - 2 are allowed as input.Enter again: ");
                    return false;
                }
                else return true;
            }
            catch
            {
                Console.WriteLine("\nWrong input. Only numbers from 0 - 2 are allowed as input.Enter again: ");
                return false;
            }

        }
        //Method to determine if you or computer won
        //three ways to win, at last also check to see if all the slots are filled, if yes then it is a DRAW.
        //(1)Diagnal, 
        //(2) Rows or
        //(3) Columns
        public bool CheckWinner(char playerSign)
        {
            //check for the match being ended in a draw
            //check Diagonals
            if ((grid[0, 0] == playerSign && grid[1, 1] == playerSign && grid[2, 2] == playerSign) ||
                (grid[0, 2] == playerSign && grid[1, 1] == playerSign && grid[2, 0] == playerSign))
            {
                return true;
            }

            //check rows
            for (int rows = 0; rows < 3; rows++)
            {
                if (grid[rows, 0] == playerSign && grid[rows, 1] == playerSign && grid[rows, 2] == playerSign)
                {
                    return true;
                }
            }

            //check columns
            for (int column = 0; column < 3; column++)
            {
                if (grid[0, column] == playerSign && grid[1, column] == playerSign && grid[2, column] == playerSign)
                {
                    return true;
                }
            }
            //check for the match being ended in a draw
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (grid[row, column] != 'X' && grid[row, column] != 'O')
                    {
                        return false;
                    }
                }
            }
            //If we reach at this level, then all the slots in the tictactoe grid are full, 
            //The game is a draw. 
            Console.Clear();
            Console.WriteLine("\n*** The Game is a Draw. Nobody WON!! ***\n", humanName);
            DrawBoard("");
            WinnerFound = true;
            return false;
        }
    }
}
