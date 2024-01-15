using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _25MazeCanExit
{
    class Program
    {
        static Stack<Position> stack = new Stack<Position>();

        static void Main(string[] args)
        {

            string[,] matrix = new string[,]
                {
                    { "","W","W", "" ,"E"},
                    { "","", "" , "" ,""},
                    { "", "W", "W","W" ,"W"},
                    { "", "", "" , "" ,"S"}
                };

            CanExit(matrix);
        }

        public static void CanExit(string[,] matrix) {
            //W: wall --> cannot pass
            //S: entry point
            //E: exit point of warehouse
            //" ": you can pas through
            int[] startPoint = GetCoordenate(matrix, "S");

            Position currentPosition = new Position(startPoint[1], startPoint[0]);
            currentPosition.AccessMovement = Movement.Down;
            currentPosition.CurrentMovement = Movement.Down;
            bool isExit = false;
            // Add Start Item
            StackPush(currentPosition, Movement.Up);

            //matrix is accesed/iterated with a current position
            while (!isExit)
            {
                PrintMatrix(matrix);
                //Check if is Exit
                //position.opciones = 4
                if (matrix[currentPosition.Y, currentPosition.X] == "E")
                {
                    Console.WriteLine(currentPosition.X + " " + currentPosition.Y);
                    isExit = true;
                    return;
                }
                //Check if is Wall
                if (matrix[currentPosition.Y, currentPosition.X] == "W")
                {
                    Console.WriteLine(currentPosition.X + " " + currentPosition.Y+" Is W");
                  
                    stack.Pop();
                    currentPosition = stack.Peek();
                    continue;
                }

                currentPosition= Rotate(currentPosition, matrix);
            }
        }

        public static Position Rotate(Position position, string[,] matrix) {
            // allow 4 movements
            Movement currentMov = position.CurrentMovement; //movimiento actual en el que esta
            Movement InitialMovement = position.AccessMovement;  // movimiento en con el cual accedio a 

            int startPosition = ((int)position.CurrentMovement);
            for (int x = 0; x < 4; x++) //for 4 values of enum
            {
                if (startPosition == 3)
                    startPosition = 0;
                else
                    startPosition++;
                Movement mov = (Movement)startPosition;

                // check if the next current mov is access point movement, return a step
                if (mov == InitialMovement)
                {
                    Console.WriteLine("________ NextMov will be access point, Stack pop");
                    stack.Pop();
                    position = stack.Peek();
                    return position;
                }

                Position result = new Position(0, 0);
                switch (mov)
                {
                    case Movement.Right:
                        result= RotateAction(position, matrix, mov, position.Y, position.X+1);
                        break;
                    case Movement.Down:
                        result= RotateAction(position, matrix, mov, position.Y+1, position.X);
                        break;
                    case Movement.Left:
                        result = RotateAction(position, matrix, mov, position.Y, position.X-1);
                        break;
                    case Movement.Up:
                        result = RotateAction(position, matrix, mov, position.Y-1, position.X);
                        break;
                }
                    
                if ( result != null) {
                    position.X = result.X;
                    position.Y = result.Y;
                    position.CurrentMovement = result.CurrentMovement;
                    position.AccessMovement = result.CurrentMovement;
                    return position;
                }                                    
            }

            return position;
        }

        public static Position RotateAction(Position currentPosition, string[,] matrix, Movement direction, int Y, int X) {
            if ((CheckMatrixLimit(currentPosition, direction, matrix))
                && IsEmptyOrExit(Y, X, matrix)
                && !IsItemInStack(Y, X))
            {
                currentPosition.X = X;
                currentPosition.Y = Y;
                currentPosition.CurrentMovement = direction;
                Console.WriteLine(direction.ToString() + " evaluated in X:" + currentPosition.X + " Y:" + currentPosition.Y);
                stack.Peek().CurrentMovement = direction;
                StackPush(currentPosition, direction);
                currentPosition.CurrentMovement = InverseMovement(direction);
                return currentPosition;
            }
            else
                return null;
        }


        public static int[] GetCoordenate(string[,] matrix, string value) {

            int[] start = new int[2];
            for (int x = 0; x < matrix.GetLength(0); x++) {
                for (int y = 0; y < matrix.GetLength(1); y++) {
                    if (matrix[x, y] == value) {
                        start[0] = x;
                        start[1] = y;
                        return start;
                    }
                }
            }
            return null;
        }

        public static void StackPush(Position item, Movement direction) {
            Position newItem = new Position(item.X, item.Y);
            newItem.CurrentMovement = InverseMovement(direction);
            newItem.AccessMovement = InverseMovement(direction);
            stack.Push(newItem);
        }

        public static bool IsItemInStack(int y, int x)
        {
            Position item = new Position(x,y);

            if (stack.Contains(item))
                return true;

            return false;
        }

        public static bool IsEmptyOrExit(int y, int x, string[,] matrix) {
            if (matrix[y, x] == "" || matrix[y, x] == "E")
                return true;

            return false;

        }

        public static bool CheckMatrixLimit(Position position, Movement direction, string[,] matrix) {
            bool result = false;
            switch (direction)
            {
                case Movement.Right:
                    if (matrix.GetLength(1) > position.X+1) 
                        result = true;
                    break;
                case Movement.Down:
                    if (matrix.GetLength(0) > position.Y+1)
                        result = true;
                    break;
                case Movement.Left:
                    if (position.X-1 >= 0)
                        result = true;
                    break;
                case Movement.Up:
                    if (position.Y-1 >= 0)
                        result = true;
                    break;
            }
            return result;
        }

        public static Movement NextMovement(Movement mov) {
            if (mov == Movement.Up)
            {
                return Movement.Right;
            }
            else {
                return mov + 1;
            }
        }

        public static Movement InverseMovement(Movement mov) {
            return mov switch
            {
                Movement.Right => Movement.Left,
                Movement.Left => Movement.Right,
                Movement.Down => Movement.Up,
                Movement.Up => Movement.Down,
                //unreachable
                _ => mov,
            };
        }

        public static void PrintMatrix(string[,] matrix) {

            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    if (IsItemInStack(y, x))
                        Console.Write("|*");
                    else
                    {
                        if(matrix[y,x]=="")
                            Console.Write("| ");
                        else
                            Console.Write("|" + matrix[y,x] + "");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("===========");
            }
            Console.WriteLine("===============================");
        }
    }

    public class Position: IEquatable<Position> {
        public int X;
        public int Y;
        public Movement AccessMovement;
        public Movement CurrentMovement;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals([AllowNull] Position position)
        {
            return position is Object && this.X == position.X && this.Y == position.Y;
        }
    }

    public enum Movement {
        Right,
        Down,
        Left,
        Up
    }
}

