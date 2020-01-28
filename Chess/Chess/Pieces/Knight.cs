using System.Collections.Generic;
using System.Drawing;
using Chess.Models;

namespace Chess.Pieces
{
    class Knight : Piece
    {
        public Knight(Image _knightImage, bool _onWhiteTeam) : base(_knightImage, _onWhiteTeam)
        { }

        public override List<Coords> Piece_Clicked()
        {
            List<Coords> moveableSpots = new List<Coords>();

            reachedFirstEnemy = false;
            int tempRow = Location.Row + 2;
            int tempColumn = Location.Column + 1;

            // Down-Right
            if (CanMoveToTile(2, 1))
            {
                moveableSpots.Add(new Coords(2, 1));
            }

            // Down-Left
            reachedFirstEnemy = false;
            tempColumn = Location.Column - 1;
            if (CanMoveToTile(2, -1))
            {
                moveableSpots.Add(new Coords(2, -1));
            }

            // Left-Down
            reachedFirstEnemy = false;
            tempColumn = Location.Column - 2;
            tempRow = Location.Row + 1;
            if (CanMoveToTile(1, -2))
            {
                moveableSpots.Add(new Coords(1, -2));
            }

            // Left-Up
            reachedFirstEnemy = false;
            tempRow = Location.Row - 1;
            if (CanMoveToTile(-1, -2))
            {
                moveableSpots.Add(new Coords(-1, -2));
            }

            // Up-Left
            reachedFirstEnemy = false;
            tempRow = Location.Row - 2;
            tempColumn = Location.Column - 1;
            if (CanMoveToTile(-2, -1))
            {
                moveableSpots.Add(new Coords(-2, -1));
            }

            // Up-Right
            reachedFirstEnemy = false;
            tempColumn = Location.Column + 1;
            if (CanMoveToTile(-2, 1))
            {
                moveableSpots.Add(new Coords(-2, 1));
            }

            // Right-Up
            reachedFirstEnemy = false;
            tempRow = Location.Row - 1;
            tempColumn = Location.Column + 2;
            if (CanMoveToTile(-1, 2))
            {
                moveableSpots.Add(new Coords(-1, 2));
            }

            // Right-Down
            reachedFirstEnemy = false;
            tempRow = Location.Row + 1;
            if (CanMoveToTile(1, 2))
            {
                moveableSpots.Add(new Coords(1, 2));
            }

            return moveableSpots;
        }
    }
}
