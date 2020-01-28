using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    struct Coords
    {
        public int Row;
        public int Column;

        public Coords(int _row, int _col)
        {
            Row = _row;
            Column = _col;
        }

        public static Coords operator+(Coords a, Coords b)
        {
            return new Coords(a.Row + b.Row, a.Column + b.Column);
        }
    }
}
