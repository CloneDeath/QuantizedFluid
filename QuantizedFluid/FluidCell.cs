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
			VelocityProbability.NormalizeProbabilities();
		}
	}
}