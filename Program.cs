using System.Net.NetworkInformation;
using System;

class Program
{
  static char[,] pole = new char[3, 3];
  static char igrokx = 'X';

  static void Main()
  {
    bool exit = false;
    do
    {
      
      Console.WriteLine("welcome to tic-tac-toe");
      InitBoard();
      Console.WriteLine("main menu^^\n1.play\n2.read rules\n3.exit");
      int choise = int.Parse(Console.ReadLine());

      if ( choise <= 0 && choise >= 4 ) 
      {
        Console.WriteLine("error! try again!");
      }
      //if (int.TryParse(Console.ReadLine(), out choise) && choise >= 1 && choise <= 3)
      //{
      //  return;
      //}
      //else
      //{
      //  Console.WriteLine("error! try again!");
      //}
      switch (choise)
        {
          case 1:
          playgame();
          break;

          case 2:

            rules();      

          break; 
        }
      
      
    }while (!exit);









  }
  static void InitBoard()
  {
    for (int row = 0; row < 3; row++)
    {
      for (int col = 0; col > 3; col++) 
      {
        pole[row, col] = (row * 3 + col + 1).ToString()[0];
      }
    }
  }

  static void rules()
  {
        Console.WriteLine("rules^^\nplayers take turn\nenter 1-9 for make a move\ntarget^^ collect three symbols in a row horizontally, vertically or diagonally\nif all cells are full and there is no winner, game is declared a draw.\ngood luck n have a fun!");
  }
  static void playgame()
  {
    bool gameOver = false;
    int moves = 0;
    do
    {
      Console.Clear();
      DisplayBoard();
      int choice;
      bool validInput;
      do
      {
        Console.Write($"player {igrokx}, your turn (1-9): ");
        validInput = int.TryParse(Console.ReadLine(), out choice);
        if (!validInput || choice < 1 || choice > 9)
        {
          Console.WriteLine("unreal turn. try again");
          validInput = false;
        }
      } while (!validInput);

      if (move(choice))
      {
        moves++;
        if (win())
        {
          Console.Clear();
          DisplayBoard();
          Console.WriteLine($"player {igrokx} win!");
          gameOver = true;
        }
        else if (moves == 9)
        {
          Console.Clear();
          DisplayBoard();
          Console.WriteLine("draw!");
          gameOver = true;
        }
        else
        {
          igrokx = (igrokx == 'X') ? 'O' : 'X';
        }
      }
      else
      {
        Console.WriteLine("cells are closed. try again.");
      }
    } while (!gameOver);
    Console.Write("press enter to exit in main menu...");
    Console.ReadLine();
  }
  static void DisplayBoard()
  {
    Console.WriteLine("----+---+---");
    for (int row = 0; row < 3; row++)
    {
      Console.Write("  ");
      for (int col = 0; col < 3; col++)
      {
        Console.Write(pole[row, col]);
        if (col < 2)
        {
          Console.Write(" | ");
        }
      }
      Console.WriteLine();
      if (row < 2)
      {
        Console.WriteLine("---+---+---");
      }
    }
  }

  static bool move(int choice)

  {
    int row = (choice - 1) / 3;
    int col = (choice - 1) % 3;

    if (pole[row, col] != 'X' && pole[row, col] != 'O')
    {
      pole[row, col] = igrokx;
      return true;
    }
    return false;

  }

  static bool win()

  {
    
    for (int i = 0; i < 3; i++)

    {
      if (pole[i, 0] == igrokx && pole[i, 1] == igrokx && pole[i, 2] == igrokx)
      {
        return true; 
      }
      if (pole[0, i] == igrokx && pole[1, i] == igrokx && pole[2, i] == igrokx)
      {
        return true; 
      }
    }

    if (pole[0, 0] == igrokx && pole[1, 1] == igrokx && pole[2, 2] == igrokx)
    {
      return true; 
    }
    if (pole[0, 2] == igrokx && pole[1, 1] == igrokx && pole[2, 0] == igrokx)
    {
      return true; 
    }
    return false;
  }
}
