using System.Windows.Forms;
using System.Drawing;
using Chess.Pieces;

namespace Chess
{
    class Tile : PictureBox
    {
        public Piece PieceToMove { get; set; } = null;
        public Piece PieceOnTile { get; set; } = null;
        public Image Background { get; set; }
    }
}
