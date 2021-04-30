using System.Collections.Generic;

namespace chess {

    /// <summary>
    /// Static class for bishops
    /// </summary>
    public static class Bishop {

        /// <summary> The the symbol that represents a bishop on the board </summary>
        public static char symbol = 'B';

        /// <summary> Get all the possible tiles a bishop can move to given a position </summary>
        public static List<(int, int)> GetPossibleMoves(Piece piece) {
            // Get the position of the specified piece
            int x = piece.position.X;
            int y = piece.position.Y;

            // Instantiate the list of possible moves
            List<(int, int)> possibleMoves = new List<(int, int)>();

            // Loop over overy tile diagonally down and right from the piece
            int j = y + 1;
            for (int i = x + 1; i < 8; i++)
            {
                // If the tile is empty
                if (j < 8 && Game.gameBoard[j, i].type == "empty") {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, j));
                }

                // If the tile is not empty, check if the piece on that tile is not on our team
                else if (j < 8 && Game.gameBoard[j, i].team.id != piece.team.id) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, j));
                    
                    // Stop the loop
                    break;
                }

                // The tile contains a piece on our team
                else {
                    // Stop the loop
                    break;
                }
                j++;
            }

            // Loop over overy tile diagonally up and right from the piece
            j = y - 1;
            for (int i = x + 1; i < 8; i++)
            {
                // If the tile is empty
                if (j >= 0 && Game.gameBoard[j, i].type == "empty") {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, j));
                }

                // If the tile is not empty, check if the piece on that tile is not on our team
                else if (j >= 0 && Game.gameBoard[j, i].team.id != piece.team.id) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, j));

                    // Stop the loop
                    break;
                }

                // The tile contains a piece on our team
                else {
                    // Stop the loop
                    break;
                }
                j--;
            }

            // Loop over overy tile diagonally down and left from the piece
            j = y + 1;
            for (int i = x - 1; i >= 0; i--)
            {
                // If the tile is empty
                if (j < 8 && Game.gameBoard[j, i].type == "empty") {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, j));
                }

                // If the tile is not empty, check if the piece on that tile is not on our team
                else if (j < 8 && Game.gameBoard[j, i].team.id != piece.team.id) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, j));

                    // Stop the loop
                    break;
                }

                // The tile contains a piece on our team
                else {
                    // Stop the loop
                    break;
                }
                j++;
            }

            // Loop over overy tile diagonally up and left from the piece
            j = y - 1;
            for (int i = x - 1; i >= 0; i--)
            {
                // If the tile is empty
                if (j >= 0 && Game.gameBoard[j, i].type == "empty") {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, j));
                }

                // If the tile is not empty, check if the piece on that tile is not on our team
                else if (j >= 0 && Game.gameBoard[j, i].team.id != piece.team.id) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((i, j));

                    // Stop the loop
                    break;
                }

                // The tile contains a piece on our team
                else {
                    // Stop the loop
                    break;
                }
                j--;
            }

            // Return the list of possible moves
            return possibleMoves;
        }
    }
}