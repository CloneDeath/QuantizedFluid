using System;
using QuantizedFluid.Core;

namespace QuantizedFluid.VisualConsole {
	public class ConsoleVisualizer {
		private readonly FluidWorld _world;

		public ConsoleVisualizer(FluidWorld world) {
			_world = world;
		}

		public void Render() {
			Console.WriteLine("Taking Step");
			SetPixels();
		}

		protected void SetPixels() {
			for (var y = 0; y < _world.Height; y++) {
				for (var x = 0; x < _world.Width; x++) {
					var count = _world[x, y].NumberOfParticles;
					Console.Write($"{count}\t");
				}
				Console.WriteLine();
			}
		}
	}
}