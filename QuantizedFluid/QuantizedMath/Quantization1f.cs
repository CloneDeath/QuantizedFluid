using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization1f : Quantization1<float> {
		public Quantization1f(int quantizations) : base(quantizations) { }
		public Quantization1f(IEnumerable<float> values) : base(values) { }
		
		public float Total => Values.Sum();

		public Quantization1f Normalized {
			get {
				var values = Values.ToArray();
				var total = values.Sum();
				if (Math.Abs(total) <= 0) throw new DivideByZeroException();
				
				for (var i = 0; i < values.Length; i++) {
					values[i] /= total;
				}
				return new Quantization1f(values);
			}
		}
	}
}