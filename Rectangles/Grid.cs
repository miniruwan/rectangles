using System;
using System.Collections.Generic;

namespace Rectangles
{
	public class Grid
	{
		private const int MinSize = 5;
		private const int MaxSize = 25;

		public Grid( int width, int height )
		{
			if ( width < MinSize || width > MaxSize )
				throw new ArgumentException( $"Width should be between {MinSize} and {MaxSize}." );

			if ( height < MinSize || height > MaxSize )
				throw new ArgumentException( $"Height should be between {MinSize} and {MaxSize}." );

			Width = width;
			Height = height;
		}

		public int Height { get; }
		public int Width { get; }
		public List<Rectangle> Rectangles { get; } = new( );

		public void Place( Rectangle rectangleToPlace )
		{
			if ( IsOutOfGrid( rectangleToPlace ) )
			{
				throw new ArgumentException( "Rectangle extends beyond the edge of the grid." );
			}

			foreach ( Rectangle rectangleInTheGrid in Rectangles )
			{
				if ( rectangleInTheGrid.IsOverlapping( rectangleToPlace ) )
				{
					throw new InvalidOperationException( "Rectangle overlaps with an existing rectangle." );
				}
			}

			Rectangles.Add( rectangleToPlace );
		}

		public Rectangle Find( Coordinate coordinate )
		{
			foreach ( Rectangle rectangle in Rectangles )
			{
				if ( rectangle.X <= coordinate.X && coordinate.X <= rectangle.XEnd &&
				     rectangle.Y <= coordinate.Y && coordinate.Y <= rectangle.YEnd )
				{
					return rectangle;
				}
				
			}

			return null;
		}

		public void Remove( Coordinate coordinate )
		{
			Rectangle rectangle = Find( coordinate );

			if ( rectangle != null )
				Rectangles.Remove( rectangle );
		}

		private bool IsOutOfGrid( Rectangle rectangle )
		{
			return rectangle.XEnd > Width || rectangle.YEnd > Height;
		}
	}
}
