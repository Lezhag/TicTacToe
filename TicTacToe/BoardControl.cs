//class for drawing the board for the game that uses console pseudographics
using System;

namespace TicTacToe
{

    class BoardControl
    {
        const int CELLS_COUNT = 3;
        const int CELLS_HEIGHT = 8;

        #region Public method for drawing a gaming TicTacToe board
        //the main function that draws a board
        internal void Draw(Board b)
        {
            //board cap
            Console.WriteLine("         1                2              3         ");
            Console.WriteLine(" ||==============================================||");

            //the board is divided into 3 main rows
            for (int FieldRow = 0; FieldRow < CELLS_COUNT; FieldRow++)
            {
                DrawBlock(FieldRow, b);
            }
        }
        
        #endregion

        #region Private methods for drawing board elements
        //this function draws a block of 3 cells in a row
        private void DrawBlock(int Row, Board b)
        {
            //each block consists of 8 lines
            for (int Lines = 0; Lines < CELLS_HEIGHT; Lines++)
            {
                Begin(Row, Lines);
                //each block has 3 cells
                for (int FieldColumn = 0; FieldColumn < CELLS_COUNT; FieldColumn++)
                {
                    DrawCell(Lines, Row, FieldColumn, b);
                }
                Console.WriteLine();
            }
        }
        //function for drawing the cell
        private void DrawCell(int Lines, int Row, int FieldColumn, Board b)
        {
            //control structure that considers each individual line and if a cell has a token character - draws it
            switch (Lines)
            {
                case 0:
                case 6:
                    Console.Write("              ||");
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    if (b.Field[Row][FieldColumn] == 1)
                    {
                        Console.Write("     ");
                        DrawX(Lines - 1);
                        Console.Write("    ||");
                    }
                    if (b.Field[Row][FieldColumn] == 0)
                    {
                        Console.Write("     ");
                        DrawO(Lines - 1);
                        Console.Write("    ||");
                    }
                    if (b.Field[Row][FieldColumn] == null)
                    {
                        Console.Write("              ||");
                    }
                    break;
                case 7:
                    Console.Write("==============||");
                    break;
            }
        }
        //function for drawing the vertical captions
        private void Begin(int Row, int Lines)
        {
            if (Lines == 3)
            {
                switch (Row)
                {
                    case 0:
                        Console.Write("A||");
                        break;
                    case 1:
                        Console.Write("B||");
                        break;
                    case 2:
                        Console.Write("C||");
                        break;
                }
            }
            else
            { Console.Write(" ||"); }
        }
        //function for drawing the X shape
        private void DrawX(int line)
        {
            switch (line)
            {
                case 0:
                    Console.Write("X   X");
                    break;
                case 1:
                    Console.Write(" X X ");
                    break;
                case 2:
                    Console.Write("  X  ");
                    break;
                case 3:
                    Console.Write(" X X ");
                    break;
                case 4:
                    Console.Write("X   X");
                    break;
            }
        }
        //function for drawing the O shape
        private void DrawO(int line)
        {
            switch (line)
            {
                case 0:
                    Console.Write(" OOO ");
                    break;
                case 1:
                    Console.Write("O   O");
                    break;
                case 2:
                    Console.Write("O   O");
                    break;
                case 3:
                    Console.Write("O   O");
                    break;
                case 4:
                    Console.Write(" OOO ");
                    break;
            }
        } 
        #endregion
    }
}
