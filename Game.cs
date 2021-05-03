using System;
using System.Collections.Generic;
using System.Linq;

namespace chess
{

    /// <summary>
    /// Main static class that controls the game
    /// </summary>
    class Game
    {

        /// <summary> A 2 dimensional array of piece objects that store the position of all the pieces on the board.  The first dimension contains the rows and the second dimension is each tile in the row. </summary>
        public static Piece[,] gameBoard = new Piece[8,8];

        /// <summary> The player object for the first player </summary>
        public static Player player1;

        /// <summary> The player object for the second player </summary>
        public static Player player2;
        
        /// <summary> The piece object of the piece selected by the player </summary>
        public static Piece selectedPiece;

        /// <summary> The list of possible moves for the selected piece </summary>
        public static List<(int X, int Y)> possibleMoves;

        /// <summary> The player's who's turn it is </summary>
        public static Player turn;

        /// <summary> The player that wins the game. This should stay null until a winner is declared </summary>
        static Player winner = null;

        /// <summary> The list of all the past moves </summary>
        static List<((int X, int Y) from, (int X, int Y) to, Piece piece, Player player, Piece replacedPiece)> moveHistory = new List<((int X, int Y) from, (int X, int Y) to, Piece piece, Player player, Piece replacedPiece)>();

        static char[] xAxis = new char[] {' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};

        static void Main(string[] args)
        {
            // Start the board
            StartBoard();

            // Loop forever
            while (winner == null) {
                // Prompt the player to select a piece
                selectedPiece = SelectPiece();
                
                // If the player selected a eligible piece
                if (selectedPiece != null) {
                    // Prompt the player to move the selected piece
                    if (MovePiece(selectedPiece) == true) {
                        // If the move is successfull, change the turn
                        if (turn == player1) {
                            turn = player2;
                        }
                        else {
                            //turn = player1;
                        }
                    }
                    else {
                        continue;
                    }
                }
                else {
                    continue;
                }

                // Update board
                PrintBoard();
            }

            // Print the winner
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($"{winner.name} Wins!");
            System.Console.ForegroundColor = ConsoleColor.White;
        }


        /// <summary>
        /// Clear the console and re-print the board. This method must to called every time the board is updated
        /// </summary>
        static void PrintBoard() {
            System.Console.Clear();

            // Print the top letter axis
            foreach (char c in xAxis){
                System.Console.Write(" {0} ", c);
            }
            System.Console.Write("\n");

            System.Console.BackgroundColor = ConsoleColor.White;

            // Loop 9 times (once for every row)
            for (int y = 0; y < 8; y++)
            {
                // Print the left number axis
                ConsoleColor oldColor = System.Console.BackgroundColor;
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.Write(" {0} ", y+1);
                System.Console.BackgroundColor = oldColor;

                // Loop 9 times (once for every column)
                for (int x = 0; x < 8; x++)
                {
                    // Switch color to create checkered pattern
                    if (System.Console.BackgroundColor == ConsoleColor.White) {
                        System.Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else {
                        System.Console.BackgroundColor = ConsoleColor.White;
                    }

                    // Set the foreground color to color of the piece
                    System.Console.ForegroundColor = gameBoard[y, x].color;
                    
                    // Print the character of the piece
                    System.Console.Write(" {0} ", gameBoard[y, x].symbol);
                    
                    // Reset the foreground color to white 
                    System.Console.ForegroundColor = ConsoleColor.White;
                }

                // If there the list of past moves is long enough
                if (moveHistory.Count - (y + 1) >= 0) {
                    // Store the current background color to restore it later
                    oldColor = Console.BackgroundColor;

                    // Set the background color to black
                    System.Console.BackgroundColor = ConsoleColor.Black;

                    // Get the move from the list of past moves
                    ((int X, int Y) from, (int X, int Y) to, Piece piece, Player player, Piece replacedPiece) move = moveHistory[moveHistory.Count - (y + 1)];
                    
                    // Set foreground color to the color of player that made the move
                    Console.ForegroundColor = move.player.color;

                    // Print the move to the console
                    Console.Write($"\t {move.piece.symbol} {xAxis.Skip(1).ToArray()[move.from.X]}{move.from.Y + 1} -> {xAxis.Skip(1).ToArray()[move.to.X]}{move.to.Y + 1} ");
                    Console.ForegroundColor = move.replacedPiece.team.color;
                    Console.Write(move.replacedPiece.symbol == '#' ? ' ' : move.replacedPiece.symbol);
                    
                    // Reset the console colors
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.BackgroundColor = oldColor;
                }

                // Switch the color again (two switches when we go to the next row will cause the color to stay the same. This is required to create the checkered pattern)
                if (System.Console.BackgroundColor == ConsoleColor.White)
                {
                    System.Console.BackgroundColor = ConsoleColor.Black;
                }
                else {
                    System.Console.BackgroundColor = ConsoleColor.White;
                }
                System.Console.Write("\n");
            }

            // Reset the background color to black
            System.Console.BackgroundColor = ConsoleColor.Black;

            // Print who's turn it is
            System.Console.ForegroundColor = turn.color;
            System.Console.WriteLine($"{turn.name}'s turn");

            // Reset foreground color to White
            System.Console.ForegroundColor = ConsoleColor.White;
        }


        /// <summary>
        /// Create the player objects and populate the game board
        /// </summary>
        public static void StartBoard() {
            // Create player 1
            System.Console.WriteLine("Enter Name For Player 1: ");
            player1 = new Player(1, Console.ReadLine());

            // Create player 2
            System.Console.WriteLine("Enter Name For Player 2: ");
            player2 = new Player(2, Console.ReadLine());

            // Give player 1 the first turn
            turn = player1;

            // Populate the game board
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    gameBoard[y, x] = GetPieceAtIndex(x, y);
                }
            }

            // Update board
            PrintBoard();
        }


