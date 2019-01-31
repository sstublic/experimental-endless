using System;
using System.Collections.Generic;
using System.Linq;
using Endless.Abstractions;

namespace Endless.Core
{
    public class NodeContext : INodeContext
    {
        private readonly List<AreaEffect> effects;
        public Point Center { get; }
        public int Size { get; }
        public Random Rnd { get; }

        public NodeContext(Point center, int size, int rootSeed, List<AreaEffect> effects)
        {
            this.effects = effects;
            this.Center = center;
            this.Size = size;

            Rnd = InitializeRandom(rootSeed);
        }

        public double GetEffectStrength(string id)
        {
            var sumEffects = effects.Where(a => a.id == id).Sum(a => a.PowerAt(Center));
            return sumEffects;
        }

        private Random InitializeRandom(int rootSeed)
        {
            var seed = (int)(GetId() & int.MaxValue);
            seed = seed ^ ((Size + 13) * 19);
            return new Random(seed ^ rootSeed);
        }

        public long GetId()
        {
            var x = (long)Math.Round(Center.x * 1_000);
            var y = (long)Math.Round(Center.y * 1_000);
            return y * 1_234_567L + x;
        }
    }
}
