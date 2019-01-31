using System;
using System.Collections.Generic;
using System.Text;
using Endless.Abstractions;
using Endless.Core;

namespace Endless.NodeDefinitions
{
    public class BodyOfWater : INodeDefinition
    {
        public int NodeSize => 30;
        public bool ShouldSpawn(INodeContext context)
        {
            return context.Rnd.NextDouble() < 0.1;
        }

        public VisualObjects VisualObjectFactory(INodeContext context)
        {
            return VisualObjects.None;
        }

        public List<AreaEffect> EffectsFactory(INodeContext context)
        {
            return new List<AreaEffect>()
            {
                new AreaEffect("body-water", context.Center, context.Rnd.NextDouble() * 10 + 5, 100)
            };
        }
    }
}
