using System.Linq;

namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization1i {
		public static Quantization1i operator *(Quantization1i left, int right) {
			return new Quantization1i(left.Values.Select(leftValue => leftValue * right));
		}
		
		public static Quantization1f operator *(Quantization1i left, float right) {
			return new Quantization1f(left.Values.Select(leftValue => leftValue * right));
		}

		public static Quantization1i operator +(Quantization1i left, Quantization1i right) {
			var values = left.Values.Select((leftValue, index) => leftValue + right.Values[index]);
			return new Quantization1i(values);
		}
	}
}