using System.Collections.Generic;
using System.Drawing;
using Chess.Models;

namespace Chess.Pieces
{
    class King : Piece
    {
        public King(Image _kingImage, bool _onWhiteTeam) : base(_kingImage, _onWhiteTeam)
        { }

        public override List<Coords> Piece_Clicked()
        {
            List<Coords> moveableSpots = new List<Coords>();

            // Right
            if (CanMoveToTile(0, 1))
            {
                moveableSpots.Add(new Coords(0, 1));
                reachedFirstEnemy = false;
            }

            // Left
            if (CanMoveToTile(0, -1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Coords(0, -1));
            }

            // Down-Right
            if (CanMoveToTile(1, 1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Coords(1, 1));
            }

            // Down
            if (CanMoveToTile(1, 0))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Coords(1, 0));
            }

            // Down-Left
            if (CanMoveToTile(1, -1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Coords(1, -1));
            }

            // Up-Right
            if (CanMoveToTile(-1, 1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Coords(-1, 1));
            }

            // Up-Left
            if (CanMoveToTile(-1, -1))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Coords(-1, -1));
            }

            // Up
            if (CanMoveToTile(-1, 0))
            {
                reachedFirstEnemy = false;
                moveableSpots.Add(new Coords(-1, 0));
            }

            return moveableSpots;
        }
    }
}
