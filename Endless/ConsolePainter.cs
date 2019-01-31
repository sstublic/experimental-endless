using System;
using System.Collections.Generic;
using System.Text;
using Endless.Abstractions;
using Endless.Core;

namespace Endless
{
    public class ConsolePainter
    {
        private readonly int width;
        private readonly int height;
        private VisualObjects[,] buffer;

        public ConsolePainter(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Paint(RenderEngine renderEngine, int posX, int posY)
        {
            buffer = new VisualObjects[width + 1, height + 1];
            var minX = posX - width / 2;
            var maxX = posX + width / 2;
            var minY = posY - height / 2;
            var maxY = posY + height / 2;

            foreach (var visualObject in renderEngine.visualObjects)
            {
                if (visualObject.position.InBounds(minX, minY, maxX, maxY))
                {
                    buffer[(int) visualObject.position.x - minX, (int) visualObject.position.y - minY] = visualObject.visualObject;
                }
            }

            var text = "";
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var visualObject = buffer[x, y];
                    if (visualObject == VisualObjects.Water) text += " ~ ";
                    else if(visualObject == VisualObjects.Tree) text += " T ";
                    else text += "   ";
                }

                text += " |\n";
            }
            Console.WriteLine(text);
        }
    }
}
