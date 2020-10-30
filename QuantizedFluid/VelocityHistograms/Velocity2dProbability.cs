using System.Collections.Generic;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.VelocityHistograms {
	public class Velocity2dProbability : Quantization2f {
		public Quantization1f X => XQuantization;
		public Quantization1f Y => YQuantization;
		
		public Velocity2dProbability(int quantizations) : base(quantizations) { }

		public Velocity2dProbability(IEnumerable<float> x, IEnumerable<float> y) : base(x, y) { }
		public Velocity2dProbability(Quantization1f x, Quantization1f y) : base(x, y) { }

		public static Velocity2dProbability operator *(Velocity2dProbability left, float right) {
			return new Velocity2dProbability(left.X * right, left.Y * right);
		}

		public static Velocity2dProbability operator +(Velocity2dProbability left, Velocity2dProbability right) {
			return new Velocity2dProbability(left.X + right.X, left.Y + right.Y);
		}

		public new Velocity2dProbability Normalized => new Velocity2dProbability(X.Normalized, Y.Normalized);
	}
}