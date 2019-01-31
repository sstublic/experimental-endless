using System;
using System.Collections.Generic;
using System.Text;
using Endless.Abstractions;
using Endless.Core;

namespace Endless.NodeDefinitions
{
    public class WaterPoolObject : INodeDefinition
    {
        public int NodeSize => 2;
        public bool ShouldSpawn(INodeContext context)
        {
            return context.GetEffectStrength("body-water") > 0;
        }

        public VisualObjects VisualObjectFactory(INodeContext context)
        {
            return VisualObjects.Water;
        }

        public List<AreaEffect> EffectsFactory(INodeContext context)
        {
            return null;
        }
    }
}
