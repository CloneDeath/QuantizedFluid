using System.Drawing;

namespace QuantizedFluid.Core.VelocityHistograms {
	public class VelocityDistribution {
		public Point Velocity { get; }
		public float Probability { get; }
		public Velocity2dProbability VelocityProbability { get; }

		public VelocityDistribution(Point velocity, float probability, Velocity2dProbability velocityProbability) {
			Velocity = velocity;
			Probability = probability;
			VelocityProbability = velocityProbability;
		}
	}
}