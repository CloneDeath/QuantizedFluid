using System.Collections.Generic;

namespace QuantizedFluid.QuantizedMath {
	public class Quantization2f {
		protected Quantization1f XQuantization { get; }
		protected Quantization1f YQuantization { get; }

		public float Total => XQuantization.Total; 

		public Quantization2f(int quantizations) {
			XQuantization = new Quantization1f(quantizations);
			YQuantization = new Quantization1f(quantizations);
		}

		public Quantization2f(IEnumerable<float> x, IEnumerable<float> y) {
			XQuantization = new Quantization1f(x);
			YQuantization = new Quantization1f(y);
		}

		public Quantization2f(Quantization1f x, Quantization1f y) : this(x.GetValues(), y.GetValues()) { }

		public Quantization2f Normalized => new Quantization2f(XQuantization.Normalized, YQuantization.Normalized);
	}
}