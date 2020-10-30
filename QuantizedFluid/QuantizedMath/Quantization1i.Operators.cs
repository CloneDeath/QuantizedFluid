using System.Linq;

namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization1i {
		public static Quantization1i operator *(Quantization1i left, int right) {
			return new Quantization1i(left._values.Select(p => p * right));
		}

		public static Quantization1i operator +(Quantization1i left, Quantization1i right) {
			var values = left._values.Select((value, index) => value + right._values[index]);
			return new Quantization1i(values);
		}
	}
}