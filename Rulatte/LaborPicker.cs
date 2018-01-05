using System.Collections.Generic;
using System.Linq;
using WhetStone.Guard;
using WhetStone.Looping;
using WhetStone.Random;


namespace Rulatte
{
    public class LaborPicker
    {
        public double sum { get; }
        public IEnumerable<(Labor labor, double weight)> candidates { get; }
        public RandomGenerator gen { get; }
        public LaborPicker(Profile profile, RandomGenerator gen = null)
        {
            IGuard<double> sumGuard = new Guard<double>();
            candidates = profile.labors.Where(a=>a.effectiveWeight > 0)
                .HookAggregate(sumGuard,(labor, d) => d+labor.effectiveWeight)
                .Select(a=>(labor: a,weight: a.effectiveWeight))
                .OrderBy(a=>a.weight).ToArray();
            this.sum = sumGuard.value;
            this.gen = gen ?? GlobalRandomGenerator.ThreadLocal();
        }
        public (Labor, double) pick((Labor labor, double weight) avoid = default((Labor labor, double weight)))
        {
            var d = gen.Double(0, sum);
            d -= avoid.weight;
            foreach (var (candidate, w) in candidates)
            {
                if (candidate == avoid.labor)
                    continue;
                if (d < w)
                    return (candidate, w);
                d -= w;
            }

            return avoid;
        }
    }
}
