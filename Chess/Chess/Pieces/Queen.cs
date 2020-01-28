using System.Collections.Generic;
using System.Drawing;
using Chess.Models;

namespace Chess.Pieces
{
    class Queen : Piece
    {
        public Queen(Image _queenImage, bool _onWhiteTeam) : base(_queenImage, _onWhiteTeam)
        { }

        public override List<Coords> Piece_Clicked()
        {
            // Diaganol
            List<Coords> moveableSpots = new List<Coords>();
            int tilesOnBoard = Chess.MAX_TILES - 1;

            int columnCounter = 0;
            int rowCounter = 0;
            int tempRow = 0;
            reachedFirstEnemy = false;

            // Moves the piece towards the bottom-right
            for (int i = Location.Row; i < tilesOnBoard; i++)
            {
                if (CanMoveToTile(++tempRow, ++columnCounter))
                {
                    moveableSpots.Add(new Coords(++rowCounter, columnCounter));
                }
                else
                {
                    break;
                }
            }
            columnCounter = 0;
            rowCounter = 0;
            tempRow = 0;
            reachedFirstEnemy = false;

            // Moves the piece toward the top-right
            for (int i = Location.Row; i > 0; i--)
            {
                if (CanMoveToTile(--tempRow, ++columnCounter))
                {
                    moveableSpots.Add(new Coords(--rowCounter, columnCounter));
                }
                else
                {
                    break;
                }
            }
            columnCounter = 0;
            rowCounter = 0;
            tempRow = 0;
            reachedFirstEnemy = false;

            // Moves the piece towards the bottom-left
            for (int i = Location.Row; i < tilesOnBoard; i++)
            {
                // Checks a temporary column if the piece would be to the very left column
                if (CanMoveToTile(++tempRow, --columnCounter))
                {
                    moveableSpots.Add(new Coords(++rowCounter, columnCounter));
                }
                else
                {
                    break;
                }
            }
            columnCounter = 0;
            rowCounter = 0;
            tempRow = 0;
            reachedFirstEnemy = false;

            // Moves the piece towards the top-left
            for (int i = Location.Row; i > 0; i--)
            {
                // Checks a temporary column if the piece would be to the very left column
                if (CanMoveToTile(--tempRow, --columnCounter))
                {
                    moveableSpots.Add(new Coords(--rowCounter, columnCounter));
                }
                else
                {
                    break;
                }
            }

            // Horizontal/Vertical
            int arrayCounter = 0;
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
