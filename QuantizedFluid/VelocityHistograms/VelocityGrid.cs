using System;
using System.Collections.Generic;
using System.Drawing;

namespace QuantizedFluid.VelocityHistograms {
	public class VelocityGrid {
		private readonly VelocityDistribution[,] _distributions = new VelocityDistribution[3,3];

		public IEnumerable<VelocityDistribution> Distributions {
			get {
				for (var x = 0; x < 3; x++) {
					for (var y = 0; y < 3; y++) {
						yield return _distributions[x, y];
					}
				}
			}
		}
		
		public VelocityGrid(Velocity2dProbability probability) {
			var leftX = GetLeft(probability.X);
			var rightX = GetRight(probability.X);
			var middleX = 1f - leftX - rightX;
			var downY = GetRight(probability.Y);
			var upY = GetLeft(probability.X);
			var middleY = 1f - downY - upY;
			
			_distributions[0, 0] = GetDistribution(new Point(-1, -1), leftX * upY, probability);
			_distributions[1, 0] = GetDistribution(new Point(0, -1), middleX * upY, probability);
			_distributions[2, 0] = GetDistribution(new Point(1, -1), leftX * upY, probability);
			
			_distributions[0, 1] = GetDistribution(new Point(-1, 0), leftX * middleY, probability);
			_distributions[1, 1] = GetDistribution(new Point(0, 0), middleX * middleY, probability);
			_distributions[2, 1] = GetDistribution(new Point(1, 0), leftX * middleY, probability);
			
			_distributions[0, 2] = GetDistribution(new Point(-1, 1), leftX * downY, probability);
			_distributions[1, 2] = GetDistribution(new Point(0, 1), middleX * downY, probability);
			_distributions[2, 2] = GetDistribution(new Point(1, 1), leftX * downY, probability);
		}

		private VelocityDistribution GetDistribution(Point sector, float amount, Velocity2dProbability probability) {
			var velocity = new Velocity2dProbability(probability.Quantizations) * 0;
			for (var i = -probability.Quantizations; i <= probability.Quantizations; i++) {
				if (Math.Sign(sector.X) == 0) {
					velocity.X[i] = GetInvProbability(probability.X, i);
				}
				else if (Math.Sign(sector.X) == Math.Sign(i) && i != 0) {
					velocity.X[i] = GetProbability(probability.X, i);
				}

				if (Math.Sign(sector.Y) == 0) {
					velocity.Y[i] = GetInvProbability(probability.Y, i);
				}
				else if (Math.Sign(sector.Y) == Math.Sign(i)) {
					velocity.Y[i] = GetProbability(probability.Y, i);
				}
			}
			return new VelocityDistribution(sector, amount, velocity);
		}

		private float GetLeft(VelocityProbability probability) {
			var total = 0f;
			for (var i = 0; i < probability.Quantizations; i++) {
				var quantum = -(i + 1);
				total += GetProbability(probability, quantum);
			}
			return total;
		}
		
		private float GetRight(VelocityProbability probability) {
			var total = 0f;
			for (var i = 0; i < probability.Quantizations; i++) {
				var quantum = i + 1;
				total += GetProbability(probability, quantum);
			}
			return total;
		}

		private float GetInvProbability(VelocityProbability probability, int quantum) {
			var scale = quantum * 1.0f / probability.Quantizations;
			return probability[quantum] * (1f - scale);
		}
		
		private float GetProbability(VelocityProbability probability, int quantum) {
			var scale = quantum * 1.0f / probability.Quantizations;
			return probability[quantum] * scale;
		}
	}
}