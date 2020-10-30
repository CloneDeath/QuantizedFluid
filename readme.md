A fluid simulator using quantized particle positions and velocities.

Particle positions are approximated and grouped into cells.
Velocities are approximated by splitting the X and Y velocities into seperate vectors, and maintaining probability distributions of particles across the two vectors.