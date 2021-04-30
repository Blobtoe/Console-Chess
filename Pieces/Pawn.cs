using System.Collections.Generic;

namespace chess {

    /// <summary>
    /// Static class for pawns
    /// </summary>
    public static class Pawn {

        /// <summary> The the symbol that represents a pawn on the board </summary>
        public static char symbol = 'P';

        /// <summary> Get all the possible tiles a pawn can move to given a position </summary>
        public static List<(int, int)> GetPossibleMoves(Piece piece) {

            // Get the position of the specified piece
            int x = piece.position.X;
            int y = piece.position.Y;

            // Change the direction of the move if the piece is on the bottom team
            int direction = 1;
            if (piece.team == Game.player2) {
                direction = -1;
            }

            // Instantiate the list of possible moves
            List<(int, int)> possibleMoves = new List<(int, int)>();

            // If the tile in front of the pawn exists
            if (y+(1*direction) < 8 && y+(1*direction) >= 0) {
                // If the tile in front of the pawn is empty
                if (Game.gameBoard[y+(1*direction), x].type == "empty") {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x, y+(1*direction)));
                }

                // If the tile diagonally to the right of the pawn contains a piece on the other team
                if (x + 1 < 8 && Game.gameBoard[y+(1*direction), x + 1].type != "empty" && Game.gameBoard[y+(1*direction), x + 1].team != piece.team) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x + 1, y+(1*direction)));
                }

                // If the tile diagonally to the left of the pawn contains a piece on the other team
                if (x - 1 >= 0 && Game.gameBoard[y+(1*direction), x - 1].type != "empty" && Game.gameBoard[y+(1*direction), x - 1].team != piece.team) {
                    // Add the tile to the list of possible moves
                    possibleMoves.Add((x - 1, y+(1*direction)));
                }
            }
            
            // If the tile 2 tiles in front of the pawn exists
            if (Game.gameBoard[y+(2*direction), x].type == "empty" && piece.moveHistory.Count == 0) {
                possibleMoves.Add((x, y+(2*direction)));
            }

            // Return the list of possible moves
            return possibleMoves;
        }
    }
}