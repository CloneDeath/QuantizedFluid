using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization2f_Tests_ConstructorInt : Quantization2f_Tests {
		[Test]
		public void AbleToCreateANewQuantization2() {
			var q = new Quantization2f(10);

			q.Total.Should().Be(0);
		}
	}
}