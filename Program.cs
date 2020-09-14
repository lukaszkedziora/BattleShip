using System;

namespace BattleShips_Natalia_Lukasz_Radek
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Game game1 = new Game();
            Ai gameAi = new Ai();

            Ocean player1 = new Ocean();      
            player1.boardName = "Player 1"; 
            Ocean player2 = new Ocean();
            player2.boardName = "Player 2";

            game1.StartNewGame(player1);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear(); 
            game1.StartNewGame(player2);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            

            game1.Battle(player1, player2);


            
        }
    }
}
