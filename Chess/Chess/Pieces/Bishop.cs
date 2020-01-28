using System.Collections.Generic;
using System.Drawing;

namespace Chess.Pieces
{
    class Bishop : Piece
    {
        public Bishop(Image _bishopImage, bool _onWhiteTeam) : base(_bishopImage, _onWhiteTeam)
        { }

        public override List<Point> Piece_Clicked()
        {
            List<Point> moveableSpots = new List<Point>();
            int tilesOnBoard = Chess.MAX_TILES - 1;

            int xCounter = 0;
            int yCounter = 0;
            int tempRow = 0;
            reachedFirstEnemy = false;

            // Moves the piece towards the bottom-right
            for (int i = Row; i < tilesOnBoard; i++)
            {
                if (CanMoveToTile(++tempRow, ++xCounter))
                {
                    moveableSpots.Add(new Point(xCounter, --yCounter));
                }
                else
                {
                    break;
                }
            }
            xCounter = 0;
            yCounter = 0;
            tempRow = 0;
            reachedFirstEnemy = false;

            // Moves the piece toward the top-right
            for (int i = Row; i > 0; i--)
            {
                if(CanMoveToTile(--tempRow, ++xCounter))
                {
                     moveableSpots.Add(new Point(xCounter, ++yCounter));
                }
                else
                {
                    break;
                }
            }
            xCounter = 0;
            yCounter = 0;
            tempRow = 0;
            reachedFirstEnemy = false;

            // Moves the piece towards the bottom-left
            for (int i = Row; i < tilesOnBoard; i++)
            {
                // Checks a temporary column if the piece would be to the very left column
                if (CanMoveToTile(++tempRow, --xCounter))
                {
                    moveableSpots.Add(new Point(xCounter, --yCounter));
                }
                else
                {
                    break;
                }
            }
            xCounter = 0;
            yCounter = 0;
            tempRow = 0;
            reachedFirstEnemy = false;

            // Moves the piece towards the top-left
            for (int i = Row; i > 0; i--)
            {
                // Checks a temporary column if the piece would be to the very left column
                if (CanMoveToTile(--tempRow, --xCounter))
                {
                    moveableSpots.Add(new Point(xCounter, ++yCounter));
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
