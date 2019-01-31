using System;
using System.Collections.Generic;
using System.Text;
using Endless.Abstractions;
using Endless.Core;

namespace Endless.NodeDefinitions
{
    public class FertileGround : INodeDefinition
    {
        public int NodeSize { get; } = 40;
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
            var effect = new AreaEffect("fertile", context.Center, NodeSize / 2, context.Rnd.NextDouble() + 1);
            return new List<AreaEffect>() { effect };
        }
    }
}
