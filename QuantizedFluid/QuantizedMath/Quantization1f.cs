using System.Collections.Generic;
using System.Linq;

namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization1f : Quantization1<float> {
		public Quantization1f(int quantizations) : base(quantizations) { }
		public Quantization1f(IEnumerable<float> values) : base(values) { }
		
		public float Total => Values.Sum();
	}
}