        /// <summary>
        /// Get the piece in the game board at the specified coordinates
        /// </summary>
        public static Piece GetPieceAtIndex(int x, int y) {
            // Loop over every piece on player 1's team 
            foreach (Piece piece in player1.pieces)
            {
                // Return the piece if its position matches the specified coordinates 
                if (piece.position.X == x && piece.position.Y == y) {
                    return piece;
                }
            }

            // Loop over every piece on player 2's team 
            foreach (Piece piece in player2.pieces)
            {
                // Return the piece if its position matches the specified coordinates 
                if (piece.position.X == x && piece.position.Y == y) {
                    return piece;
                }
            }

            // Return an new empty piece if no piece is found 
            return new Piece("empty", x, y, ConsoleColor.Black, null, ' ');
        }


        /// <summary>
        /// Get the player to select a piece
        /// </summary>
        public static Piece SelectPiece() {
            // Prompt the player
            Console.Write("Select Piece To Move:");
            char[] coords = Console.ReadLine().ToUpper().ToCharArray();
            int x;
            int y;
            try {
                // Parse the x coordinate from user input
                x = Array.IndexOf(xAxis.Skip(1).ToArray(), coords[0]);

                // Return null if the user input is invalid
                if (x == -1) {
                    PrintBoard();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Invalid Tile.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return null;
                }

                // Parse the y coordinate from user input
                y = Int32.Parse(coords[1].ToString()) - 1;
            }
            // Return null if an exception is encountered (user input is invalid)
            catch (System.Exception) {
                PrintBoard();
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Invalid Tile.");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }

            // Return null if selected piece doesn't have a piece on it
            if (gameBoard[y, x].type == "empty") {
                PrintBoard();
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Nothing On That Tile.");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }

            /// Return null if the selected piece is not on the player's team
            if (gameBoard[y, x].team != turn) {
                PrintBoard();
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Piece Not On Your Team.");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }

            // Change the foreground color of the selected piece to green
            gameBoard[y, x].color = ConsoleColor.Green;

            // Get the possible moves of the selected piece
            possibleMoves = gameBoard[y, x].GetPossibleMoves();

            // Loop over every possible move
            for (int i = 0; i < possibleMoves.Count; i++)
            {
                (int X, int Y) move = possibleMoves[i];

                // If there is a piece at at the possible move, set the piece's color to cyan   
                if (gameBoard[move.Y, move.X].type != "empty") {
                    gameBoard[move.Y, move.X].color = ConsoleColor.Cyan;
                }
                // Else, it must be empty, so replace the piece with a new 'move' type piece
                else {
                    gameBoard[move.Y, move.X] = new Piece("move", move.X, move.Y, ConsoleColor.Green, gameBoard[y, x].team, '#');
                }
            }
            
            // Update board
            PrintBoard();

            // Return the selected piece
            return gameBoard[y, x];
        }


        /// <summary>
        /// Get the player to move a piece
        /// </summary>
        public static bool MovePiece(Piece piece) {
            (int X, int Y) move;

            bool success;
            
            // Loop until the player successfully moves
            while (true) {
                // Prompt the player
                Console.Write("Select Tile To Move To: ");
                char[] coords = Console.ReadLine().ToUpper().ToCharArray();

                // return false if the user leaves the field empty
                if (coords.Length == 0) {
                    success = false;
                    break;
                }
                else {
                    try {
                        // Parse the x coordinate from user input
                        move.X = Array.IndexOf(xAxis.Skip(1).ToArray(), coords[0]);

                        // Continue the loop if the user input is invalid
                        if (move.X == -1) {
                            PrintBoard();
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("Invalid Tile.");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }

                        // Parse the y coordinate from user input
                        move.Y = Int32.Parse(coords[1].ToString()) - 1; 
                    }

                    // Continue the loop if an exception is encountered (user input is invalid)
                    catch (System.Exception) {
                        PrintBoard();
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Invalid Tile.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    // Continue the loop if the selected tile is not is the list of possible moves
                    if (!possibleMoves.Contains((move.X, move.Y))) {
                        PrintBoard();
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Cant Move there.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    // The rest of the code in the for loop will only run once (if the move is valid)

                    // Replace the old position of the piece if an new empty piece
                    gameBoard[piece.position.Y, piece.position.X] = new Piece("empty", piece.position.X, piece.position.Y, ConsoleColor.Black, null, ' ');
                    
                    // If the tile we are moving to contains a king
                    if (gameBoard[move.Y, move.X].type == "king") {
                        // Declare the player who's turn it is the winner
                        winner = turn;
                    }

                    // Store the piece's old position to add move to move history list later
                    (int X, int Y) oldPos = (piece.position.X, piece.position.Y);

                    // Add the move the pieces's move history list
                    piece.moveHistory.Add((oldPos, (move.X, move.Y), gameBoard[move.Y, move.X]));
                    moveHistory.Add(((oldPos.X, oldPos.Y), (move.X, move.Y), piece, turn, gameBoard[move.Y, move.X]));

                    // Move the piece to its new position
                    gameBoard[move.Y, move.X] = piece;

                    // If the move is a castle
                    if (piece.type == "king" && Math.Abs(oldPos.X - move.X) == 2) {
                        // Information about the castling rook (default is the one to the left of the king)
                        int rookXPos = 0;
                        int newRookXPos = 3;

                        // If the player is castling to the right
                        if (move.X > oldPos.X) {
                            rookXPos = 7;
                            newRookXPos = 5;
                        }

                        // Add the move the lists of past moves
                        gameBoard[move.Y, rookXPos].moveHistory.Add(((move.X, rookXPos), (move.X,newRookXPos), gameBoard[move.Y,newRookXPos]));
                        moveHistory.Add(((rookXPos, move.Y), (newRookXPos, move.Y), gameBoard[move.Y, rookXPos], turn, gameBoard[move.Y,newRookXPos]));
                        
                        // Move the rook
                        gameBoard[move.Y,newRookXPos] = gameBoard[move.Y, rookXPos];
                        gameBoard[move.Y,newRookXPos].position = (newRookXPos, move.Y);
                        
                        // Replace the old tile with an empty piece
                        gameBoard[move.Y, rookXPos] = new Piece("empty", rookXPos, move.Y, ConsoleColor.Black, null, ' ');
                    }

                    // Update the piece object's postition
                    piece.position.X = move.X;
                    piece.position.Y = move.Y;

                    // Stop the loop
                    success = true;
                    break;
                }
            }

            // Loop over every move in the list of possible moves
            foreach ((int X, int Y) possibleMove in possibleMoves)
            {
                // Replace the 'move' type pieces from the game board with new empty pieces
                if (gameBoard[possibleMove.Y, possibleMove.X].type == "move") {
                    gameBoard[possibleMove.Y, possibleMove.X] = new Piece("empty", possibleMove.X, possibleMove.Y, ConsoleColor.Black, null, ' ');
                }
                // Revert all the pieces to their original color
                else { 
                    gameBoard[possibleMove.Y, possibleMove.X].color = gameBoard[possibleMove.Y, possibleMove.X].team.color;
                }
            }

            // Reset the list of possible moves
            possibleMoves =  new List<(int X, int Y)>();

            // Reset the color of the moved piece
            piece.color = piece.team.color;

            // Update board
            PrintBoard();

            return success;
        }
    }
}
