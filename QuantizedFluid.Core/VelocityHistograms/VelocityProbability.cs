using System.Linq;

namespace QuantizedFluid.Core.VelocityHistograms {
	public class VelocityProbability {
		private readonly float[] _probabilities;
		public int Quantizations { get; }

		public VelocityProbability(int quantizations) {
			Quantizations = quantizations;
			_probabilities = new float[quantizations*2 + 1];
			_probabilities[quantizations] = 1;
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
	}
}