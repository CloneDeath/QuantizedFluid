using System;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Exceptions {
	public class QuantizationsMismatchException<TType> : Exception {
		public readonly Quantization1<TType> Quantization1;
		public readonly Quantization1<TType> Quantization2;

		public QuantizationsMismatchException(Quantization1<TType> q1, Quantization1<TType> q2)
			: base($"Quantizations {q1.Quantizations} can not be mixed with Quantizations {q2.Quantizations}."
				+ " Both Quantization arrays must have the same number of Quantizations.") {
			Quantization1 = q1;
			Quantization2 = q2;
		}
	}
}