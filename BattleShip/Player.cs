﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Player
    {
        public int turnNumber = 0;

        public string playerName { get; set; }

        public bool playerWin { get; set; }
        public bool boardInitialized { get; set; }

        private string promptAnswer;

        private enum Ships { AircraftCarrier = 5, BattleShip = 4, Destroyer = 3, Submarine = 2, PatrolBoat = 1 };

        private List<string> myChars = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", };
        private List<string> myInts = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", };

        /*
        private int numberOfBattleShips = 2;
        private int numberOfDestroyers = 3;
        private int numberOfAircraftCarriers = 1;
        private int numberOfSubs = 2;
        private int numberOfPatrolBoats = 1;
        */

        private int totalShips;
        private int arraySize = 10;

        private bool isHuman;

        //THE ACTUAL BOARD WHERE GAMEPLAY OCCURS
        private char[,] playerBoardArray = new char[10,10];

        //SHITTY BORDER THAT CONFUSED ME
        private char[,] border = new char[,] { {'A', '0' }, {'B', '1' }, {'C', '2' }, { 'D', '3' }, {'E', '4' }, 
            {'F', '5' }, {'G', '6' }, { 'H', '7' }, {'I', '8' }, {'J', '9' } };

       

        private Random rng = new Random();

        //Player namer and Control setting
        public void PlayerStart()
        {
            Console.Write("Enter this player's name> ");
            playerName = Console.ReadLine();

            Console.Write("Is {0} a (H)uman or (C)omputer? ", playerName);
            promptAnswer = Console.ReadLine();
            Console.Clear();

            if(promptAnswer == "H" && promptAnswer != "C")
            {
                Console.WriteLine("{0} is a human player...", playerName);
                isHuman = true;
            }
            else if(promptAnswer == "C")
            {
                Console.WriteLine("{0} is a computer player...", playerName);
                isHuman = false;
            }
            Console.Write("Press enter to continue> ");
            Console.ReadLine();
            Console.Clear();
            
        }

        //Flips a coing returns a bool
        public bool CoinFlip()
        {
            bool headsTtailsF = true;
            if (rng.Next(1, 21) > 10)
            {
                return headsTtailsF;
            } 
            else
            {
                headsTtailsF = false;
                return headsTtailsF;
            }


        }

        //Computers own initialize function
        //will have random fleet config
        private void ComputerInitializeBoard()
        {
            InitializePlayerBoard();
            //Fleet config goes here
        }

        //Fills the board with ocean ~
        //Then goes to AddShips
        private void InitializePlayerBoard()
        {
            totalShips = 5; //numberOfAircraftCarriers + numberOfBattleShips + numberOfDestroyers + numberOfPatrolBoats + numberOfSubs;
            

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    playerBoardArray[i, j] = '~';
                }
            }

            if(isHuman)
            {
                AddShipsToBoardGate();
            }
            
        }

        //Adds ship to the board
        private void AddShipsToBoardGate()
        {
            int loopCounter = 0;
            int shipsToAdd = totalShips;
            int x = 0;
            int y = 0;
            bool rawDisplay = true;

            Console.Clear();
            Console.Write("Hear is where you place your ships...");
            Console.ReadLine();
            Console.Clear();
            Console.Write("You will be shown the board and then\ngiven the chance to place a ship at a set of coordinates.\nEnsure other player is looking away!");
            Console.ReadLine();

            //Adding ships loop
            while (shipsToAdd != 0)
            {
               loopCounter++;
               Console.Clear();
               DisplayPlayerBoard(rawDisplay);
               shipsToAdd = AddShipToBoard(shipsToAdd, loopCounter);
               if(shipsToAdd == 5)
               {
                    loopCounter = 0;
               }
            } 

            if (PassBoard(x, y))
            {

            }
            else
            {

            }

            boardInitialized = true;
        }

        //Iterates through available ships to add
        private int AddShipToBoard(int shipsToAdd, int loopCounter)
        {
            Tuple<char, int> location;
            int numCordinate = 0;
            string input;

            Console.WriteLine("Enter location (Example: A6) to center your {0} with a length of {1}:", EnumNameFlippper(Math.Abs((loopCounter-6))), shipsToAdd);
            input = Console.ReadLine();


            if (input.Length == 0 || input.Length > 2 || !myChars.Contains(input.Substring(0, 1)) || !myInts.Contains(input.Substring(1,1)))
            {
                Console.WriteLine("Input error! Format example A6. Try again...");
                Console.ReadLine();
                //Wipe board
                return 5;
            }

            Console.ReadLine();
            return (shipsToAdd-1);
        }

        private string EnumNameFlippper(int numberInSet)
        {
            return Enum.GetName(typeof(Ships), numberInSet);
        }

        /*
        private int EnumValueFlippper(int numberInSet)
        {
            return numberInSet;
        }
        */

        //Shows the board
        //rawDisplay does not provide player warning
        public void DisplayPlayerBoard(bool rawDisplay)
        {
            if (isHuman)
            {
                if (!rawDisplay)
                {
                    Console.Clear();
                    Console.WriteLine("{0}'s map display. Ensure other player is looking away!\nEnter to begin... ", playerName);
                    Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine("Player {0}'s Board", playerName);

                //Top row
                Console.Write("   ");
                for (int i = 0; i < arraySize; i++)
                {
                    Console.Write("{0}  ", i);
                }


                Console.WriteLine();
                for (int i = 0; i < arraySize; i++)
                {
                    //WRITES BORDER ON LEFTSIDE OF LETTERS
                    Console.Write("{0}  ", border[i, 0]);

                    for (int j = 0; j < arraySize; j++)
                    {
                        //THE ACTUAL PLAYER MAP
                        Console.Write(playerBoardArray[i, j]);
                        Console.Write("  ");
                    }
                    Console.WriteLine();
                }

                Console.Write("\n");
            }
        }

        //edits the player board
        public void EditBoard(char y, int x, string shipType)
        {
            
        }


        //Checks to see if something was at location on player board
        private bool PassBoard(int x, int y)
        {
            if(playerBoardArray[x,y] != '~')
            {
                return true;
            }
            else
            {
                return false;
            }


            /*
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    if((i == y && j == x) && (playerBoardArray[i,j] == '#'))
                    {
                        return true;
                    }
                }
            }

            return false;
            */
        }

        //Returns what is on the board at recieved cordinates
        public char WhatIsOnBoard(int x, int y)
        {
            return playerBoardArray[x, y];

            /*
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    if ((playerBoardArray[i, j] != '~'))
                    {
                        return playerBoardArray[i, j];
                    }
                }
            }

            return '~';
            */

        }

        public void Turn()
        {
            //show uninit board
            DisplayPlayerBoard(false);

            //enum tester
            Console.WriteLine((int)Ships.AircraftCarrier);
            Console.ReadLine();

            //checks if human and on turn zero
            if (isHuman == true)
            {
                if (turnNumber == 0)
                {
                    InitializePlayerBoard();
                }
                else
                {

                }
            }
            else
            {
                if(turnNumber == 0)
                {
                    Console.WriteLine("Computer initializes board here...");
                    Console.ReadLine();
                    ComputerInitializeBoard();
                }
            }
            //select attack square
            //Attack cycle
            //view enemy board (Miss and hit squares displayed)

            turnNumber++;
            Console.Clear();
            Console.Write("Press enter to end turn...");
            Console.ReadLine();
        }

       


        //TODO
        //Not sure what this was for
        /*
        public Tuple<int, int> Turn()
        {
            if (boardInitialized == false)
            {
                InitializePlayerBoard();
            }
            else
            {
                //view own board
                //select attack square
                //view hit
            }

            return Tuple.Create(0, 0);

        }*/
    }
}