using System.Collections.Generic;
using System.Drawing;

namespace Chess.Pieces
{
    class Knight : Piece
    {
        public Knight(Image _knightImage, bool _onWhiteTeam) : base(_knightImage, _onWhiteTeam)
        { }

        public override List<Point> Piece_Clicked()
        {
            List<Point> moveableSpots = new List<Point>();

            reachedFirstEnemy = false;
            int tempRow = Row + 2;
            int tempColumn = Column + 1;

            // Down-Right
            if (CanMoveToTile(2, 1))
            {
                moveableSpots.Add(new Point(1, -2));
            }

            // Down-Left
            reachedFirstEnemy = false;
            tempColumn = Column - 1;
            if (CanMoveToTile(2, -1))
            {
                moveableSpots.Add(new Point(-1, -2));
            }

            // Left-Down
            reachedFirstEnemy = false;
            tempColumn = Column - 2;
            tempRow = Row + 1;
            if (CanMoveToTile(1, -2))
            {
                moveableSpots.Add(new Point(-2, -1));
            }

            // Left-Up
            reachedFirstEnemy = false;
            tempRow = Row - 1;
            if (CanMoveToTile(-1, -2))
            {
                moveableSpots.Add(new Point(-2, 1));
            }

            // Up-Left
            reachedFirstEnemy = false;
            tempRow = Row - 2;
            tempColumn = Column - 1;
            if (CanMoveToTile(-2, -1))
            {
                moveableSpots.Add(new Point(-1, 2));
            }

            // Up-Right
            reachedFirstEnemy = false;
            tempColumn = Column + 1;
            if (CanMoveToTile(-2, 1))
            {
                moveableSpots.Add(new Point(1, 2));
            }

            // Right-Up
            reachedFirstEnemy = false;
            tempRow = Row - 1;
            tempColumn = Column + 2;
            if (CanMoveToTile(-1, 2))
            {
                moveableSpots.Add(new Point(2, 1));
            }

            // Right-Down
            reachedFirstEnemy = false;
            tempRow = Row + 1;
            if (CanMoveToTile(1, 2))
            {
                moveableSpots.Add(new Point(2, -1));
            }

            return moveableSpots;
        }
    }
}
