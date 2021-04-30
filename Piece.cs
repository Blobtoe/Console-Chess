using System;
using System.Collections.Generic;

namespace chess {

    /// <summary>
    /// Non-static class that represents a piece
    /// </summary>
    public class Piece {
        /// <summary> The type of the piece </summary>
        public string type;

        /// <summary> The piece's postition </summary>
        public (int X, int Y) position;

        /// <summary> The piece's symbol </summary>
        public char symbol;

        /// <summary> The piece's color </summary>
        public ConsoleColor color;

        /// <summary> The piece's team </summary>
        public Player team;

        /// <summary> The list of all the piece's past moves </summary>
        public List<((int X, int Y) from, (int X, int Y) to, Piece replacedPiece)> moveHistory = new List<((int X, int Y) from, (int X, int Y) to, Piece replacedPiece)>();


        /// <summary>
        /// Piece constructor
        /// </summary>
        public Piece(string inputType, int inputXPos, int inputYPos, ConsoleColor inputColor, Player inputTeam, char inputSymbol) {
            type = inputType;
            position.X = inputXPos;
            position.Y = inputYPos;
            color = inputColor;
            team = inputTeam;
            symbol = inputSymbol;
        }

        /// <summary>
        /// Get a list of possible tiles this piece can move to
        /// </summary>
        public List<(int, int)> GetPossibleMoves() {
            List<(int, int)> possibleMoves = new List<(int, int)>();

            // Get possible moves depending the piece's type
            switch (type)
            {
                case "rook":
                    possibleMoves = Rook.GetPossibleMoves(this);
                    break;
                case "knight":
                    possibleMoves = Knight.GetPossibleMoves(this);
                    break;
                case "bishop":
                    possibleMoves = Bishop.GetPossibleMoves(this);
                    break;
                case "king":
                    possibleMoves = King.GetPossibleMoves(this);
                    break;
                case "queen":
                    possibleMoves = Queen.GetPossibleMoves(this);
                    break;
                case "pawn":
                    possibleMoves = Pawn.GetPossibleMoves(this);
                    break;
                case "empty":
                    symbol = ' ';
                    break;
                case "move":
                    symbol = '#';
                    break;
            }
            return possibleMoves;
        }
    }
}