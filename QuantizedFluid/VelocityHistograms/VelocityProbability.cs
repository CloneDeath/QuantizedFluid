using System.Collections.Generic;
using System.Linq;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.VelocityHistograms {
	public class VelocityProbability : Quantization1f {
		public VelocityProbability(int quantizations) : base(quantizations) {
		}

		public VelocityProbability(IEnumerable<float> probabilities) : base(probabilities) {
		}

		public void NormalizeProbabilities() {
			var total = Values.Sum();
			if (total == 0) {
				for (var i = 0; i < Values.Length; i++) {
					Values[i] = 1.0f / Values.Length;
				}
			}
			else {
				for (var i = 0; i < Values.Length; i++) {
					Values[i] /= total;
				}
			}
		}

		public static VelocityProbability operator *(VelocityProbability left, float right) {
			return new VelocityProbability(((Quantization1f)left * right).GetValues());
		}
		
		public static VelocityProbability operator +(VelocityProbability left, VelocityProbability right) {
			return new VelocityProbability(((Quantization1f)left + right).GetValues());
		}
	}
}