using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();

            //initiate player names and human or computer type
            player1.PlayerStart();
            player2.PlayerStart();
            player1.playerWin = false;
            player2.playerWin = false;

            Console.Write("Heads goes first, press enter to flip coin...");
            Console.ReadLine();


            /*take this out for final version
            player1.InitializePlayerBoard();
            player2.InitializePlayerBoard();
            */


            //Pick first move
            if (player1.CoinFlip() == true)
            {
                Console.WriteLine("Looks like {0} goes first!", player1.playerName);
                PlayGame(player1, player2);
            }
            else
            {
                Console.WriteLine("Looks like {0} goes first!", player2.playerName);
                PlayGame(player2, player1);
            }




            


        }

        static void PlayGame(Player goesFirst, Player goesSecond)
        {

            //take this out for final version
            //goesFirst.DisplayPlayerBoard();


            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("{0} goes first! {1} goes second!", goesFirst.playerName, goesSecond.playerName);
            Console.ReadLine();
            Console.Clear();

            //main game loop

            while(goesFirst.playerWin == false && goesSecond.playerWin == false)
            {
                Console.WriteLine("We are in the main game loop");
                goesFirst.playerWin = true;
                

                goesFirst.Turn();
                //check if enemy is hit


                goesSecond.Turn();
                //check if enemy is hit


                //goes second turn

            }

            //Check who won
            
            Console.Write("Game over... Press enter to continue> ");
            Console.ReadLine();
        }

    }
}



/*for (int i = 0; i < 10; i++)
           {
               if (player1.coinFlip() == true)
               {
                   Console.WriteLine("Flip number {0} for player {1} = Heads!", i, player1.playerName);
               }
               else
               {
                   Console.WriteLine("Flip number {0} for player {1} = Tails!", i, player1.playerName);
               }
           }
           */
