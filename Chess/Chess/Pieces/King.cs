using System.Collections.Generic;
using System.Drawing;

namespace Chess.Pieces
{
    class King : Piece
    {
        public King(Image _kingImage, bool _onWhiteTeam) : base(_kingImage, _onWhiteTeam)
        { }

        public override List<Point> Piece_Clicked()
        {
            List<Point> moveableSpots = new List<Point>();

            // Right
            if (CanMoveToTile(0, 1))
            {
                moveableSpots.Add(new Point(1, 0));
                reachedFirstEnemy = false;
            }

            // Left
            if (CanMoveToTile(0, -1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Point(-1, 0));
            }

            // Down-Right
            if (CanMoveToTile(1, 1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Point(1, -1));
            }

            // Down
            if (CanMoveToTile(1, 0))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Point(0, -1));
            }

            // Down-Left
            if (CanMoveToTile(1, -1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Point(-1, -1));
            }

            // Up-Right
            if (CanMoveToTile(-1, 1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Point(1, 1));
            }

            // Up-Left
            if (CanMoveToTile(-1, -1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Point(-1, 1));
            }

            // Up
            if (CanMoveToTile(-1, 0))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Point(0, 1));
            }

            return moveableSpots;
        }
    }
}
