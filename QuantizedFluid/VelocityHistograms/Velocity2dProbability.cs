using System.Collections.Generic;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.VelocityHistograms {
	public class Velocity2dProbability : Quantization2f {
		public Quantization1f X => XQuantization;
		public Quantization1f Y => YQuantization;
		
		public Velocity2dProbability(int quantizations) : base(quantizations) { }

		public Velocity2dProbability(IEnumerable<float> x, IEnumerable<float> y) : base(x, y) { }
		public Velocity2dProbability(Quantization1f x, Quantization1f y) : base(x, y) { }

		public Velocity2dProbability(Quantization2f copy) : base(copy.GetXValues(), copy.GetYValues()) { }
	}
}