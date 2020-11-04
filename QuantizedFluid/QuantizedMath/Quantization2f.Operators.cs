namespace QuantizedFluid.QuantizedMath {
	public partial class Quantization2f {
		public static Quantization2f operator *(Quantization2f left, float right) {
			return new Quantization2f(left.XQuantization * right, left.YQuantization * right);
		}
	}
}