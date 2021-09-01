using System;

namespace RockPaperScissor
{
    /// <summary>
    /// Interface to intitiate the game and display options to user.
    /// </summary>
    public interface IGameConsole
    {
        void StartGameOrNot();
    }

    /// <summary>
    /// Interface to display end results. 
    /// </summary>
    public interface IDeclareWinner
    {
        void displayWinner(string result);
    }

    /// <summary>
    /// class implementing IGameConsole Interface
    /// </summary>
    public class GameConsole : IGameConsole
    {
        public bool play;
        public static string startgame;
        public void StartGameOrNot()
        {
            do
            {
                startgame = Console.ReadLine().ToUpper();
                startgame.ToUpper();

                if (startgame == "Y")
                {
                    play = true;
                }
                else if (startgame == "N")
                {
                    Console.WriteLine("\nLeave the game console");
                    Environment.Exit(0);
                }
                else
                {
                    Console.Write("\nInvalid option. Do you want to start the game? [Y/N] --> ");
                }
            } while (startgame != "Y" && startgame != "N");
        }
    }

    /// <summary>
    /// class Implementing Ideclare Interface
    /// </summary>
    public class DeclareWinner : IDeclareWinner
    {
        public void displayWinner(string result)
        {
            Console.WriteLine(result);
        }
       
    }

    /// <summary>
    /// class to intialize Player 
    /// </summary>
    public class Player
    {
        public int score { get; set; }
    }

    /// <summary>
    /// class implementing logic for game 
    /// </summary>
    public class RockPaperScissors
    {
        private static string winner { get; set; }
        public static string player_resp;
        private static int comp_resp;
        private static int computerscore;
      
        public static void Initialize(Player player)
        {
            player.score = 0;
            computerscore = 0;
        }

        public static int ComputerRPS()
        {
            Random c = new Random();
            comp_resp = c.Next(1, 4);
            return comp_resp;
        }

        public static void Check(int c, Player player)
        {
            c = ComputerRPS();
            DeclareWinner winnerResult = new DeclareWinner();
            switch (c)
            {
                case 1:

                    if (player_resp == "R")
                    {
                        winner="No one wins!! It's a Tie";
                    }
                    else if (player_resp == "P")
                    {
                        winner="Computer chose rock.\nPaper beats rock. Player wins this round.";
                        player.score++;
                    }
                    else if (player_resp == "S")
                    {
                        winner="Computer chose rock.\nRock beats scissors. Computer wins this round.";
                        computerscore++;
                    }
                    winnerResult.displayWinner(winner);

                    break;

                case 2:

                    if (player_resp == "R")
                    {
                        winner="Computer chose paper.\nPaper beats rock. Computer wins this round.";
                        computerscore++;
                    }
                    else if (player_resp == "P")
                    {
                        winner = "No one wins!!! It's a Tie";
                    }
                    else if (player_resp == "S")
                    {
                        winner = "Computer chose paper.\nScissors beats rock. player wins this round.";
                        player.score++;
                    }
                    winnerResult.displayWinner(winner);
                    break;

                case 3:

                    if (player_resp == "R")
                    {
                        winner = "Computer chose scissors.\nRock beats scissors. player wins this round.";
                        player.score++;
                    }
                    else if (player_resp == "P")
                    {
                        winner = "Computer chose scissors.\nScissors beats paper. Computer wins this round.";
                        computerscore++;
                    }
                    else if (player_resp == "S")
                    {
                        winner = "No one wins!!! It's a Tie";
                    }
                    winnerResult.displayWinner(winner);
                    break;
            }
        }

        public static bool WhoWins(Player player)
        {
            DeclareWinner winnerResult = new DeclareWinner();
            if (player.score == 2)
            {
                winnerResult.displayWinner("\nPlayer wins the game.\n");
                return true;
            }
            if (computerscore == 2)
            {
                winnerResult.displayWinner("\nComputer wins the game.\n");
                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Driver main program
    /// </summary>
    class Program
    {        
        static void Main(string[] args)
        {

            GameConsole gameConsole = new GameConsole();
            Console.Write("Do you want to start the game? [Y/N] --> ");
            gameConsole.StartGameOrNot();

            Player player1 = new Player();

            Console.Clear();          
            RockPaperScissors.Initialize(player1);

            while (gameConsole.play)
            {
                do
                {
                    Console.Write("Rock, paper, scissors? [R/P/S] --> ");
                    RockPaperScissors.player_resp = Console.ReadLine().ToUpper();
                } while (RockPaperScissors.player_resp == "R" && RockPaperScissors.player_resp == "P" && RockPaperScissors.player_resp == "S");

                int c = RockPaperScissors.ComputerRPS();

                Console.Clear();

                RockPaperScissors.Check(c, player1);

                if (RockPaperScissors.WhoWins(player1))
                {
                    Console.Write("Replay? --> ");
                    gameConsole.StartGameOrNot();
                    RockPaperScissors.Initialize(player1);
                    Console.Clear();
                }
            }
        }
    }
}


