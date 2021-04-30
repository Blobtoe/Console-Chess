using System;
using System.Collections.Generic;

namespace chess {

    /// <summary>
    /// Non-static class that represent a player in the game
    /// </summary>
    public class Player {

        /// <summary> List of pieces that are on this player's team </summary>
        public List<Piece> pieces;

        /// <summary> Color that will be used to show the pieces  </summary>
        public ConsoleColor color = ConsoleColor.Blue;

        /// <summary> Player's name </summary>
        public string name;

        /// <summary> Player id (1 or 2) </summary>
        public int id;


        /// <summary>
        /// Player constructor
        /// </summary>
        public Player(int playerNumber, string name = "") {
            // Instantiate pieces list
            pieces = new List<Piece>();

            // If the player's name is not specified, use default names
            if (name == "") {
                if (playerNumber == 1) {
                    this.name = "Player 1";
                }
                else {
                    this.name = "Player 2";
                }
            }
            else {
                this.name = name;
            }

            // Set id
            this.id = playerNumber;

            // Change the y value of where the pieces are started depending on which team they're on
            int kingRow = 0;
            int pawnRow = 1;
            if (playerNumber == 2) {
                kingRow = 7;
                pawnRow = 6;
                color = ConsoleColor.Red;
            }

            // Instantiate all the team's pieces
            pieces.Add(new Piece("rook", 0, kingRow, color, this, Rook.symbol));
            pieces.Add(new Piece("knight", 1, kingRow, color, this, Knight.symbol));
            pieces.Add(new Piece("bishop", 2, kingRow, color, this, Bishop.symbol));
            pieces.Add(new Piece("queen", 3, kingRow, color, this, Queen.symbol));
            pieces.Add(new Piece("king", 4, kingRow, color, this, King.symbol));
            pieces.Add(new Piece("bishop", 5, kingRow, color, this, Bishop.symbol));
            pieces.Add(new Piece("knight", 6, kingRow, color, this, Knight.symbol));
            pieces.Add(new Piece("rook", 7, kingRow, color, this, Rook.symbol));
            pieces.Add(new Piece("pawn", 0, pawnRow, color, this, Pawn.symbol));
            pieces.Add(new Piece("pawn", 1, pawnRow, color, this, Pawn.symbol));
            pieces.Add(new Piece("pawn", 2, pawnRow, color, this, Pawn.symbol));
            pieces.Add(new Piece("pawn", 3, pawnRow, color, this, Pawn.symbol));
            pieces.Add(new Piece("pawn", 4, pawnRow, color, this, Pawn.symbol));
            pieces.Add(new Piece("pawn", 5, pawnRow, color, this, Pawn.symbol));
            pieces.Add(new Piece("pawn", 6, pawnRow, color, this, Pawn.symbol));
            pieces.Add(new Piece("pawn", 7, pawnRow, color, this, Pawn.symbol));
        }
    }
}