using System.Collections.Generic;

namespace chess {

    /// <summary>
    /// Static class for kings
    /// </summary>
    public static class King {

        /// <summary> The the symbol that represents a king on the board </summary>
        public static char symbol = 'K';

        /// <summary> Get all the possible tiles a king can move to given a position </summary>
        public static List<(int, int)> GetPossibleMoves(Piece piece) {
            // Get the position of the specified piece
            int x = piece.position.X;
            int y = piece.position.Y;

            // Instatiate the list of possible moves
            List<(int, int)> possibleMoves = new List<(int, int)>();

            // If the tile to the right of the piece exists
            if (x + 1 < 8) {
                // If the tile is empty (null team) or contains a piece on the other team
                if (Game.gameBoard[y, x + 1].team != piece.team) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x + 1, y));
                }
                if (y + 1 < 8) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y + 1, x + 1].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x + 1, y + 1));
                    }
                }
                if (y - 1 >= 0) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y - 1, x + 1].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x + 1, y - 1));
                    }
                }
            }

            // If the tile to the left of the piece exists
            if (x - 1 >= 0) {
                // If the tile is empty (null team) or contains a piece on the other team
                if (Game.gameBoard[y, x - 1].team != piece.team) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x - 1, y));
                }
                if (y + 1 < 8) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y + 1, x - 1].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x - 1, y + 1));
                    }
                }
                if (y - 1 >= 0) {
                    // If the tile is empty (null team) or contains a piece on the other team
                    if (Game.gameBoard[y - 1, x - 1].team != piece.team) {
                        // Add the tile to the list of possible moves
                        possibleMoves.Add((x - 1, y - 1));
                    }
                }
            }

            // If the tile below the piece exists
            if (y + 1 < 8) {
                // If the tile is empty (null team) or contains a piece on the other team
                if (Game.gameBoard[y + 1, x].team != piece.team) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x, y + 1));
                }
            }

            // If the tile above the piece exists
            if (y - 1 >= 0) {
                // If the tile is empty (null team) or contains a piece on the other team
                if (Game.gameBoard[y - 1, x].team != piece.team) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x, y - 1));
                }
            }

            // Return the list of possible moves
            return possibleMoves;
        }
    }
}