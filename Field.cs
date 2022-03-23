using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tic_tac_toe
{
    public class Field
    {
        public Point drawPoint { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int value { get; set; }

        public Field()
        {
            value = -1;
        }

        public Field(Point _drawPoint, int _width, int _height)
        {
            value = -1;
            drawPoint = _drawPoint;
            width = _width;
            height = _height;
        }
    }
}
