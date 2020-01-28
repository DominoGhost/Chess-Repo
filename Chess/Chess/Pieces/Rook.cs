using System.Collections.Generic;
using System.Drawing;
using Chess.Models;

namespace Chess.Pieces
{
    class Rook : Piece
    {
        public Rook(Image _rookImage, bool _onWhiteTeam) : base(_rookImage, _onWhiteTeam)
        { }

        public override List<Coords> Piece_Clicked()
        {
            List<Coords> moveableSpots = new List<Coords>();
            int arrayCounter = 0;
            int tilesOnBoard = Chess.MAX_TILES - 1;
            reachedFirstEnemy = false;

            // Moves the rook to the down
            for (int i = Location.Row; i < tilesOnBoard; i++)
            {
                if (CanMoveToTile(++arrayCounter, 0))
                {
                    moveableSpots.Add(new Coords(arrayCounter, 0));
                }
                else
                {
                    break;
                }
            }
            arrayCounter = 0;
            reachedFirstEnemy = false;

            // Moves the rook to the up
            for (int i = Location.Row; i > 0; i--)
            {
                if (CanMoveToTile(--arrayCounter, 0))
                {
                    moveableSpots.Add(new Coords(arrayCounter, 0));
                }
                else
                {
                    break;
                }
            }
            arrayCounter = 0;
            reachedFirstEnemy = false;

            // Moves the rook to the right
            for (int i = Location.Column; i < tilesOnBoard; i++)
            {
                if (CanMoveToTile(0, ++arrayCounter))
                {
                    moveableSpots.Add(new Coords(0, arrayCounter));
                }
                else
                {
                    break;
                }
            }
            arrayCounter = 0;
            reachedFirstEnemy = false;

            // Moves the rook to the left
            for (int i = Location.Column; i > 0; i--)
            {
                if (CanMoveToTile(0, --arrayCounter))
                {
                    moveableSpots.Add(new Coords(0, arrayCounter));
                }
                else
                {
                    break;
                }
            }

            return moveableSpots;
        }
    }
}
