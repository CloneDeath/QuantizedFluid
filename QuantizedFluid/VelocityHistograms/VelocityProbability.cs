using System.Collections.Generic;
using System.Linq;

namespace QuantizedFluid.VelocityHistograms {
	public class VelocityProbability {
		private readonly float[] _probabilities;
		public int Quantizations { get; }

		public VelocityProbability(int quantizations) {
			Quantizations = quantizations;
			_probabilities = new float[quantizations*2 + 1];
			_probabilities[quantizations] = 1;
		}

		public VelocityProbability(IEnumerable<float> probabilities) {
			_probabilities = probabilities.ToArray();
			Quantizations = _probabilities.Length / 2;
		}

		protected int QuantumToIndex(int quantum) => quantum + Quantizations;
		public float this[int quantum] {
			get => _probabilities[QuantumToIndex(quantum)];
			set => _probabilities[QuantumToIndex(quantum)] = value;
		}

		public void NormalizeProbabilities() {
			var total = _probabilities.Sum();
			if (total == 0) {
				for (var i = 0; i < _probabilities.Length; i++) {
					_probabilities[i] = 1.0f / _probabilities.Length;
				}
			}
			else {
				for (var i = 0; i < _probabilities.Length; i++) {
					_probabilities[i] /= total;
				}
			}
		}

		public static VelocityProbability operator *(VelocityProbability left, float right) {
			return new VelocityProbability(left._probabilities.Select(p => p*right));
		}

		public static VelocityProbability operator +(VelocityProbability left, VelocityProbability right) {
			var values = new List<float>();
			for (var i = 0; i < left._probabilities.Length; i++) {
				values.Add(left._probabilities[i] + right._probabilities[i]);
			}
			return new VelocityProbability(values);
		}
	}
}