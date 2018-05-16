﻿using System.Drawing;

namespace Domain.Entities
{
    public class Window : Element
    {
        public Point StartPoint;
        public Point EndPoint;
        public string sense;

        public Window()
        {
        }

        public Window(Point startPoint, Point endPoint, string sense)
        {
            this.sense = sense;
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

        public override void Draw(Graphics graphic)
        {
            if (sense.Equals("vertical")) {
                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                graphic.FillRectangle(blueBrush, StartPoint.X-4, StartPoint.Y-10, 8, 20);
            }
            else{
                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                graphic.FillRectangle(blueBrush, StartPoint.X-10, StartPoint.Y-4, 20, 8);
            }
        }

        public override bool Equals(object windowObject)
        {
            bool isEqual = false;
            if (windowObject != null && this.GetType().Equals(windowObject.GetType()))
            {
                Window window = (Window)windowObject;
                if ((this.StartPoint.Equals(window.StartPoint)))
                {
                    isEqual = true;
                }

            }
            return isEqual;
        }

    }
}
