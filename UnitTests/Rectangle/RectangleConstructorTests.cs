using System;
using FluentAssertions;
using Rectangles;
using Xunit;

namespace UnitTests.Rectangle
{
	public class RectangleConstructorTests
	{
		private static readonly Coordinate BaseCoordinate = new(10, 10);

		[Theory]
		[InlineData( -1, -1 )]
		[InlineData( 1, -1 )]
		[InlineData( -1, 1 )]
		[InlineData( 0, 0 )]
		[InlineData( 0, 1 )]
		[InlineData( 1, 0 )]
		public void Should_ThrowForInvalidWidthOrHeight( int width, int height )
		{
			Action result = ( ) =>
			{
				var _ = new Rectangles.Rectangle( width, height, BaseCoordinate );
			};

			result.Should( ).Throw<ArgumentException>( ).WithMessage( "Width and height should be greater than 0." );
		}

		[Fact]
		public void Should_CreateSuccessfullyForPositivePositions( )
		{
			const int width = 10;
			const int height = 20;

			var result = new Rectangles.Rectangle( width, height, BaseCoordinate );

			result.Width.Should( ).Be( width );
			result.Height.Should( ).Be( height );
		}
	}
}
