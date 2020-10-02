namespace QuantizedFluid.Core.VelocityHistograms {
	public class Velocity2dProbability {
		public VelocityProbability X { get; }
		public VelocityProbability Y { get; }
		public int Quantizations { get; }

		public Velocity2dProbability(int quantizations) {
			Quantizations = quantizations;
			X = new VelocityProbability(quantizations);
			Y = new VelocityProbability(quantizations);
		}

		public void NormalizeProbabilities() {
			X.NormalizeProbabilities();
			Y.NormalizeProbabilities();
		}
	}
}