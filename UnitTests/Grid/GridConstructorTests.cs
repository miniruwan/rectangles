using System;
using FluentAssertions;
using Xunit;

namespace UnitTests.Grid
{
	public class GridConstructorTests
	{
		private const int ValidSize = 10;

		[Theory]
		[InlineData( 4 )]
		[InlineData( 26 )]
		public void Should_ThrowForOutOfRangeWidth( int width )
		{
			Action result = ( ) =>
			{
				var _ = new Rectangles.Grid( width, ValidSize );
			};

			result.Should( ).Throw<ArgumentException>( ).WithMessage( "Width should be between 5 and 25." );
		}

		[Theory]
		[InlineData( 4 )]
		[InlineData( 26 )]
		public void Should_ThrowForOutOfRangeHeight( int height )
		{
			Action result = ( ) =>
			{
				var _ = new Rectangles.Grid( ValidSize, height );
			};

			result.Should( ).Throw<ArgumentException>( ).WithMessage( "Height should be between 5 and 25." );
		}

		[Theory]
		[InlineData( ValidSize, ValidSize )]
		[InlineData( 25, 5 )]
		[InlineData( 5, 25 )]
		public void Constructor_Should_CreateSuccessfullyForValidWidthAndHeight( int width, int height )
		{
			var result = new Rectangles.Grid( width, height );

			result.Width.Should( ).Be( width );
			result.Height.Should( ).Be( height );
		}
	}
}
