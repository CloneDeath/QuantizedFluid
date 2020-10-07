﻿using System;
using System.Drawing;
using CorePixelEngine;
using QuantizedFluid.Core;

namespace QuantizedFluid {
	public static class Program {
		[STAThread]
		public static void Main() {
			var size = new Size(20, 20);
			const int quantizations = 10;
			var world = MakeWorld(size, quantizations);
			world[0, size.Height / 2].VelocityProbability.X[quantizations] = 1;
			world.NormalizeProbabilities();

			var visual = new FluidWorldVisualizer(world);
			if (visual.Construct(size.Width, size.Height, 10, 10, false, true) == RCode.OK) {
				visual.Start();
			}
		}

		private static FluidWorld MakeWorld(Size size, int quantizations) {
			var world = new FluidWorld(size, quantizations);
			for (var x = 0; x < size.Width; x++) {
				for (var y = 0; y < size.Height; y++) {
					var point = new Point(x, y);
					world[point].NumberOfParticles = 127000;
				}
			}
			return world;
		}
	}
}