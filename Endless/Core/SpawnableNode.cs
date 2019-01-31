using System;
using Endless.Abstractions;

namespace Endless.Core
{
    public abstract class SpawnableNode
    {
        private readonly Point center;
        private readonly INodeContext context;
        private readonly Random rnd;

        public virtual int NodeSize { get; }

        protected SpawnableNode(Point center, INodeContext context)
        {
            this.center = center;
            this.context = context;

            rnd = InitializeRandom();
        }

        public virtual VisualObjects GetVisualObject()
        {
            return VisualObjects.None;
        }

        private Random InitializeRandom()
        {
            var seed = (int) (GetId() & int.MaxValue);
            seed = seed ^ ((NodeSize + 13) * 19);
            return new Random(seed);
        }

        public long GetId()
        {
            var x = (long) Math.Round(center.x * 1_000);
            var y = (long) Math.Round(center.y * 1_000);
            return y * 1_234_567L + x;
        }
    }
}
