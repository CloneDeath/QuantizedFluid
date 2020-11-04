using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1i_Tests_GetQuantumProbability : Quantization1i_Tests {
		[TestCase(1, -1, 1)]
		[TestCase(1, 0, 0)]
		[TestCase(1, 1, 1)]

		[TestCase(2, -2, 1)]
		[TestCase(2, -1, 0.5f)]
		[TestCase(2, 0, 0)]
		[TestCase(2, 1, 0.5f)]
		[TestCase(2, 2, 1)]
		
		[TestCase(10, 10, 1)]
		[TestCase(10, 7, 0.7f)]
		[TestCase(10, 5, 0.5f)]
		[TestCase(10, -3, 0.3f)]

		public void QuantumProbabilityIsCalculatedCorrectly(int quantizations, int quantum, float expectedProbability) {
			var q = new Quantization1i(quantizations);

			var probability = q.GetQuantumProbability(quantum);

			probability.Should().Be(expectedProbability);
		}
	}
}