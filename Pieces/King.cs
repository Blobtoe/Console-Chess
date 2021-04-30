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

            // If this piece hasn't moved AND the piece three tiles to the right is a rook AND the piece three tiles to the right hasn't moved AND if the two tiles in between them are empty
            if (piece.moveHistory.Count == 0 && Game.gameBoard[piece.position.Y, piece.position.X + 3].type == "rook" && Game.gameBoard[piece.position.Y, piece.position.X + 3].moveHistory.Count == 0 && Game.gameBoard[piece.position.Y, piece.position.X + 1].type == "empty" && Game.gameBoard[piece.position.Y, piece.position.X + 2].type == "empty") {
                // If the piece if on the team 1
                if (piece.team.id == 1) {
                    // Add G1 the the list of possible moves
                    possibleMoves.Add((6, 0));
                }

                // If the piece is on team 2
                else {
                    // Add G8 to the list of possible moves
                    possibleMoves.Add((6, 7));
                }
            }

            // Return the list of possible moves
            return possibleMoves;
        }
    }
}