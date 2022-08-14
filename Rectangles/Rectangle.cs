using System;

namespace Rectangles
{
	public class Rectangle
	{
		public Rectangle( int width, int height, Coordinate baseCoordinate )
		{
			if ( width <= 0 || height <= 0 )
				throw new ArgumentException( "Width and height should be greater than 0." );

			Width = width;
			Height = height;
			BaseCoordinate = baseCoordinate;
		}

		public int Height { get; }
		public int Width { get; }
		private Coordinate BaseCoordinate { get; }

		/*
		 
		   X              XEnd
		  Y┌──────────────┐
		   │              │
		   │              │
		   └──────────────┘
		   YEnd            
		   
		 */
		public int X => BaseCoordinate.X;
		public int XEnd => BaseCoordinate.X + Width;
		public int Y => BaseCoordinate.Y;
		public int YEnd => BaseCoordinate.Y + Height;

		public bool IsOverlapping( Rectangle other )
		{
			if ( X >= other.XEnd )
				return false;

			if ( XEnd <= other.X )
				return false;

			if ( Y >= other.YEnd )
				return false;

			if ( YEnd <= other.Y )
				return false;

			return true;
		}
	}
}
