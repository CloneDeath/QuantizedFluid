using System.Collections.Generic;
using System.Drawing;
using QuantizedFluid.VelocityHistograms;

namespace QuantizedFluid {
	public class FluidCell {
		public Point Position { get; }
		public int Quantizations { get; }
		
		public int NumberOfParticles { get; set; }
		public Velocity2dProbability VelocityProbability { get; set; }

		public FluidCell(Point position, int quantizations) {
			Position = position;
			Quantizations = quantizations;
			VelocityProbability = new Velocity2dProbability(quantizations);
		}

		public void NormalizeProbabilities() {
			var x = VelocityProbability.X.Total != 0
				? VelocityProbability.X.Normalized.GetValues()
				: GetEqualProbabilityDistribution();
			var y = VelocityProbability.Y.Total != 0
				? VelocityProbability.Y.Normalized.GetValues()
				: GetEqualProbabilityDistribution();
			VelocityProbability = new Velocity2dProbability(x, y);
		}

		private IEnumerable<float> GetEqualProbabilityDistribution() {
			for (var i = 0; i < Quantizations * 2 + 1; i++) {
				yield return 1.0f/(Quantizations * 2 + 1);
			}
		}
	}
}