using System;
using Endless.Core;

namespace Endless.Abstractions
{
    public interface INodeContext
    {
        Point Center { get; }
        Random Rnd { get; }
        double GetEffectStrength(string id);
    }
}
