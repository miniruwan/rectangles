using System;

namespace Rectangles
{
	public class Coordinate
	{
		public Coordinate( int x, int y )
		{
			if ( x < 0 || y < 0 )
				throw new ArgumentException( "X and Y positions should be greater than or equal to 0." );

			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }
	}
}
