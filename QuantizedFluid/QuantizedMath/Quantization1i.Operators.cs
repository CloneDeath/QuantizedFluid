using System.Linq;

namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization1i {
		public static Quantization1i operator *(Quantization1i left, int right) {
			return new Quantization1i(left.Values.Select(p => p * right));
		}

		public static Quantization1i operator +(Quantization1i left, Quantization1i right) {
			var values = left.Values.Select((value, index) => value + right.Values[index]);
			return new Quantization1i(values);
		}
	}
}