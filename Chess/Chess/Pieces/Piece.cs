using System.Collections.Generic;
using System.Drawing;

namespace Chess.Pieces
{
    abstract class Piece
    {
        protected int _x = 0;
        protected int _y = 0;
        protected int _row = 0;
        protected int _col = 0;
        protected Point _location = new Point(0, 0);
        protected bool reachedFirstEnemy = false;

        public Piece(Image _pieceImage, bool _onWhiteTeam)
        {
            PieceImage = _pieceImage;
            OnWhiteTeam = _onWhiteTeam;
        }

        // Allows other pieces to have their own moveset
        public abstract List<Point> Piece_Clicked();
        public Image PieceImage { get; }

        protected bool CanMoveToTile(int newRow, int newCol)
        {
            newRow += Row;
            newCol += Column;

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

        public static Point ConvertMovesToLocations(Point move, Point coords)
        {
            Point newCoords = new Point(coords.X + move.X, coords.Y + move.Y);

            return new Point(newCoords.X, Chess.MAX_TILES - 1 - newCoords.Y);
        }

        public int X {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                _col = value;
            }
        }

        public int Y 
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                _row = Chess.MAX_TILES - 1 - value;
            }
        }

        public int Row 
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
                _y = Chess.MAX_TILES - 1 - value;
            }
        }

        public int Column 
        {
            get
            {
                return _col;
            }
            set
            {
                _col = value;
                _x = value;
            }
        }

        public Point Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public bool OnWhiteTeam { get; }
    }
}
