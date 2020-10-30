using System;
using System.Drawing;
using QuantizedFluid;

namespace QuantizedFluid.VisualConsole {
	public class Program {
		public static void Main() {
			var size = new Size(10, 10);
			const int quantizations = 10;
			var world = MakeWorld(size, quantizations);
			world[0, size.Height / 2].VelocityProbability.X[quantizations] = 1;
			world.NormalizeProbabilities();

			var visual = new ConsoleVisualizer(world);
			while (true) {
				var cmd = Console.ReadLine();
				if (cmd == "quit") return;
				
				world.Step();
				visual.Render();
			}
		}

		private static FluidWorld MakeWorld(Size size, int quantizations) {
			var world = new FluidWorld(size, quantizations);
			for (var x = 0; x < size.Width; x++) {
				for (var y = 0; y < size.Height; y++) {
					var point = new Point(x, y);
					world[point].NumberOfParticles = 10;
				}
			}
			return world;
		}
	}
}