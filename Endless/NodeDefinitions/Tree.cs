using System;
using System.Collections.Generic;
using System.Text;
using Endless.Abstractions;
using Endless.Core;

namespace Endless.NodeDefinitions
{
    public class Tree : INodeDefinition
    {
        public int NodeSize => 3;
        public bool ShouldSpawn(INodeContext context)
        {
            if (context.GetEffectStrength("body-water") > 0) return false;
            return context.Rnd.NextDouble() < 0.02 + context.GetEffectStrength("fertile");
        }

        public VisualObjects VisualObjectFactory(INodeContext context)
        {
            return VisualObjects.Tree;
        }

        public List<AreaEffect> EffectsFactory(INodeContext context)
        {
            return null;
        }
    }
}
