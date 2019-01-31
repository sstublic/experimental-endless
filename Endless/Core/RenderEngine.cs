using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Endless.Abstractions;

namespace Endless.Core
{
    public class RenderEngine
    {
        private readonly List<INodeDefinition> nodes;
        private readonly int rootSeed;
        private readonly int renderSize;
        public List<(Point position, VisualObjects visualObject)> visualObjects;
        public List<AreaEffect> effects;

        public RenderEngine(List<INodeDefinition> nodes, int rootSeed, int renderSize)
        {
            this.nodes = nodes;
            this.rootSeed = rootSeed;
            this.renderSize = renderSize;
        }

        public void RenderNodes(Point origin)
        {
            visualObjects = new List<(Point position, VisualObjects visualObject)>();
            effects = new List<AreaEffect>();
            var bySize = nodes
                .GroupBy(a => a.NodeSize)
                .Select(a => (size: a.Key, nodes: a.ToList()))
                .OrderByDescending(a => a.size)
                .ToList();

            foreach (var nodesOfSize in bySize)
            {
                RenderNodesOfSize(nodesOfSize.size, nodesOfSize.nodes, origin);
            }
        }

        private void RenderNodesOfSize(int size, List<INodeDefinition> nodes, Point origin)
        {
            foreach (var nodeDefinition in nodes)
            {
                RenderSingleNode(nodeDefinition, origin);
            }
        }

        private void RenderSingleNode(INodeDefinition nodeDefinition, Point origin)
        {
            var sw = Stopwatch.StartNew();
            var spawnedCount = 0;
            var effectCount = 0;
            // lets spawn units in each direction
            var nodeCount = renderSize / nodeDefinition.NodeSize + 1;
            var nodeOffset = (x: (int) (origin.x / nodeDefinition.NodeSize), y: (int) (origin.y / nodeDefinition.NodeSize));
            for (var nodeY = -nodeCount; nodeY < nodeCount; nodeY++)
            {
                for (var nodeX = -nodeCount; nodeX < nodeCount; nodeX++)
                {
                    var center = new Point((nodeX + nodeOffset.x) * nodeDefinition.NodeSize, (nodeY + nodeOffset.y) * nodeDefinition.NodeSize);
                    var context = new NodeContext(center, nodeDefinition.NodeSize, rootSeed, effects); // shouldn't pass effects reference, but instead create a new collection for this nodecontext??
                    if (nodeDefinition.ShouldSpawn(context))
                    {
                        spawnedCount++;
                        var visualObject = nodeDefinition.VisualObjectFactory(context);
                        if (visualObject != VisualObjects.None) visualObjects.Add((context.Center, visualObject));

                        var nodeEffects = nodeDefinition.EffectsFactory(context);
                        if (nodeEffects != null)
                        {
                            effectCount += nodeEffects.Count;
                            effects.AddRange(nodeEffects);
                        }
                    }
                }
            }
            Console.WriteLine($"Spawned {spawnedCount} instances of '{nodeDefinition.GetType().Name}' and {effectCount} effects in {sw.Elapsed.TotalMilliseconds:0.0000} ms.");
        }
    }
}
