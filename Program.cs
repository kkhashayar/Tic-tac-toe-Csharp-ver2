using System;

namespace TTT
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string[] board = {" "," "," "," "," "," "," "," "," "};

            bool gameRunning = true;
            Player(board, gameRunning);
        }

        static void PrintMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void ShowBoard(string[] board)
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.Clear(); 
            
            Console.WriteLine(board[0] + "|" + board[1] + "|" + board[2]);
            Console.WriteLine("------");
            Console.WriteLine(board[3] + "|" + board[4] + "|" + board[5]);
            Console.WriteLine("------");
            Console.WriteLine(board[6] + "|" + board[7] + "|" + board[8]);
            Console.WriteLine("------");
            Console.ResetColor();
        }

        // Player method, getting input from user, datacheck and update the board
        static void Player(string[] board, bool gameRunning)
        {
            if(gameRunning == true)
            {
                ShowBoard(board);
                PrintMessage(ConsoleColor.Yellow, "Choose a spot 0-8 ");
                string playerInput = Console.ReadLine();
                int playerMove;

                if(!int.TryParse(playerInput, out playerMove))
                    {
                        PrintMessage(ConsoleColor.Red, "Only numbers 0-8, Press a key to continue!");
                        Console.ReadLine();
                        Player(board, gameRunning);
                    }else
                        {
                            if(playerMove > board.Length)
                                {
                                    PrintMessage(ConsoleColor.Red, "Out of range, only 0-8,  Press a key to continue!");
                                    Console.ReadLine();
                                    Player(board, gameRunning);
                                }if(board[playerMove] != " ")
                                    {
                                        PrintMessage(ConsoleColor.Red, "Spot is taken! press a key to try again!");
                                        Console.ReadLine();
                                        Player(board, gameRunning);
                                    }else
                                        {
                                            board[playerMove] = "X";
                                            if(CheckWin(board)== 1){
                                                Console.WriteLine("You won!");
                                                gameRunning = false;
                                            }
                                            ShowBoard(board);
                                            Machine(board, gameRunning);
                                        }
                        }
            }
            if(gameRunning == false){
                Console.WriteLine("Done! ");
            } 
        }

        // Machine method, using random numbers.
        static void Machine(string[] board, bool gameRunning)
        {
            
            Console.WriteLine("in machine method");
            bool running = true;
            // Check if empty spot available in board
            for(int i=0; i<board.Length; i++){
                if (board[i] == " " && gameRunning == true){
                    running = true;
                }else{
                    running = false;
                }
            }
            if(running == true){
                int machine_move = GetRandomSpot();
            if(board[machine_move] != " ")
                {
                    Machine(board, gameRunning);
                }else
                    {
                        board[machine_move] = "O";
                        Player(board, gameRunning);
                    }
            }else{
                Console.WriteLine("All spots are full! ");
                
            }  
        }
        
        // Generating random number 0-8
        static int GetRandomSpot()
        {
            Random random = new Random();
            int random_number = random.Next(0,8);
            return random_number;
        }
        
        static int CheckWin(string[] board)
        {
            if (board[0] == board[1] && board[0] == board[2] && board[0] != " ")
            {
                return 1;
            }
            else if (board[3] == board[4] && board[3] == board[5] && board[3] != " ")
            {
                return 1;
            }
            else if (board[6] == board[7] && board[6] == board[8] && board[6] != " ")
            {
                return 1;
            }
            else if (board[0] == board[3] && board[0] == board[6] && board[0] != " ")
            {
                return 1;
            }
            else if (board[1] == board[4] && board[1] == board[7] && board[1] != " ")
            {
                return 1;
            }
            else if (board[2] == board[5] && board[2] == board[8] && board[2] != " ")
            {
                return 1;
            }
            else if (board[0] == board[4] && board[0] == board[8] && board[0] != " ")
            {
                return 1;
            }
            else if (board[2] == board[4] && board[2] == board[6] && board[2] != " ")
            {
                return 1;
            }
            return 0;
        }

        
    }
}
