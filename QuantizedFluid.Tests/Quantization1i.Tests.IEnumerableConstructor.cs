using System;
using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.Exceptions;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1i_Tests_IEnumerableConstructor : Quantization1i_Tests {
		[Test]
		public void PassedInValuesAreUsed() {
			var q = new Quantization1i(new[]{5, 1, 9});
			q[-1].Should().Be(5);
			q[0].Should().Be(1);
			q[1].Should().Be(9);
		}

		[Test]
		public void IfAnEvenNumberOfValuesIsPassedIn_AnExceptionIsThrown() {
			new Func<Quantization1i>(() => new Quantization1i(new[]{1, 2, 3, 4}))
				.Should().ThrowExactly<EvenNumberQuantizationArrayLengthException<int>>();
		}

		[Test]
		public void IfAnEmptyArrayIsPassedIn_AnExceptionIsThrown() {
			new Func<Quantization1i>(() => new Quantization1i(new int[0]))
				.Should().ThrowExactly<EvenNumberQuantizationArrayLengthException<int>>()
				.Which.Length.Should().Be(0);
		}
	}
}