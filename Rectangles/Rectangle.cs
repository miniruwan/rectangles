using System;

namespace Rectangles
{
	public class Coordinate
	{
		public int X { get; set; }
		public int Y { get; set; }
		
		public Coordinate( int x, int y )
		{
			if ( x < 0 || y < 0 )
				throw new ArgumentException( "X and Y positions should be greater than 0." );
			
			X = x;
			Y = y;
		}
	}
}
