using System.Collections.Generic;

namespace chess {

    /// <summary>
    /// Static class for knights
    /// </summary>
    public static class Knight {

        /// <summary> The the symbol that represents a kight on the board </summary>
        public static char symbol = 'N';

        /// <summary> Get all the possible tiles a bishop can move to given a position </summary>
        public static List<(int, int)> GetPossibleMoves(Piece piece) {
            // Get the position of the specified piece
            int x = piece.position.X;
            int y = piece.position.Y;

            // Instatiate the list of possible moves
            List<(int, int)> possibleMoves = new List<(int, int)>();

            // If the tile 2 tiles over to the right of the rook exists
            if (x + 2 < 8) {
                // If the tile 2 tiles over to the right and one tile down from the rook exists
                if (y + 1 < 8) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y + 1, x + 2].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x + 2, y + 1));
                    }
                }

                // If the tile 2 tiles over to the right and one tile up from the rook exists
                if (y - 1 >= 0) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y - 1, x + 2].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x + 2, y - 1));
                    }
                }
            }

            // If the tile 2 tiles over to the left of the rook exists
            if (x - 2 >= 0) {
                // If the tile 2 tiles over to the left and one tile down from the rook exists
                if (y + 1 < 8) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y + 1, x - 2].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x - 2, y + 1));
                    }
                }

                // If the tile 2 tiles over to the left and one tile up from the rook exists
                if (y - 1 >= 0) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y - 1, x - 2].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x - 2, y - 1));
                    }
                }
            }

            // If the tile 2 tiles below the rook exists
            if (y + 2 < 8) {
                // If the tile 2 tiles below and one tile to the right from the rook exists
                if (x + 1 < 8) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y + 2, x + 1].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x + 1, y + 2));
                    }
                }

                // If the tile 2 tiles below and one tile to the left from the rook exists
                if (x - 1 >= 0) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y + 2, x - 1].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x - 1, y + 2));
                    }
                }
            }

            // If the tile 2 tiles above the rook exists
            if (y - 2 >= 0) {
                // If the tile 2 tiles above and one tile to the right from the rook exists
                if (x + 1 < 8) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y - 2, x + 1].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x + 1, y - 2));
                    }
                }

                // If the tile 2 tiles above and one tile to the left from the rook exists
                if (x - 1 >= 0) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y - 2, x - 1].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x - 1, y - 2));
                    }
                }
            }

            // Return the list of possible moves
            return possibleMoves;
        }
    }
}