using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class State
    {
        public static char PLAYER1 = 'R';
        public static char PLAYER2 = 'Y';

        public char[,] Board = {    {' ', ' ', ' ', ' ', ' ', ' ' },
                                    {' ', ' ', ' ', ' ', ' ', ' ' },
                                    {' ', ' ', ' ', ' ', ' ', ' ' },
                                    {' ', ' ', ' ', ' ', ' ', ' ' },
                                    {' ', ' ', ' ', ' ', ' ', ' ' },
                                    {' ', ' ', ' ', ' ', ' ', ' ' }   
        };


        public static char LastTurn;

        public char CurrentPlayer = PLAYER1;
        public void ChangePlayer()
        {
            if (CurrentPlayer == PLAYER1)
            {
                CurrentPlayer = PLAYER2;
            }
            else
            {
                CurrentPlayer = PLAYER1;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is State)) return false;
            State other = (State)obj;
            if (!Board.Equals(other.Board))
            {
                return false;
            }
            return CurrentPlayer == other.CurrentPlayer;
        }

        public bool IsTargetState()
        {
            int count;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                count = 0;
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == PLAYER1)
                    {
                        count++;
                        if (count == 4)
                            return true;
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }

            for(int i = 0; i < Board.GetLength(0); i++)
            {
                count = 0;
                for(int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[j, i] == PLAYER1)
                    {
                        count++;
                        if (count == 4)
                            return true;
                    }
                    else
                    {
                        count = 0;
                    }                    
                }
            }

            for(int i = 0; i <= Board.GetLength(0) - 4; i++)
            {
                for(int j = 0; j <= Board.GetLength(1) - 4; j++)
                {
                    count = 0;
                    for(int k = 0; k < 4; k++)
                    {
                        if (Board[i + k, j + k] == PLAYER1) 
                        {
                            count++;
                            if(count == 4)
                                return true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            for(int i = 0; i <= Board.GetLength(0) - 4; i++)
            {
                for(int j = Board.GetLength(1) - 1; j >= 3; j--)
                {
                    count = 0;
                    for(int k = 0; k < 4; k++)
                    {
                        if (Board[i + k, j - k] == PLAYER1)
                        {
                            count++;
                            if(count == 4)
                                return true;

                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return false;

        }

        public bool IsDraw()
        {
            for(int i = 0; i < Board.GetLength(0); i++)
            {
                for(int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == ' ')
                        return false;
                }
            }
            return true;
        }

        public char GetLastColor()
        {
            if (LastTurn == 'R')
                return 'R';
            return 'Y';
        }
        public override string ToString()
        {
            string value = "---------------------------\n";
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                value += i + 1 + " ";
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    value += "| " + Board[i, j] + " ";
                }
                value += "|\n---------------------------\n";

            }
            value += "  | a | b | c | d | e | f |";
            return value;
        }
    }
}
