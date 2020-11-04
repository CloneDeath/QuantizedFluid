using System;
using System.Collections.Generic;
using System.Linq;
using QuantizedFluid.Exceptions;

namespace QuantizedFluid.QuantizedMath {
	public abstract class Quantization1<TType> {
		public int Quantizations { get; }
		protected readonly TType[] Values;

		public TType[] GetValues() => Values.ToArray();

		protected Quantization1(int quantizations) {
			Quantizations = quantizations;
			Values = new TType[quantizations*2 + 1];
		}
		
		protected Quantization1(IEnumerable<TType> values) {
			Values = values.ToArray();
			if (Values.Length % 2 != 1) throw new EvenNumberQuantizationArrayLengthException<TType>(Values);
			
			Quantizations = Values.Length / 2;
		}
		
		protected int QuantumToIndex(int quantum) => quantum + Quantizations;

		public TType this[int quantum] {
			get => Values[QuantumToIndex(quantum)];
			set => Values[QuantumToIndex(quantum)] = value;
		}
		
		public float GetQuantumProbability(int quantum) {
			return Math.Abs(quantum) * 1.0f / Quantizations;
		}
	}
}