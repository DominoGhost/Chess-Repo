using System.Collections.Generic;
using System.Drawing;

namespace Chess.Pieces
{
    class Queen : Piece
    {
        public Queen(Image _queenImage, bool _onWhiteTeam) : base(_queenImage, _onWhiteTeam)
        { }

        public override List<Point> Piece_Clicked()
        {
            List<Point> moveableSpots = new List<Point>();

            // Vertical/Horizontal Movement
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


            // Diagonal Movement
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
                if (CanMoveToTile(--tempRow, ++xCounter))
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
