using System;
using System.Collections.Generic;
using Endless.Abstractions;
using Endless.Core;
using Endless.NodeDefinitions;

namespace Endless
{
    class Program
    {
        static void Main(string[] args)
        {
            var definitions = new List<INodeDefinition>()
            {
                new Tree(),
                new FertileGround(),
                new BodyOfWater(),
                new WaterPoolObject()
            };

            var rootSeed = 1;
            var painter = new ConsolePainter(70, 70);

            var posX = 0;
            var posY = 0;
            var rnd = new Random();
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Rendering at position ({posX}, {posY}).");
                var renderEngine = new RenderEngine(definitions, rootSeed, 40);
                renderEngine.RenderNodes(new Point(posX, posY));
                painter.Paint(renderEngine, posX, posY);

                Console.WriteLine($"RootSeed={rootSeed}, press [R] to randomize seed or ARROW keys to move.");

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow) posX++;
                else if (key.Key == ConsoleKey.LeftArrow) posX--;
                else if (key.Key == ConsoleKey.UpArrow) posY--;
                else if (key.Key == ConsoleKey.DownArrow) posY++;
                else if (key.Key == ConsoleKey.R)
                {
                    rootSeed = rnd.Next();
                    posX = 0;
                    posY = 0;
                }
            }
        }
    }
}
