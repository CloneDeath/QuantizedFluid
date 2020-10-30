using System.Linq;

namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization1i {
		public static Quantization1i operator *(Quantization1i left, int right) {
			return new Quantization1i(left._values.Select(p => p * right));
		}
	}
}