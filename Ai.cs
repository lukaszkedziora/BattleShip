using System.ComponentModel;
using System.Reflection.Emit;
using System.Diagnostics.Contracts;
using System;


namespace BattleShips_Natalia_Lukasz_Radek
{
    class Ai
    {
       //Ocean AiBoard = new Ocean();
        //public int x;
        //public int y;


    public void markOrientation(int[,] boardAi, int sunknumber, string[,] boardTemp){
    int[] xboard = new int[2];
    int[] yboard = new int[2];
    int i = 0;
    for (int x=1; x < 11; x++){
        for (int y = 1; y<11; y++){
            if (boardAi[x,y] == sunknumber){
                boardTemp[x,y] = "#";
                xboard[i] = x;
                yboard[i] = y;
                i++;
            }
            }
        }
    if (xboard[0] == xboard[1]){
        int curX = xboard[0]-1;
        int curY = yboard[0]-1;
            for (int z = 0; z < 3; z++){ 
                for (int a = 0; a < i+2; a++){             
                    boardAi[curX+z, curY+a] = -6;
                }
                    
                          
            }        
        }
    else if (yboard[0] == yboard[1]){
        int curX = xboard[0]-1;
        int curY = yboard[0]-1;
            for (int z = 0; z < 3; z++){ 
                for (int a = 0; a < i+2; a++){             
                    boardAi[curX+a, curY+z] = -6;
                }
                    
                          
            }        
        }
    }
       
   public void markAround(Ocean player, Ocean player2, int sunknumber){
    int[] xboard = new int[5];
    int[] yboard = new int[5];
    int i = 0;
    for (int x=1; x < 11; x++){
        for (int y = 1; y<11; y++){
            if (player.boardAi[x,y] == sunknumber){
                player.boardTemp[x,y] = "#";
                player2.board[x,y] = "#";
                xboard[i] = x;
                yboard[i] = y;
                i++;
            }
            }
        }
    if (xboard[0] == xboard[1]){
        int curX = xboard[0]-1;
        int curY = yboard[0]-1;
            for (int z = 0; z < 3; z++){ 
                for (int a = 0; a < i+2; a++){             
                    player.boardAi[curX+z, curY+a] = -6;
                }
                    
                          
            }        
        }
    else if (yboard[0] == yboard[1]){
        int curX = xboard[0]-1;
        int curY = yboard[0]-1;
            for (int z = 0; z < 3; z++){ 
                for (int a = 0; a < i+2; a++){             
                    player.boardAi[curX+a, curY+z] = -6;
                }
                    
                          
            }        
        }
    }
    

    
    public (int, int) aiMax(Ocean player)
    {
    int temp = 0;
    int x = 0;
    int y = 0;
    var res = (x, y);
    for (int i = 0; i < player.boardAi.GetLength(0)-1; i++)
        {  
         for (int a = 0; a < player.boardAi.GetLength(1)-1; a++)
            {
                if (temp < player.boardAi[a,i])
                {
                   temp = player.boardAi[a,i];
                   res = (x=a, y=i);
                }
            }
        }
        return res;
    }
    public (int, int) aiCheck(int x, int y, string[,] board1)
    {   
        if (board1[x, y-1] == " ")
        {
            y = y-1;
        }
        else if (board1[x, y+1] == " ")
        {
            y = y+1;

        }
          else if (board1[x-1, y] == " ")
        {
            x = x-1;

        }
          else if (board1[x+1, y+1] == " ")
        {
            x = x+1;

        }
        return (x, y);
    }

    
    }

}
