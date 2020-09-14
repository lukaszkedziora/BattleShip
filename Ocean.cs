using System;

namespace BattleShips_Natalia_Lukasz_Radek{

    class Ocean {
        public string[,] board = new string[12,12];			
        public int[,] boardAi = new int[12,12];					
        public string[,] boardTemp = new string[12,12];
        public Random random = new Random();
        public bool isItAiMovement = new bool();
        public bool shotSuccessfull = false;
        public bool sunkSuccessfull = new bool();
        public string boardName;
        public int shipsSunkCounter; 
        public int c=3;
        public int C=5;
        public int s=3;
        public int d=2;
        public int b=4;
    
        
        public void DrawOceans(Ocean player){
            Console.WriteLine($" The board for: {player.boardName}         Your previous shots: ");
            Console.WriteLine();
            Console.WriteLine("  |A|B|C|D|E|F|G|H|I|J|          |A|B|C|D|E|F|G|H|I|J|");
            for(int y = 0; y < 10; y++){
                    Console.Write(" "+y+"|");		
                for (int x = 0; x < 10; x++){
                    Console.Write(player.board[x,y] +"|");	
                }             
                Console.Write($"         {y}|");
                for (int z = 0; z < 10; z++){
                    Console.Write(boardTemp[z,y] +"|");	 
                }	
                 Console.WriteLine("");	
                } 	          
        }

         public void DrawOcean(string [,] board){
            Console.WriteLine("  |A|B|C|D|E|F|G|H|I|J|");
            for(int y = 0; y < 10; y++){
                    Console.Write(" "+y+"|");		
                for (int x = 0; x < 10; x++){
                    Console.Write(board[x,y] +"|");			
                }
                Console.WriteLine("");
            }
        }
        public void DrawOceanAi(Ocean player){
            Console.WriteLine("  |A|B|C|D|E|F|G|H|I|J|");
            for(int y = 0; y < 12; y++){
                    Console.Write(" "+y+"|");		
                for (int x = 0; x < 12; x++){
                    Console.Write(player.boardAi[x,y] +"|");			
                }
                Console.Write("          ");
                Console.WriteLine("");
            }
        }
        public void CreateTempBoard(string[,] boardTemp){
            for (int x=0; x < 12; x++){
                for (int y = 0; y<12; y++){
                   boardTemp[x,y] = " ";
                }
            }
        }
        public void CreateTempBoardAi(int[,] boardTemp){
            for(int x = 0; x<10; x++){
                for(int y = 0; y<10; y++){
                    boardAi[x,y] = 0;							
                }
            }
        }
       
        public bool isHorozontal() {
            int z = random.Next(0,2);
            if (z == 0) {
                return true;
            } else {
                return false;
            }
        }
        public bool horizontal(int length, int x) {         
            if ((x + length) > 9) {
                return false;
            } else {
                return true;
            }
        }

        public bool veritcal(int length, int y) {           
            if (y + length > 9) {
                return false;
            } else {
                return true;
            }
        }
        public bool checkaround(Ocean player, int length, bool ishorizontal, int x, int y) {        
            int curX = x - 1;
            int curY = y - 1;

            if (x == 0){
                for (int i = 0; i < 2; i++) {               // if y ==0 lub jesli x,y == 9
                    for (int a = 0; a < length+2; a++) {
                        if (ishorizontal == true) {
                            if (player.board[curX+i, curY+a] != " ") {             
                                return false;
                            }
                        } else if (ishorizontal == false) {
                            if (player.board[curX+a, curY+i] != " ") {             
                                return false;
                            }
                        }
                    }
                }
            } else if (y == 0){
                for (int i = 0; i < 3; i++) {   
                    for (int a = 0; a < length+2; a++) {
                        if (ishorizontal == true) {
                            if (player.board[curX+a, y+i] != " ") {             
                                return false;
                            }
                        } else if (ishorizontal == false) {
                            if (player.board[curX+i, y+a] != " ") {             
                                return false;
                            }
                        }
                    }
                }
            }
            else {
                for (int i = 0; i < 3; i++) {   
                    for (int a = 0; a < length+2; a++) {
                        if (ishorizontal == true) {
                            if (player.board[curX+a, curY+i] != " ") {              
                                return false;
                            }
                        } else if (ishorizontal == false) {
                            if (player.board[curX+i, curY+a] != " ") {            
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

}
}