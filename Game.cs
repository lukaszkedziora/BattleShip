using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Diagnostics.Contracts;
using System;


namespace BattleShips_Natalia_Lukasz_Radek
{
    class Game {

        //public int gameMode2;
        string shotPosition;
        public int x;
        public int y;

       
        Ship ship1 = new Ship("Carrier", 5, "C");
        Ship ship2 = new Ship("Battleship", 4, "b");
        Ship ship3 = new Ship("Cruiser", 3, "c");
        Ship ship4 = new Ship("Submarine", 3, "s");
        Ship ship5 = new Ship("Destroyer", 2, "d");

        public void StartNewGame(Ocean player){    
            bool correct = false;
            player.CreateTempBoard(player.board);
            player.CreateTempBoardAi(player.boardAi);   
            while (correct != true)
            {
            Console.Clear();
            Console.WriteLine("Let's play Battleships!");
            Console.Write($"{player.boardName} should be AI or real person a/r: ");
            string gameMode = Console.ReadLine();
            string gameMode2;

            switch(gameMode)
            {
                case "a":
                RandomAi(player);
                Console.WriteLine($"\nThe board for {player.boardName}:\n");
                while(!ship1.PlaceShipRandomly(player));    
                while(!ship2.PlaceShipRandomly(player)); 
                while(!ship3.PlaceShipRandomly(player));  
                while(!ship4.PlaceShipRandomly(player));  
                while(!ship5.PlaceShipRandomly(player));                    
                player.DrawOcean(player.board);
                player.CreateTempBoard(player.boardTemp); 
                correct = true;
                player.isItAiMovement = true;
                break;

                case "r":
                Console.WriteLine("Please choose how you want to play (1/2):\n 1. Choose ships position on the board\n 2. Place ships randomly");
                gameMode2 = Console.ReadLine();
                switch(gameMode2)
                    {
                        case "1":
                        player.DrawOcean(player.board);
                        Console.WriteLine($"\nPlease create board for {player.boardName}:\n");
                        Console.WriteLine("\nPlease create your board. Your ships are: Carrier (occupies 5 squares), Battleship (4), Cruiser (3), Submarine (3), and Destroyer (2). \n");
                        AddShips(ship1, player);
                        AddShips(ship2, player);
                        AddShips(ship3, player);
                        AddShips(ship4, player);
                        AddShips(ship5, player);
                        player.CreateTempBoard(player.boardTemp);
                        correct = true;
                        break;

                        case "2":
                        Console.WriteLine($"\nThe board for {player.boardName}:\n");
                        while(!ship1.PlaceShipRandomly(player));    
                        while(!ship2.PlaceShipRandomly(player)); 
                        while(!ship3.PlaceShipRandomly(player));  
                        while(!ship4.PlaceShipRandomly(player));  
                        while(!ship5.PlaceShipRandomly(player));                    
                        player.DrawOcean(player.board);
                        player.CreateTempBoard(player.boardTemp);
                        correct = true;
                        break;

                        default:
                        Console.WriteLine("Invalid Input");
                        correct = false;
                        break;
                    }
                    break;
                              
                default:
                Console.WriteLine("Invalid Input");
                correct = false;
                break;
               
                }
            }
        }

        public void RandomAi(Ocean player){
            int i = 0;
            while (i < 1000000)
            {
            while(!ship1.PlaceShipRandomlyAi(player));    
            while(!ship2.PlaceShipRandomlyAi(player)); 
            while(!ship3.PlaceShipRandomlyAi(player));  
            while(!ship4.PlaceShipRandomlyAi(player));  
            while(!ship5.PlaceShipRandomlyAi(player));
            i++;
            }
        }

        public void AddShips(Ship ship, Ocean player){
            ship.CreateShip();
            while(!ship.PlaceShip(player));
            player.DrawOcean(player.board);
        }

