using System.Collections.Generic;
using System.Linq;
using QuantizedFluid.Exceptions;

namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization1i {
		public int Quantizations { get; }
		private readonly int[] _values;
		
		public Quantization1i(int quantizations) {
			Quantizations = quantizations;
			_values = new int[quantizations*2 + 1];
		}

		public Quantization1i(IEnumerable<int> values) {
			_values = values.ToArray();
			if (_values.Length % 2 != 1) throw new EvenNumberQuantizationArrayLengthException<int>(_values);
			
			Quantizations = _values.Length / 2;
		}

		public int Total => _values.Sum();
		
		protected int QuantumToIndex(int quantum) => quantum + Quantizations;

		public int this[int quantum] {
			get => _values[QuantumToIndex(quantum)];
			set => _values[QuantumToIndex(quantum)] = value;
		}
	}
}