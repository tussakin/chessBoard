namespace ChessBoard;

class Program
{

    // Theres Sundberg Selin, NET.23

    /* In the main method we write out statements to inform the user of 
         * what we want them to do and the then call the apropriate method to
         * collect the data that we need.*/
    public static void Main(string[] args)
    {
        Console.WriteLine("Välkommen till schackbrädesskaparen! \nHur stort vill du att schackbrädet ska vara? Skriv in en siffra så kommer det skapas så många kolumner och rader.");
        int chessSize = parseNumber();

        Console.WriteLine("Hur vill du att de vita rutorna ska se ut?");
        string whiteSquare = validateStringInput();

        Console.WriteLine("Och de svarta rutorna?");
        string blackSquare = validateStringInput();

        Console.WriteLine("Du ska placera ut en schackpjäs, hur ska den se ut?");
        string chessPiece = validateStringInput();

        Console.WriteLine($"Vilken rad ska schackpjäsen stå? Skriv in en siffra mellan 1 och {chessSize}");
        int chessPiecePlaceRow = rowColumnSize(chessSize);

        Console.WriteLine($"Och vilken kolumn? Skriv in en siffra mellan 1 och {chessSize}");
        int chessPiecePlaceColumn = rowColumnSize(chessSize);

        Console.WriteLine("Woo, här är ditt bräde! \n\n\n");
        /* In the end of the program we call the chessBoard method to write
         out the chessBoard to show the user what their input resulted in. */
        ChessBoard(whiteSquare, blackSquare, chessSize, chessPiecePlaceRow, chessPiecePlaceColumn, chessPiece);
    }


    /* A method that prints out the chessboard. It loops through and writes out
     * the chosen white space if the number of spaces that is even and if it's  
     * not even, it prints out the chosen black square. If the position is the 
     * number the user chose for the place of the chesspiece the program will
     * print out the chesspiece instead of a square. This is to visualise the 
     chessboard for the user. */
    private static void ChessBoard(string whiteSquare, string blackSquare, int chessSize, int chessPiecePlaceRow, int chessPiecePlaceColumn, string chessPiece)
    {
        for (int row = 1; row <= chessSize; row++)
        {
            for (int column = 1; column <= chessSize; column++)
            {
                if (column == chessPiecePlaceColumn && row == chessPiecePlaceRow)
                {
                    Console.Write(chessPiece);
                }
                else if ((row + column) % 2 == 0)
                {
                    Console.Write(whiteSquare);
                }
                else
                {
                    Console.Write(blackSquare);
                }
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }


    /* A method that takes input from user and checks if the value is a valid 
     * number and not lower than 0. If not valid, a message explaining 
     * is written out and user is promted to input a new value. */

    private static int parseNumber()
    {
        while (true)
        {
            string ParseNumber = Console.ReadLine();

            if (int.TryParse(ParseNumber, out int number) && number > 0)
            {
                    return number;
            }
            else
            {
                Console.WriteLine("Det var inte ett giltigt nummer, prova igen med ett positivt heltal");
            }
        }
    }


    /* A method that takes input from user and then makes sure that the input 
     * is not a whitespace or null. This is to make sure that the chessboard 
     will be visable for the user in the end of the program. */
    private static string validateStringInput()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Du behöver skriva in något!");
            }
        }
    }

    /* A method that takes in input from user and then proceeds to make sure 
     * that the input is correct. For the input to be correct it needs to not 
     * be a whitespace or null, and it needs to be a number, not higher or lower
     * than the size of the chessboard.If the input is not correct, a message 
     * explaning this will come up and the user gets to input a new value.*/

    private static int rowColumnSize(int chessSize)
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (number <= chessSize && number > 0)
                    {
                        return number;
                    }
                    else
                            {
                                Console.WriteLine($"Du måste välja ett nummber mellan 1 och {chessSize}");
                            }
                }
                else
                {
                    Console.WriteLine("Du behöver skriva in något! Prova igen.");
                }
            }
            else
            {
                Console.WriteLine("Du måste skriva ett giltigt nummer! Prova igen.");
            }
        }
    }
}