        public bool PlayerShot(Ocean player, Ocean player2) {                                  
            string testForIndexing1 = "ABCDEFGHIJ";                             
            string testForIndexing2 = "0123456789"; 
            Ai  xyCoordinates = new Ai();
            Ai  markAround = new Ai();
            if (player.isItAiMovement == true && player.shotSuccessfull == false) 
            {
                //Console.Read();
                (this.x, this.y) = xyCoordinates.aiMax(player);
                int x = this.x;
                int y = this.y;
            }
            else if (player.isItAiMovement == true && (player.shotSuccessfull == true))
            {
              Console.WriteLine($"{x}, {y}");
              (this.x, this.y) = xyCoordinates.aiCheck(x, y, player.boardTemp);
        
            }
            else if (player.isItAiMovement == false)
            {
            Console.Write("\nChoose which square you want to shoot: ");
            shotPosition = Console.ReadLine().ToUpper();
            x = Convert.ToInt32(testForIndexing1.IndexOf(shotPosition[0]));
            y = Convert.ToInt32(testForIndexing2.IndexOf(shotPosition[1]));
            }
            if (player2.board[x,y] == ship1.pictogram){
                putXonBoard(player, player2, -5);
                player2.C--;
                if (player2.C == 0) {
                    markAround.markAround(player, player2, -5);
                    player.sunkSuccessfull = true;
                }
            }
            
            else if (player2.board[x,y] == ship2.pictogram){
            putXonBoard(player, player2, -4);
                player2.b--;
                if (player2.b == 0) {
                    markAround.markAround(player, player2, -4);
                    player.sunkSuccessfull = true;
                }
            }
            
            else if (player2.board[x,y] == ship3.pictogram){
            putXonBoard(player, player2, -3);
                player2.c--;
                if (player2.c == 0){
                    markAround.markAround(player, player2, -3);
                    player.sunkSuccessfull = true;
                } 
            }
             
            else if (player2.board[x,y] == ship4.pictogram){
            putXonBoard(player, player2, -2);
                player2.s--;
                if (player2.s == 0){
                    markAround.markAround(player, player2, -2);
                    player.sunkSuccessfull = true;
                } 
                
            }
            else if (player2.board[x,y] == ship5.pictogram){
            putXonBoard(player, player2, -1);
                player2.d--;
                if (player2.d == 0){
                    markAround.markAround(player, player2, -1);
                    player.sunkSuccessfull = true;  
                    
                } 
                
            }
            else if (player2.board[x,y] == " ") {
                //player.board[x,y] = "o";
                player.boardTemp[x,y] = "o";
                player.shotSuccessfull = false;
                player.boardAi[x,y] = -6;
            } else if (player2.board[x,y] == "X" || player2.board[x,y] == "o") {
                Console.WriteLine("You have already shot this spot!");
                player.shotSuccessfull = false;
            }
            return player.shotSuccessfull;
        }

        

        public void putXonBoard(Ocean player, Ocean player2, int shipNumber)
        {
            player2.board[x,y] = "X";
            player.boardTemp[x,y] = "X";
            player.boardAi[x,y] = shipNumber;
            player.shotSuccessfull = true;
            player.shipsSunkCounter++; 
        }
       
        public void Shooting(Ocean player, Ocean player2) {                    
            player.DrawOceans(player);
            Console.WriteLine();
            //player.DrawOceanAi(player);
            PlayerShot(player, player2);
            while (player.shotSuccessfull == true){
                Console.Clear();
                if (player.sunkSuccessfull == true)
                {
                    Console.WriteLine("Hit and sunk!");
                    Console.ReadKey();
                    player.sunkSuccessfull = false;
                    player.shotSuccessfull = false;

                }
                else if (player.shotSuccessfull == true && player.sunkSuccessfull == false){
                Console.WriteLine("You hit a ship! Press any key to continue shooting...");
                Console.ReadKey();
                Console.WriteLine("\nPress any key to continue...");
                player.shotSuccessfull = false;
                player.DrawOceans(player);
                PlayerShot(player, player2);     
                }   
            }
        
            Console.Clear();
            if (player.shotSuccessfull == false){
            Console.WriteLine("You missed :(");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            player.sunkSuccessfull = false;
            Console.Clear();
            }   
        }

        public void Battle(Ocean player1, Ocean player2) {  
            int numberOfSquers = 16;
            bool hasWinner = false;
            do
           {
                Shooting(player1, player2);
                Shooting(player2, player1);
                if (player2.shipsSunkCounter > numberOfSquers || player1.shipsSunkCounter > numberOfSquers ) {
                hasWinner = false;}
                else{
                    hasWinner = true;
                }
                
           } while (hasWinner);
        
            WinEnd(player1, player2);
        }

        public void WinEnd(Ocean player1, Ocean player2){
            if (player1.shipsSunkCounter==17) Console.Write($"{player1.boardName} has WIN!");
            else if (player2.shipsSunkCounter==17) Console.Write($"{player2.boardName} has WIN!");
            Console.Read();

        }  
        
    }
}
