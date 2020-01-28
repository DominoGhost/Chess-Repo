using System.Collections.Generic;
using System.Drawing;

namespace Chess.Pieces
{
    class Pawn : Piece
    {
        public bool HasMoved { get; set; }

        public Pawn(Image _pawnImage, bool _onWhiteTeam) : base(_pawnImage, _onWhiteTeam)
        {}

        public override List<Point> Piece_Clicked()
        {
            List<Point> moveableSpots = new List<Point>();

            int newRow = Row - 1;
            int newCol = Column + 1;
            if (OnWhiteTeam)
            {
                // Checks if the pawn can attack diagonally
                if (CheckOutOfBounds(newRow, newCol))
                {
                    if (Chess.tiles[newRow, newCol].PieceOnTile != null)
                    {
                        if(Chess.tiles[newRow, newCol].PieceOnTile.OnWhiteTeam != OnWhiteTeam)
                        {
                            moveableSpots.Add(new Point(1, 1));
                        }
                    }
                }

                // Checks if the pawn can attack diagonally
                newRow = Row - 1;
                newCol = Column - 1;
                if (CheckOutOfBounds(newRow, newCol))
                {
                    if (Chess.tiles[newRow, newCol].PieceOnTile != null)
                    {
                        if (Chess.tiles[newRow, newCol].PieceOnTile.OnWhiteTeam != OnWhiteTeam)
                        {
                            moveableSpots.Add(new Point(-1, 1));
                        }
                    }
                }

                // Checks if the pawn can move forward
                if (Chess.tiles[Row - 1, Column].PieceOnTile == null)
                {
                    moveableSpots.Add(new Point(0, 1));

                    if (!HasMoved)
                    {
                        if (Chess.tiles[Row - 2, Column].PieceOnTile == null)
                        {
                            moveableSpots.Add(new Point(0, 2));
                        }
                    }
                }
            }
            else
            {
                newRow = Row + 1;
                newCol = Column + 1;
                // Checks if the pawn can attack diagonally
                if (CheckOutOfBounds(newRow, newCol))
                {
                    if (Chess.tiles[newRow, newCol].PieceOnTile != null)
                    {
                        if (Chess.tiles[newRow, newCol].PieceOnTile.OnWhiteTeam != OnWhiteTeam)
                        {
                            moveableSpots.Add(new Point(1, -1));
                        }
                    }
                }

                // Checks if the pawn can attack diagonally
                newRow = Row + 1;
                newCol = Column - 1;
                if (CheckOutOfBounds(newRow, newCol))
                {
                    if (Chess.tiles[newRow, newCol].PieceOnTile != null)
                    {
                        if (Chess.tiles[newRow, newCol].PieceOnTile.OnWhiteTeam != OnWhiteTeam)
                        {
                            moveableSpots.Add(new Point(-1, -1));
                        }
                    }
                }

                // Checks if the pawn can move forward
                if (Chess.tiles[Row + 1, Column].PieceOnTile == null)
                {
                    moveableSpots.Add(new Point(0, -1));

                    if (!HasMoved)
                    {
                        if (Chess.tiles[Row + 2, Column].PieceOnTile == null)
                        {
                            moveableSpots.Add(new Point(0, -2));
                        }
                    }
                }
            }

            return moveableSpots;
        }
    }
}
