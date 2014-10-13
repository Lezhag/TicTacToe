using System;
using System.Text.RegularExpressions;

//class for keeping game logic and stopping (win) conditions
namespace TicTacToe
{
    class Board
    {
        #region Board Properties
        private int?[][] _field;

        public int?[][] Field //main property that holds game information about player moves - a jagged array
        {
            get { return _field; }
            set { _field = value; }
        }

        public int? Row1
        {
            get { return _field[0][0] + _field[0][1] + _field[0][2]; }
        }

        public int? Row2
        {
            get { return _field[1][0] + _field[1][1] + _field[1][2]; }
        }

        public int? Row3
        {
            get { return _field[2][0] + _field[2][1] + _field[2][2]; }
        }

        public int? Column1
        {
            get { return _field[0][0] + _field[1][0] + _field[2][0]; }
        }

        public int? Column2
        {
            get { return _field[0][1] + _field[1][1] + _field[2][1]; }
        }

        public int? Column3
        {
            get { return _field[0][2] + _field[1][2] + _field[2][2]; }
        }

        public int? Diagonal1
        {
            get { return _field[0][0] + _field[1][1] + _field[2][2]; }
        }

        public int? Diagonal2
        {
            get { return _field[0][2] + _field[1][1] + _field[2][0]; }
        }

        private bool _endGame;

        public bool EndGame //if either player has the upper hand - or no more possible moves - the game ends
        {
            get
            {
                if ((Row1 == 0) || (Row1 == 3) ||
                    (Row2 == 0) || (Row2 == 3) ||
                    (Row3 == 0) || (Row3 == 3) ||
                    (Column1 == 0) || (Column1 == 3) ||
                    (Column2 == 0) || (Column2 == 3) ||
                    (Column3 == 0) || (Column3 == 3) ||
                    (Diagonal1 == 0) || (Diagonal1 == 3) ||
                    (Diagonal2 == 0) || (Diagonal2 == 3) || (FieldFull == true))
                {
                    _endGame = true;
                }
                else
                {
                    _endGame = false;
                }
                return _endGame;
            }
            set { _endGame = value; }
        }

        private bool FieldFull // private property to indicate that the board is full and no more moves are possible
        {
            get
            {
                int? sum = 0;
                foreach (int? i in _field[0])
                {
                    sum = sum + i;
                }
                foreach (int? i in _field[1])
                {
                    sum = sum + i;
                }
                foreach (int? i in _field[2])
                {
                    sum = sum + i;
                }
                if (sum != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int? WinnerToken //the property that holds winner info
        {
            get
            {
                if ((Row1 == 0) ||
                    (Row2 == 0) ||
                    (Row3 == 0) ||
                    (Column1 == 0) ||
                    (Column2 == 0) ||
                    (Column3 == 0) ||
                    (Diagonal1 == 0) ||
                    (Diagonal2 == 0))
                {
                    return 0;
                }
                if ((Row1 == 3) ||
                    (Row2 == 3) ||
                    (Row3 == 3) ||
                    (Column1 == 3) ||
                    (Column2 == 3) ||
                    (Column3 == 3) ||
                    (Diagonal1 == 3) ||
                    (Diagonal2 == 3))
                {
                    return 1;
                }
                return null;
            }
        }

        public int XIndex { get; set; } //property to access the game board X coordinate

        public int YIndex { get; set; } //property to access the game board Y coordinate
        
        #endregion

        #region Public ctor that initializes a new game with an empty field
        public Board()
        {
            _field = new int?[][] 
            {
                new int?[3],
                new int?[3],
                new int?[3]
            };
            EndGame = false;
        } 
        #endregion

        #region Function for making turns of players
        public void MakeTurn(Player p)
        {
            Console.WriteLine("{0}'s turn:", p.Name);
            char v = 'd';
            int h = 0;
            string _input = "";

            while (_input == "")
                try
                {
                    Console.WriteLine("{0}, please, enter the location: (Row letter Column number: A1)", p.Name);
                    _input = Console.ReadLine();
                    if ((Regex.IsMatch(_input[0].ToString(), @"^[a-cA-C]")) && (Regex.IsMatch(_input[1].ToString(), @"^[0-3]")))
                    {
                        v = _input[0];
                        h = int.Parse(_input[1].ToString());
                    }
                    else
                    {
                        _input = "";
                        throw new FormatException();
                    }
                    switch (v)
                    {
                        case 'A':
                        case 'a':
                            XIndex = 0;
                            break;
                        case 'B':
                        case 'b':
                            XIndex = 1;
                            break;
                        case 'C':
                        case 'c':
                            XIndex = 2;
                            break;
                        default:
                            throw new FormatException();
                    }
                    YIndex = h - 1;
                    //TurnLocation();

                    if (_field[XIndex][YIndex] == null)
                    {
                        _field[XIndex][YIndex] = p.Token;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Already moved here");
                        _input = "";
                    }
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine("Error in input data:" + e.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("This turn location is in an invalid format");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in input data:" + e.Message);
                }
        } 
        #endregion
    }
}
