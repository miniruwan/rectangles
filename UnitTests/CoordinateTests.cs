using System;
using FluentAssertions;
using Rectangles;
using Xunit;

namespace UnitTests
{
	public class CoordinateTests
	{
		[Theory]
		[InlineData( -1, -1 )]
		[InlineData( 1, -1 )]
		[InlineData( -1, 1 )]
		public void Constructor_Should_ThrowForNegativePositions( int x, int y )
		{
			Action result = ( ) =>
			{
				var _ = new Coordinate( x, y );
			};

			result.Should( ).Throw<ArgumentException>( ).WithMessage( "X and Y positions should be greater than or equal to 0." );
		}

		[Theory]
		[InlineData( 0, 0 )]
		[InlineData( 1, 1 )]
		[InlineData( 0, 1 )]
		[InlineData( 1, 0 )]
		public void Constructor_Should_CreateSuccessfullyForPositiveOrZeroPositions( int x, int y )
		{
			var result = new Coordinate( x, y );

			result.X.Should( ).Be( x );
			result.Y.Should( ).Be( y );
		}
	}
}
