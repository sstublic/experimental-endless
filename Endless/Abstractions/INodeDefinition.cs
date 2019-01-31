using System.Collections.Generic;
using Endless.Core;

namespace Endless.Abstractions
{
    public interface INodeDefinition
    {
        int NodeSize { get; }
        bool ShouldSpawn(INodeContext context);
        VisualObjects VisualObjectFactory(INodeContext context);
        List<AreaEffect> EffectsFactory(INodeContext context);
    }
}
