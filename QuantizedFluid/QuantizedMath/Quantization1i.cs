using System.Collections.Generic;
using System.Linq;

namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization1i : Quantization1<int> {
		public Quantization1i(int quantizations) : base(quantizations) { }
		public Quantization1i(IEnumerable<int> values) : base(values) { }

		public int Total => Values.Sum();
	}
}