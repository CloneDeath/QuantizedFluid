using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1f_Tests_Total : Quantization1f_Tests {
		[Test]
		public void AbleToGetTheTotal() {
			var q = new Quantization1f(new[] {0.1f, 1.04f, 2f});
			q.Total.Should().BeApproximately(3.14f, 0.001f);
		}
	}
}