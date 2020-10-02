using System.Drawing;

namespace QuantizedFluid.Core.VelocityHistograms {
	public class VelocityDistribution {
		public Point Velocity { get; }
		public float Probability { get; }

		public VelocityDistribution(Point velocity, float probability) {
			Velocity = velocity;
			Probability = probability;
		}
	}
}