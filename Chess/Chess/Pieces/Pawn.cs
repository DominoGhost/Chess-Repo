using System.Collections.Generic;
using System.Drawing;
using Chess.Models;

namespace Chess.Pieces
{
    class Pawn : Piece
    {
        public bool HasMoved { get; set; }

        public Pawn(Image _pawnImage, bool _onWhiteTeam) : base(_pawnImage, _onWhiteTeam)
        {}

        public override List<Coords> Piece_Clicked()
        {
            List<Coords> moveableSpots = new List<Coords>();

            int newRow = Location.Row - 1;
            int newCol = Location.Column + 1;
            if (OnWhiteTeam)
            {
                // Checks if the pawn can attack diagonally
                if (CheckOutOfBounds(newRow, newCol))
                {
                    if (Chess.tiles[newRow, newCol].PieceOnTile != null)
                    {
                        if(Chess.tiles[newRow, newCol].PieceOnTile.OnWhiteTeam != OnWhiteTeam)
                        {
                            moveableSpots.Add(new Coords(-1, 1));
                        }
                    }
                }

                // Checks if the pawn can attack diagonally
                newRow = Location.Row - 1;
                newCol = Location.Column - 1;
                if (CheckOutOfBounds(newRow, newCol))
                {
                    if (Chess.tiles[newRow, newCol].PieceOnTile != null)
                    {
                        if (Chess.tiles[newRow, newCol].PieceOnTile.OnWhiteTeam != OnWhiteTeam)
                        {
                            moveableSpots.Add(new Coords(-1, -1));
                        }
                    }
                }

                // Checks if the pawn can move forward
                if (Chess.tiles[Location.Row - 1, Location.Column].PieceOnTile == null)
                {
                    moveableSpots.Add(new Coords(-1, 0));

                    if (!HasMoved)
                    {
                        if (Chess.tiles[Location.Row - 2, Location.Column].PieceOnTile == null)
                        {
                            moveableSpots.Add(new Coords(-2, 0));
                        }
                    }
                }
            }
            else
            {
                newRow = Location.Row + 1;
                newCol = Location.Column + 1;
                // Checks if the pawn can attack diagonally
                if (CheckOutOfBounds(newRow, newCol))
                {
                    if (Chess.tiles[newRow, newCol].PieceOnTile != null)
                    {
                        if (Chess.tiles[newRow, newCol].PieceOnTile.OnWhiteTeam != OnWhiteTeam)
                        {
                            moveableSpots.Add(new Coords(1, 1));
                        }
                    }
                }

                // Checks if the pawn can attack diagonally
                newRow = Location.Row + 1;
                newCol = Location.Column - 1;
                if (CheckOutOfBounds(newRow, newCol))
                {
                    if (Chess.tiles[newRow, newCol].PieceOnTile != null)
                    {
                        if (Chess.tiles[newRow, newCol].PieceOnTile.OnWhiteTeam != OnWhiteTeam)
                        {
                            moveableSpots.Add(new Coords(1, -1));
                        }
                    }
                }

                // Checks if the pawn can move forward
                if (Chess.tiles[Location.Row + 1, Location.Column].PieceOnTile == null)
                {
                    moveableSpots.Add(new Coords(1, 0));

                    if (!HasMoved)
                    {
                        if (Chess.tiles[Location.Row + 2, Location.Column].PieceOnTile == null)
                        {
                            moveableSpots.Add(new Coords(2, 0));
                        }
                    }
                }
            }

            return moveableSpots;
        }
    }
}
