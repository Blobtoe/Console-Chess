using System.Collections.Generic;

namespace chess {

    /// <summary>
    /// Static class for rooks
    /// </summary>
    public static class Rook {

        /// <summary> The the symbol that represents a rook on the board </summary>
        public static char symbol = 'R';

        /// <summary> Get all the possible tiles a rook can move to given a position </summary>
        public static List<(int, int)> GetPossibleMoves(Piece piece) {
            // Get the position of the specified piece
            int x = piece.position.X;
            int y = piece.position.Y;

            // Instantiate the list of possible moves
            List<(int, int)> possibleMoves = new List<(int, int)>();

            // Loop over every tile to the right of the piece
            for (int i = x + 1; i < 8; i++)
            {
                // If the tile is empty
                if (Game.gameBoard[y, i].type == "empty") {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, y));
                }

                // If the tile is not empty, check if the piece on that tile is not on our team
                else if (Game.gameBoard[y, i].team.id != piece.team.id) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, y));
                    
                    // Stop the loop
                    break;
                }

                // The tile contains a piece on our team
                else {
                    // Stop the loop
                    break;
                }
            }

            // Loop over every tile to the left of the piece
            for (int i = x - 1; i >= 0; i--)
            {
                // If the tile is empty
                if (Game.gameBoard[y, i].type == "empty") {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, y));
                }

                // If the tile is not empty, check if the piece on that tile is not on our team
                else if (Game.gameBoard[y, i].team.id != piece.team.id) {
                    possibleMoves.Add((i, y));
                    
                    // Stop the loop
                    break;
                }

                // The tile contains a piece on our team
                else {
                    // Stop the loop
                    break;
                }
            }

            // Loop over every tile below the piece
            for (int i = y + 1; i < 8; i++)
            {
                // If the tile is empty
                if (Game.gameBoard[i, x].type == "empty") {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x, i));
                }

                // If the tile is not empty, check if the piece on that tile is not on our team
                else if (Game.gameBoard[i, x].team.id != piece.team.id) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x, i));
                    
                    // Stop the loop
                    break;
                }

                // The tile contains a piece on our team
                else {
                    // Stop the loop
                    break;
                }
            }

            // Loop over every tile above the piece
            for (int i = y - 1; i >= 0; i--)
            {
                // If the tile is empty
                if (Game.gameBoard[i, x].type == "empty") {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x, i));
                }

                // If the tile is not empty, check if the piece on that tile is not on our team
                else if (Game.gameBoard[i, x].team.id != piece.team.id) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x, i));
                    
                    // Stop the loop
                    break;
                }

                // The tile contains a piece on our team
                else {
                    // Stop the loop
                    break;
                }
            }

            // Return the list of possible moves
            return possibleMoves;
        }
    }
}