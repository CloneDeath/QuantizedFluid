using System;

namespace QuantizedFluid.Exceptions {
	public class EvenNumberQuantizationArrayLengthException<T> : Exception {
		public readonly T[] Values;
		public int Length => Values.Length;
		
		public EvenNumberQuantizationArrayLengthException(T[] values) 
			: base($"An even number of values ({values.Length}) were used to create a quantization." 
			       + " Only odd-length arrays are valid.") {
			Values = values;
		}
	}
}