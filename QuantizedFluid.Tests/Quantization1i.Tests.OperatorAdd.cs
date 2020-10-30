using System;
using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.Exceptions;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1i_Tests_OperatorAdd : Quantization1i_Tests {
		[Test]
		public void AbleToAddTwoQuantizationsTogether() {
			var q1 = new Quantization1i(new[]{1, 2, 3, 4, 5});
			var q2 = new Quantization1i(new []{10, 100, 30, 14, 11});

			var result = q1 + q2;

			result.GetValues().Should().BeEquivalentTo(new[] {11, 102, 33, 18, 16});
		}
		
		[Test]
		public void IfTwoQuantizationsHaveDifferentLengths_AnExceptionIsThrown() {
			var q1 = new Quantization1i(10);
			var q2 = new Quantization1i(11);

			new Func<Quantization1i>(() => q1 + q2)
				.Should().ThrowExactly<QuantizationsMismatchException<int>>();
		}
	}
}