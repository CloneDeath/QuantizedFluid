using System.Drawing;

namespace QuantizedFluid.Core.VelocityHistograms {
	public class VelocityGrid {
		private readonly VelocityDistribution[,] _distributions = new VelocityDistribution[3,3];

		public VelocityGrid(Velocity2dProbability probability) {
			var leftX = GetLeft(probability.X);
			var rightX = GetRight(probability.X);
			var middleX = 1f - leftX - rightX;
			var downY = GetRight(probability.Y);
			var upY = GetLeft(probability.X);
			var middleY = 1f - downY - upY;
			
			_distributions[0, 0] = new VelocityDistribution(new Point(-1, -1), leftX * upY);
			_distributions[1, 0] = new VelocityDistribution(new Point(0, -1), middleX * upY);
			_distributions[2, 0] = new VelocityDistribution(new Point(1, -1), leftX * upY);
			
			_distributions[0, 1] = new VelocityDistribution(new Point(-1, 0), leftX * middleY);
			_distributions[1, 1] = new VelocityDistribution(new Point(0, 0), middleX * middleY);
			_distributions[2, 1] = new VelocityDistribution(new Point(1, 0), leftX * middleY);
			
			_distributions[0, 2] = new VelocityDistribution(new Point(-1, 1), leftX * downY);
			_distributions[1, 2] = new VelocityDistribution(new Point(0, 1), middleX * downY);
			_distributions[2, 2] = new VelocityDistribution(new Point(1, 1), leftX * downY);
		}

		private float GetLeft(VelocityProbability probability) {
			var total = 0f;
			for (var i = 0; i < probability.Quantizations; i++) {
				var quantum = -(i + 1);
				var scale = quantum * 1.0f / probability.Quantizations;
				var prob = probability[quantum];
				total += scale * prob;
			}
			return total;
		}
		
		private float GetRight(VelocityProbability probability) {
			var total = 0f;
			for (var i = 0; i < probability.Quantizations; i++) {
				var quantum = i + 1;
				var scale = quantum * 1.0f / probability.Quantizations;
				var prob = probability[quantum];
				total += scale * prob;
			}
			return total;
		}
	}
}