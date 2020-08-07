﻿using GraphicEngine.Interceptors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEngine.DrawingObject
{
    public class DRectangle : GraphItem
    {
        [EllipseInterceptor]
        public int Width { get; set; }



        [EllipseInterceptor]
        public int Height { get; set; }

        internal override void OnDraw(Graphics graphics, Matrix mtx)
        {
            if (matrix != null && mtx != null)
            {
                var tmpMatrix = matrix.Clone();
                tmpMatrix.Multiply(mtx, MatrixOrder.Append);
                graphics.Transform = tmpMatrix;
            }
            else if (mtx != null)
            {
                graphics.Transform = mtx;
            }
            else if (matrix != null) {
                graphics.Transform = matrix;
            }
            if(Width < 0 && Height < 0)
            {
                graphics.FillRectangle(MyBrush, X + Width, Height + Y, -Width, -Height);
            }
            else if (Width < 0)
            {
                graphics.FillRectangle(MyBrush, X + Width, Y, -Width, Height);
            }
            else if (Height < 0)
            {
                graphics.FillRectangle(MyBrush, X , Height + Y, Width, -Height);
            }
            else
            {
                graphics.FillRectangle(MyBrush, X, Y, Width, Height);
            }
        }

        public override void DrawOnMove(Point point)
        {
            Width = point.X - X;
            Height = point.Y - Y;
        }

        public override bool IsContain(Point point)
        {
            throw new NotImplementedException();
        }
    }
}
