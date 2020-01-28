using System.Collections.Generic;
using System.Drawing;
using Chess.Models;

namespace Chess.Pieces
{
    abstract class Piece
    {
        protected bool reachedFirstEnemy = false;
        public Coords Location = new Coords(0, 0);

        public Piece(Image _pieceImage, bool _onWhiteTeam)
        {
            PieceImage = _pieceImage;
            OnWhiteTeam = _onWhiteTeam;
        }

        // Allows other pieces to have their own moveset
        public abstract List<Coords> Piece_Clicked();
        public Image PieceImage { get; }

        protected bool CanMoveToTile(int newRow, int newCol)
        {
            newRow += Location.Row;
            newCol += Location.Column;

            if (CheckOutOfBounds(newRow, newCol))
            {
                if ((Chess.tiles[newRow, newCol].PieceOnTile == null ||
                    Chess.tiles[newRow, newCol].PieceOnTile.OnWhiteTeam != OnWhiteTeam) && !reachedFirstEnemy)
                {
                    if(Chess.tiles[newRow, newCol].PieceOnTile != null)
                    {
                        reachedFirstEnemy = true;
                    }

                    return true;
                }
            }

            return false;

        }

        protected bool CheckOutOfBounds(int newRow, int newCol)
        {
            if (newRow < Chess.MAX_TILES && newRow >= 0 && newCol < Chess.MAX_TILES && newCol >= 0)
            {
                return true;
            }

            return false;
        }

        public bool OnWhiteTeam { get; }
    }
}
