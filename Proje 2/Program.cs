using System;

namespace Proje_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] number = new int[3, 30];//Array to keep numbers

            int x = 13, y = 2, ry = 0, rx = 0;//Variables for cursor position and random numbers
            int control = 1, score = 0;//Variables for match control and adding score for each matching

            ConsoleKeyInfo cki;
            //To draw screeen
            for (int i = 0; i <= 0; i++)
            {
                for (int j = 0; j <= 0; j++) Console.WriteLine("+--------------------------------+");
                for (int k = 1; k <= 3; k++) Console.WriteLine("|                                |");
                for (int c = 4; c <= 4; c++) Console.WriteLine("+--------------------------------+");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0,8);
            Console.Write("Press ESC To Exit");

            //To generate numbers and place them
            Random random = new Random();
            for (int r = 0; r < 30; r++)
            {
                ry = random.Next(0, 3);
                rx = random.Next(0, 30);

                while (number[ry, rx] != 0)
                {
                    ry = random.Next(0, 3);
                    rx = random.Next(0, 30);
                }
                number[ry, rx] = random.Next(1, 4);
                Console.SetCursorPosition(rx + 2, ry + 1);
                if (number[ry, rx] == 1)
                    Console.ForegroundColor = ConsoleColor.Red;
                if (number[ry, rx] == 2)
                    Console.ForegroundColor = ConsoleColor.Blue;
                if (number[ry, rx] == 3)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(number[ry, rx]);
                System.Threading.Thread.Sleep(100);
            }

            Console.SetCursorPosition(x, y);
            //Loop for cursor and W,S,A,D movement
            while (true)
            {
                control = 1;
                while (control != 0)//Controlsif there any identical number matched
                {
                    control = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < 29; i++)
                        {
                            if (number[j, i] != 0 && (number[j, i] == number[j, i + 1]))//Detects matched identical numbers
                            {
                                number[j, i] = 0;
                                number[j, i + 1] = 0;
                                Console.SetCursorPosition(i + 2, j + 1);
                                Console.Write(" ");
                                Console.SetCursorPosition((i + 1) + 2, j + 1);
                                Console.Write(" ");

                                for (int k = 0; k < 2; k++)
                                {

                                    ry = random.Next(0, 3);
                                    rx = random.Next(0, 30);
                                    while (number[ry, rx] != 0)
                                    {
                                        ry = random.Next(0, 3);
                                        rx = random.Next(0, 30);
                                    }
                                    number[ry, rx] = random.Next(1, 4);
                                    Console.SetCursorPosition(rx + 2, ry + 1);
                                    if (number[ry, rx] == 1)
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    if (number[ry, rx] == 2)
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                    if (number[ry, rx] == 3)
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(number[ry, rx]);
                                    control = control + 1;
                                    score = score+5;

                                }
                                Console.SetCursorPosition(40, 2);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Score = " + score);
                                Console.SetCursorPosition(x, y);
                            }
                        }
                    }
                }
                cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.RightArrow)//Cursor movement
                {
                    Console.SetCursorPosition(x + 1, y);
                    x = x + 1;
                    if (x >= 32)
                        Console.SetCursorPosition(x = 2, y);
                }
                else if (cki.Key == ConsoleKey.LeftArrow)//Cursor movement
                {
                    Console.SetCursorPosition(x - 1, y);
                    x = x - 1;
                    if (x <= 1)
                        Console.SetCursorPosition(x = 31, y);
                }
                else if (cki.Key == ConsoleKey.UpArrow)//Cursor movement
                {
                    Console.SetCursorPosition(x, y - 1);
                    y = y - 1;
                    if (y <= 0)
                        Console.SetCursorPosition(x, y = 3);

                }
                else if (cki.Key == ConsoleKey.DownArrow)//Cursor movement
                {
                    Console.SetCursorPosition(x, y + 1);
                    y = y + 1;
                    if (y >= 4)
                        Console.SetCursorPosition(x, y = 1);

                }
                else if (cki.Key == ConsoleKey.W)//Moves single number up
                {

                    if (y - 1 <= 0)
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You can not move the number up!                 ");
                        Console.SetCursorPosition(x, y);

                    }
                    else if ((x == 2 && number[y - 1, x - 2] != 0 && number[y - 1, x - 1] != 0) || (x == 31 && number[y - 1, x - 2] != 0 && number[y - 1, x - 3] != 0))
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You can not move the number up!                 ");
                        Console.SetCursorPosition(x, y);
                    }
                    else if ((x != 2 && x != 31) && number[y - 1, x - 2] != 0 && (number[y - 1, x - 3] != 0 || number[y - 1, x - 1] != 0))
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You can not move the number up!                 ");
                        Console.SetCursorPosition(x, y);
                    }

                    else if (number[y - 1, x - 2] != 0 && number[y - 2, x - 2] == 0)
                    {
                        Console.Write(" ");
                        y = y - 1;
                        Console.SetCursorPosition(x, y);
                        number[y - 1, x - 2] = number[y, x - 2];
                        number[y, x - 2] = 0;
                        if (number[y - 1, x - 2] == 1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (number[y - 1, x - 2] == 2)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else if (number[y - 1, x - 2] == 3)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(number[y - 1, x - 2]);
                        Console.SetCursorPosition(x, y);

                    }
                    else if (number[y - 1, x - 2] != 0 && number[y - 2, x - 2] != 0)
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You can not move the number up!                 ");
                        Console.SetCursorPosition(x, y);


                    }

                }
                else if (cki.Key == ConsoleKey.S)//Moves single number down
                {

                    if (y + 1 >= 4)
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("You can not move the number down!                          ");
                        Console.SetCursorPosition(x, y);

                    }
                    else if ((x == 2 && number[y - 1, x - 2] != 0 && number[y - 1, x - 1] != 0) || (x == 31 && number[y - 1, x - 2] != 0 && number[y - 1, x - 3] != 0))
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("You can not move the number down!                          ");
                        Console.SetCursorPosition(x, y);
                    }
                    else if ((x != 2 && x != 31) && number[y - 1, x - 2] != 0 && (number[y - 1, x - 3] != 0 || number[y - 1, x - 1] != 0))
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("You can not move the number down!                          ");
                        Console.SetCursorPosition(x, y);
                    }

                    else if (number[y - 1, x - 2] != 0 && number[y, x - 2] == 0)
                    {
                        Console.Write(" ");
                        y = y + 1;
                        Console.SetCursorPosition(x, y);
                        number[y - 1, x - 2] = number[y - 2, x - 2];
                        number[y - 2, x - 2] = 0;
                        if (number[y - 1, x - 2] == 1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (number[y - 1, x - 2] == 2)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else if (number[y - 1, x - 2] == 3)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(number[y - 1, x - 2]);
                        Console.SetCursorPosition(x, y);

                    }
                    else if (number[y - 1, x - 2] != 0 && number[y, x - 2] != 0)
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You can not move the number down!");
                        Console.SetCursorPosition(x, y);


                    }

                }
                else if (cki.Key == ConsoleKey.D)//Moves single number right
                {
                    if (x >= 31)
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You can not move the number to the right!               ");
                        Console.SetCursorPosition(x, y);
                    }
                    else if ((x != 2 && x != 31) && (number[y - 1, x - 2] != 0 && (number[y - 1, x - 3] != 0 || number[y - 1, x - 1] != 0)))
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You can not move the number to the right!               ");
                        Console.SetCursorPosition(x, y);

                    }
                    while (x < 31 && number[y - 1, x - 1] == 0)
                    {
                        if ((x == 2 && number[y - 1, x - 2] != 0 && number[y - 1, x - 1] != 0) || (x == 31 && number[y - 1, x - 2] != 0 && number[y - 1, x - 3] != 0))
                        {
                            Console.SetCursorPosition(0, 6);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You can not move the number to the right!               ");
                            Console.SetCursorPosition(x, y);
                            break;
                        }
                        else if ((x != 2 && x != 31) && (number[y - 1, x - 2] != 0 && (number[y - 1, x - 3] != 0 || number[y - 1, x - 1] != 0)))
                        {
                            Console.SetCursorPosition(0, 6);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You can not move the number to the right!               ");
                            Console.SetCursorPosition(x, y);
                            break;
                        }
                        if (number[y - 1, x - 2] == 0)
                            break;
                        Console.Write(" ");
                        number[y - 1, x - 1] = number[y - 1, x - 2];
                        number[y - 1, x - 2] = 0;
                        x = x + 1;
                        Console.SetCursorPosition(x, y);
                        if (number[y - 1, x - 2] == 1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (number[y - 1, x - 2] == 2)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else if (number[y - 1, x - 2] == 3)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(number[y - 1, x - 2]);
                        Console.SetCursorPosition(x, y);
                        System.Threading.Thread.Sleep(100);
                    }


                }
                else if (cki.Key == ConsoleKey.A)//Moves single number left
                {
                    if (x <= 2)
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You can not move the number to the left!               ");

                        Console.SetCursorPosition(x, y);
                    }
                    else if ((x != 2 && x != 31) && (number[y - 1, x - 2] != 0 && (number[y - 1, x - 3] != 0 || number[y - 1, x - 1] != 0)))
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You can not move the number to the left!               ");
                        Console.SetCursorPosition(x, y);

                    }
                    while (x > 2 && number[y - 1, x - 3] == 0)
                    {
                        if ((x == 2 && number[y - 1, x - 2] != 0 && number[y - 1, x - 1] != 0) || (x == 31 && number[y - 1, x - 2] != 0 && number[y - 1, x - 3] != 0))
                        {
                            Console.SetCursorPosition(0, 6);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You can not move the number to the left!               ");
                            Console.SetCursorPosition(x, y);
                            break;
                        }
                        else if ((x != 2 && x != 31) && number[y - 1, x - 2] != 0 && (number[y - 1, x - 3] != 0 || number[y - 1, x - 1] != 0))
                        {
                            Console.SetCursorPosition(0, 6);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You can not move the number to the left!               ");
                            Console.SetCursorPosition(x, y);
                            break;
                        }

                        if (number[y - 1, x - 2] == 0)
                            break;
                        Console.Write(" ");
                        number[y - 1, x - 3] = number[y - 1, x - 2];
                        number[y - 1, x - 2] = 0;
                        x = x - 1;
                        Console.SetCursorPosition(x, y);
                        if (number[y - 1, x - 2] == 1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (number[y - 1, x - 2] == 2)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else if (number[y - 1, x - 2] == 3)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(number[y - 1, x - 2]);
                        Console.SetCursorPosition(x, y);
                        System.Threading.Thread.Sleep(100);
                    }

                }
                else if (cki.Key == ConsoleKey.Escape) { break; }//Exits from the game
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 8);
            Console.Write("Thanks For Playing\n\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
