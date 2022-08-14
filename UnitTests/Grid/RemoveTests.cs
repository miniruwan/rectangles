using System.Linq;
using FluentAssertions;
using Rectangles;
using Xunit;

namespace UnitTests.Grid
{
	public class RemoveTests
	{
		[Theory]
		[InlineData( 0, 0 )]
		[InlineData( 1, 1 )]
		[InlineData( 2, 2 )]
		[InlineData( 0, 2 )]
		[InlineData( 2, 1 )]
		[InlineData( 9, 9 )]
		[InlineData( 9, 10 )]
		public void Should_NotRemove_IfRectangleNotFound( int x, int y )
		{
			// Arrange
			var grid = new Rectangles.Grid( 10, 10 );

			var someRectangle = new Rectangles.Rectangle( 3, 3, new Coordinate( 5, 5 ) );
			grid.Place( someRectangle );
			grid.Rectangles.Should( ).ContainSingle( );

			// Act
			grid.Remove( new Coordinate( x, y ) );

			// Assert
			grid.Rectangles.Should( ).ContainSingle( );
		}

		[Theory]
		[InlineData( 0, 0 )]
		[InlineData( 1, 1 )]
		[InlineData( 2, 2 )]
		[InlineData( 0, 2 )]
		[InlineData( 0, 1 )]
		[InlineData( 1, 0 )]
		[InlineData( 2, 1 )]
		public void Should_Remove_WhenThereIsARectangleFoundOnPosition( int x, int y )
		{
			// Arrange
			var grid = new Rectangles.Grid( 10, 10 );

			var rectangleToBeFound = new Rectangles.Rectangle( 2, 2, new Coordinate( 0, 0 ) );
			grid.Place( rectangleToBeFound );

			var otherRectangle = new Rectangles.Rectangle( 3, 3, new Coordinate( 5, 5 ) );
			grid.Place( otherRectangle );

			grid.Rectangles.Count.Should( ).Be( 2 );

			// Act
			grid.Remove( new Coordinate( x, y ) );

			// Assert
			grid.Rectangles.Count.Should( ).Be( 1 );
			grid.Rectangles.Single( ).Should( ).Be( otherRectangle );
		}
	}
}
