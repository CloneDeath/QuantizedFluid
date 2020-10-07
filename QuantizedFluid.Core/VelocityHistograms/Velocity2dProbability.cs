using System;

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

		public Velocity2dProbability(VelocityProbability x, VelocityProbability y) {
			if (x.Quantizations != y.Quantizations) throw new Exception("X and Y quantizations don't match.");
			Quantizations = x.Quantizations;
			X = x;
			Y = y;
		}

		public void NormalizeProbabilities() {
			X.NormalizeProbabilities();
			Y.NormalizeProbabilities();
		}

		public static Velocity2dProbability operator *(Velocity2dProbability left, float right) {
			return new Velocity2dProbability(left.X * right, left.Y * right);
		}

		public static Velocity2dProbability operator +(Velocity2dProbability left, Velocity2dProbability right) {
			return new Velocity2dProbability(left.X + right.X, left.Y + right.Y);
		}
	}
}