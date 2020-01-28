using System.Collections.Generic;
using System.Drawing;

namespace Chess.Pieces
{
    class Rook : Piece
    {
        public Rook(Image _rookImage, bool _onWhiteTeam) : base(_rookImage, _onWhiteTeam)
        { }

        public override List<Point> Piece_Clicked()
        {
            List<Point> moveableSpots = new List<Point>();
            int arrayCounter = 0;
            int coordCounter = 0;
            int tilesOnBoard = Chess.MAX_TILES - 1;
            reachedFirstEnemy = false;

            // Moves the rook to the down
            for (int i = Row; i < tilesOnBoard; i++)
            {
                if (CanMoveToTile(++arrayCounter, 0))
                {
                    moveableSpots.Add(new Point(0, --coordCounter));
                }
                else
                {
                    break;
                }
            }
            arrayCounter = 0;
            coordCounter = 0;
            reachedFirstEnemy = false;

            // Moves the rook to the up
            for (int i = Row; i > 0; i--)
            {
                if (CanMoveToTile(--arrayCounter, 0))
                {
                    moveableSpots.Add(new Point(0, ++coordCounter));
                }
                else
                {
                    break;
                }
            }
            arrayCounter = 0;
            coordCounter = 0;
            reachedFirstEnemy = false;

            // Moves the rook to the right
            for (int i = Column; i < tilesOnBoard; i++)
            {
                if (CanMoveToTile(0, ++arrayCounter))
                {
                    moveableSpots.Add(new Point(++coordCounter, 0));
                }
                else
                {
                    break;
                }
            }
            arrayCounter = 0;
            coordCounter = 0;
            reachedFirstEnemy = false;

            // Moves the rook to the left
            for (int i = Column; i > 0; i--)
            {
                if (CanMoveToTile(0, --arrayCounter))
                {
                    moveableSpots.Add(new Point(--coordCounter, 0));
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
