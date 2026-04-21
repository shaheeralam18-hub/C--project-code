using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        int dice   = rnd.Next(1, 7);
        
        int TotalPlayers;
        Console.WriteLine("Welcome to the ultimate game of snakes and ladders!");
        Console.WriteLine("Note this game is entirely based off luck");
        Console.WriteLine("Press 1 if you wish to see the rules. Or press any other key to continue..");
        string Response = Console.ReadLine();
        if (Response == "1")
        {
            Console.WriteLine("Previewing rules...");
            Console.WriteLine("Rules: \nRoll your dice. \nIf rolling your dice ends with 3 sixes, foul! \nIf your current tile + your turn score exceeds 100, foul!");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }
        Console.WriteLine("\nEnter the number of players (atleast 1 player required and maximum 4 players are supported. Answer in numeric)");
        while(true)
        {
            string InputVal = Console.ReadLine();
        if (InputVal != "1" && InputVal != "2" && InputVal != "3" && InputVal != "4")
            {
                Console.WriteLine("Incorrect Input. Please re-enter!");
            }
            else
            {
                TotalPlayers = Convert.ToInt32(InputVal);
                break;
            }
        }
        Console.WriteLine("Setting up game for "+TotalPlayers+" Player(s)");
        Console.WriteLine("...");
        Console.WriteLine("...");
        Console.WriteLine("...");
        
        int[] SnLOpening = new int[10] {6,19,30,33,58,63,72,74,84,96};
        int[] SnLEnding = new int[10] {27,57,8,85,37,81,94,55,65,61};
        
        string[] playerNames = new string[TotalPlayers];
        int[] playerScores = new int[TotalPlayers];
        string[] Colors = new string[4] {"+", "*", "@", "$"};
        
        for (int i = 0; i < TotalPlayers; i++)
        {
        Console.WriteLine("Enter Your Name Player "+i);
        playerNames[i] = Console.ReadLine();
        Console.WriteLine("\n"+playerNames[i]+"! your sign is "+Colors[i]+"\n");
        playerScores[i] = 1;
        }
        
        Console.WriteLine("\n GAME BEGINS!\n");
        
        while(true)
        {
            for (int i = 0; i < TotalPlayers; i++)
              {
                  if (playerScores[i] == 100)
                  {continue;}
                 int TurnScore = 0;
              Console.WriteLine("\n"+playerNames[i]+"! Press any key to roll the dice");
              Console.ReadLine();
              dice   = rnd.Next(1, 7);
              Console.WriteLine("\n"+playerNames[i]+"! You rolled: "+dice);
              TurnScore = TurnScore+dice;
              if (dice == 6)
              {
                  Console.WriteLine("\n"+playerNames[i]+"! Press any key to roll the dice again");
              Console.ReadLine();
              dice   = rnd.Next(1, 7);
              Console.WriteLine("\n"+playerNames[i]+"! You rolled: "+dice);
              TurnScore = TurnScore+dice;
              if (dice == 6)
              {
                  Console.WriteLine("\n"+playerNames[i]+"! Press any key to roll the dice again");
              Console.ReadLine();
              dice   = rnd.Next(1, 7);
              Console.WriteLine("\n"+playerNames[i]+"! You rolled: "+dice);
              TurnScore = TurnScore+dice;
              if (dice == 6)
              {
                  Console.WriteLine("\n FOUL!!");
                  TurnScore = 0;
                    }
                 }
              }
                Console.WriteLine("\n"+playerNames[i]+"! In this turn you scored: "+TurnScore+"\n");
                
                if (playerScores[i]+TurnScore <= 100)
                 {
                     playerScores[i] = playerScores[i]+TurnScore;
                 for (int B = 0; B < 10; B++)
                 {
                     if (playerScores[i] == SnLOpening[B])
                     {
                         playerScores[i] = SnLEnding[B];
                         if (SnLOpening[B] > SnLEnding[B])
                         {
                             Console.WriteLine(playerNames[i]+" was bitten by a snake!");
                         }
                         else
                         {
                             Console.WriteLine(playerNames[i]+" climbed a ladder!");
                         }
                     }
                 }
              }
                 else
                 {Console.WriteLine("Turn didn't count");}
                 
              }
              bool GAME_ENDED = true;
              for (int A = 0; A < TotalPlayers; A++)
                {
                    if (playerScores[A] < 100)
                    GAME_ENDED = false;
                }
                if (GAME_ENDED == true)
                    {
                        Console.WriteLine("GAME OVER!");
                        break;
                        
                    }
                    Console.WriteLine("\nPreviewing Gameboard!!\n\n");
                    for (int j = 9; j >= 0 ; j--)
                 {
                     for (int k = 9; k >= 0; k--)
                     {
                         int BLOCKNUM;
                         if (j%2 == 1)
                         {BLOCKNUM = 10*j+k+1;}
                         else
                         {BLOCKNUM = (10*j)+(10-k);}
                         
                         bool overwritten = false;
                         for (int A = 0; A < TotalPlayers; A++)
                             {
                                if (playerScores[A] == BLOCKNUM)
                                {
                                    Console.Write(Colors[A]+"\t");
                                    overwritten = true;
                                }
                             }
                             if (overwritten == false)
                              {Console.Write(BLOCKNUM+"\t");}
                     }
                     Console.WriteLine("\n");
                 }
        }
    }
}
