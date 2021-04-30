using System.Collections.Generic;

namespace chess {

    /// <summary>
    /// Static class for queens
    /// </summary>
    public static class Queen {

        /// <summary> The the symbol that represents a queen on the board </summary>
        public static char symbol = 'Q';

        /// <summary> Get all the possible tiles a queen can move to given a position </summary>
        public static List<(int, int)> GetPossibleMoves(Piece piece) {
            // Get the position of the specified piece
            int x = piece.position.X;
            int y = piece.position.Y;

            // Instatiate the list of possible moves
            List<(int, int)> possibleMoves = new List<(int, int)>();


            // A queen's movement can be described as a rook and bishop put together

            // Add a rook's possible moves to the list
            possibleMoves = Rook.GetPossibleMoves(piece);

            // Add a bishop's possible moves to the list
            possibleMoves.AddRange(Bishop.GetPossibleMoves(piece));

            // Return the list of possible moves
            return possibleMoves;
        }
    }
}