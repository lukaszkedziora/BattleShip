using System;

namespace BattleShips_Natalia_Lukasz_Radek
{
    class Ship : Ocean {
        public string name;
        public int length;
        public  string pictogram;
        //public string position;                 // for user input
        public bool isHorizontal;               
        public Ship (string name, int length, string pictogram){
            this.name = name;
            this.length = length;
            this.pictogram = pictogram;
        }
        public Ship(){
        }

        public void CreateShip() {         
            string shipPlacement;
            bool correctPlacement = false;
            Console.WriteLine("Please place: " + name + " (" + length + " squares)");
            
            // asks for ship placement - vertical or horizontal
            while (!correctPlacement) {
                Console.Write("Do you want to place it horizontally (y/n): "); 
                shipPlacement = Console.ReadLine().ToLower();

                if (shipPlacement == "y"){
                    isHorizontal = true;
                    correctPlacement = true;
                } else if (shipPlacement == "n") {
                    isHorizontal = false;
                    correctPlacement = true;
                } else {
                    Console.WriteLine("Invalid answer, please choose y (yes) or n (no).");
                }
            }
        }

        public bool PlaceShip(Ocean player) {
            Console.Write("Please choose the starting point: ");
            string position = Console.ReadLine().ToUpper();
            Console.WriteLine(position);
            string lettersForIndexing1 = "ABCDEFGHIJ";
            string numbersForIndexing2 = "0123456789";
            int x = Convert.ToInt32(lettersForIndexing1.IndexOf(position[0]));
            int y = Convert.ToInt32(numbersForIndexing2.IndexOf(position[1]));     
            int shipEndPosition = x + length;
            int shipEndPosition2 = y + length;
            if (isHorizontal == true && horizontal(length, x) == true && checkaround(player, length, isHorizontal, x, y) == true) {
                while (x < shipEndPosition) {                      
                    player.board[x,y] = pictogram;           
                    x ++;
                }           
                return true;
            } else if (isHorizontal == false && veritcal(length, y) == true && checkaround(player, length, isHorizontal, x, y) == true) {
                while (y < shipEndPosition2) {                                        
                    player.board[x,y] = pictogram;
                    y ++;
                }
                return true;
            } else {
                Console.WriteLine("Invalid placement.");
                return false;
            }
        }

        public bool PlaceShipRandomly(Ocean player) {
            isHorizontal = false;
            if(random.Next(2)==1){
                isHorizontal = true;
            };
            int x = random.Next(1,10);             // !!!! (10)
            int y = random.Next(1,10);

            int shipEndPosition = x + length;
            int shipEndPosition2 = y + length;

            if (isHorizontal == true && horizontal(length, x) == true && checkaround(player, length, isHorizontal, x, y) == true) {
                while (x < shipEndPosition) {                      
                    player.board[x,y] = pictogram;           
                    x ++;
                } 
                return true;
            
            } else if (isHorizontal == false && veritcal(length, y) == true && checkaround(player, length, isHorizontal, x, y) == true) {
                while (y < shipEndPosition2) {                                        
                    player.board[x,y] = pictogram;
                    y ++;
                }
                return true; 
            } 
            return false;
        }

        public bool PlaceShipRandomlyAi(Ocean player) {
            isHorizontal = false;
            if(random.Next(2)==1){
                isHorizontal = true;
            };
            int x = random.Next(1,11);             // !!!! (10)
            int y = random.Next(1,11);

            int shipEndPosition = x + length;
            int shipEndPosition2 = y + length;

            if (isHorizontal == true && horizontal(length, x) == true && checkaround(player, length, isHorizontal, x, y) == true) {
                while (x < shipEndPosition) {                      
                    player.boardAi[x,y]++;    
                    x ++;
                } 
                return true;
            
            } else if (isHorizontal == false && veritcal(length, y) == true && checkaround(player, length, isHorizontal, x, y) == true) {
                while (y < shipEndPosition2) {                                        
                    player.boardAi[x,y]++;
                    y ++;
                }
                return true; 
            } 
            return false;
        }

    

    }
}