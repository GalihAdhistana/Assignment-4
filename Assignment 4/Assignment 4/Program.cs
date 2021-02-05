using System;

namespace Assignment_4
{
    class GameMechanics
    {
        public static void Main(string[] args)
        {
            bool finished = false;

            do
            {
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. About the author");
                Console.WriteLine("3. Exit");

                int option = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (option)
                {
                    case 1:
                        NewGame();
                        break;
                    case 2:
                        AboutTheAuthor();
                        break;
                    case 3:
                        Exit();
                        break;
                }

                Console.Clear();
                Console.Write("Go back to the main menu? (y/n)");
                char c = char.Parse(Console.ReadLine());

                if (c == 'y')
                {
                    finished = false;
                }

                else
                {
                    finished = true;
                }

                Console.Clear();
            } while (!finished);
        }

        public static void NewGame()
        {
            char[] fieldStates = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int status = 0;
            int player = -1;

            do
            {
                Console.Clear();

                player = NextPlayer(player);

                Display(player);
                board(fieldStates);

                Engine(fieldStates, player);

                status = CheckWinner(fieldStates);

            } while (status.Equals(0));

            Console.Clear();
            Display(player);
            board(fieldStates);

            if (status.Equals(1))
            {
                Console.WriteLine($"Player {player} is the winner!");
            }

            if (status.Equals(2))
            {
                Console.WriteLine($"The game is a draw!");
            }
            Console.ReadKey();
        }

        public static int CheckWinner(char[] fieldStates)
        {
            if (itDraw(fieldStates))
            {
                return 2;
            }

            if (someoneWin(fieldStates))
            {
                return 1;
            }

            return 0;
        }

        public static bool itDraw(char[] fieldStates)
        {
            return fieldStates[0] != '1' &&
                   fieldStates[1] != '2' &&
                   fieldStates[2] != '3' &&
                   fieldStates[3] != '4' &&
                   fieldStates[4] != '5' &&
                   fieldStates[5] != '6' &&
                   fieldStates[6] != '7' &&
                   fieldStates[7] != '8' &&
                   fieldStates[8] != '9';
        }

        public static bool someoneWin(char[] fieldStates)
        {
            if (SamefieldStates(fieldStates, 0, 1, 2))
            {
                return true;
            }

            if (SamefieldStates(fieldStates, 3, 4, 5))
            {
                return true;
            }

            if (SamefieldStates(fieldStates, 6, 7, 8))
            {
                return true;
            }

            if (SamefieldStates(fieldStates, 0, 3, 6))
            {
                return true;
            }

            if (SamefieldStates(fieldStates, 1, 4, 7))
            {
                return true;
            }

            if (SamefieldStates(fieldStates, 2, 5, 8))
            {
                return true;
            }

            if (SamefieldStates(fieldStates, 0, 4, 8))
            {
                return true;
            }

            if (SamefieldStates(fieldStates, 2, 4, 6))
            {
                return true;
            }

            return false;
        }

        public static bool SamefieldStates(char[] testfieldStates, int pos1, int pos2, int pos3)
        {
            return testfieldStates[pos1].Equals(testfieldStates[pos2]) && testfieldStates[pos2].Equals(testfieldStates[pos3]);
        }

        public static void Engine(char[] fieldStates, int player)
        {
            bool illegalMove = true;

            do
            {
                string enteredNumber = Console.ReadLine();

                if (!string.IsNullOrEmpty(enteredNumber) &&
                    (enteredNumber.Equals("1") ||
                    enteredNumber.Equals("2") ||
                    enteredNumber.Equals("3") ||
                    enteredNumber.Equals("4") ||
                    enteredNumber.Equals("5") ||
                    enteredNumber.Equals("6") ||
                    enteredNumber.Equals("7") ||
                    enteredNumber.Equals("8") ||
                    enteredNumber.Equals("9")))
                {

                    int.TryParse(enteredNumber, out var fieldPlacementStates);

                    char currentStates = fieldStates[fieldPlacementStates - 1];

                    if (currentStates.Equals('X') || currentStates.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a states please select anotyher placement.");
                    }
                    else
                    {
                        fieldStates[fieldPlacementStates - 1] = playerStates(player);

                        illegalMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Illegal move please select anotyher placement.");
                }
            } while (illegalMove);
        }

        public static char playerStates(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }

            return 'X';
        }
        public static int NextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;
        }
        public static void Exit()
        {

        }
    }
    class Displaying
    {
        public static void Display(int PlayerNumber)
        {
            Console.WriteLine("Welcome to tic-tac-toe!");

            Console.WriteLine($"Player {PlayerNumber} to move, select 1 thorugh 9 from the game board.");
            Console.WriteLine();
        }

        public static void board(char[] fieldStates)
        {
            Console.WriteLine($" {fieldStates[0]} | {fieldStates[1]} | {fieldStates[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {fieldStates[3]} | {fieldStates[4]} | {fieldStates[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {fieldStates[6]} | {fieldStates[7]} | {fieldStates[8]} ");
        }
        public static void AboutTheAuthor()
        {
            Console.WriteLine("Galih Adhistana");
            Console.WriteLine("18 years old");
            Console.WriteLine("Indonesian");
            Console.WriteLine("Press any key. . .");
            Console.ReadKey();

        }
    }
}
