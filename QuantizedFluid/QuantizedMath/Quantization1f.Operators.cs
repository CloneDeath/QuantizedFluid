using System.Linq;

namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization1f {
		public static Quantization1f operator *(Quantization1f left, float right) {
			return new Quantization1f(left.Values.Select(leftValue => leftValue * right));
		}
		
		public static Quantization1f operator +(Quantization1f left, Quantization1f right) {
			var values = left.Values.Select((leftValue, index) => leftValue + right.Values[index]);
			return new Quantization1f(values);
		}
	}
}