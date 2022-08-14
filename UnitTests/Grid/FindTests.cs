using FluentAssertions;
using Rectangles;
using Xunit;

namespace UnitTests.Grid
{
	public class FindTests
	{
		[Fact]
		public void Should_ReturnNull_WhenGridIsEmpty( )
		{
			// Arrange
			var grid = new Rectangles.Grid( 10, 10 );

			// Act
			Rectangles.Rectangle rectangle = grid.Find( new Coordinate( 5, 5 ) );

			// Assert
			rectangle.Should( ).BeNull( );
		}
		
		[Theory]
		[InlineData( 10, 10 )]
		[InlineData( 9, 9 )]
		[InlineData( 3, 3 )]
		public void Should_ReturnNull_WhenNoRectangleFoundInPosition( int x, int y )
		{
			// Arrange
			var grid = new Rectangles.Grid( 10, 10 );

			grid.Place( new Rectangles.Rectangle( 2, 2, new Coordinate( 0, 0 ) ) );
			grid.Place( new Rectangles.Rectangle( 3, 3, new Coordinate( 5, 5 ) ) );

			// Act
			Rectangles.Rectangle rectangle = grid.Find( new Coordinate( x, y ) );

			// Assert
			rectangle.Should( ).BeNull( );
		}

		[Theory]
		[InlineData( 0, 0 )]
		[InlineData( 1, 1 )]
		[InlineData( 2, 2 )]
		[InlineData( 0, 2 )]
		[InlineData( 0, 1 )]
		[InlineData( 1, 0 )]
		[InlineData( 2, 1 )]
		public void Should_FindRectangle_WhenThereIsARectangleOnPosition( int x, int y )
		{
			// Arrange
			var grid = new Rectangles.Grid( 10, 10 );

			var rectangleToBeFound = new Rectangles.Rectangle( 2, 2, new Coordinate( 0, 0 ) );
			grid.Place( rectangleToBeFound );

			var someOtherRectangle = new Rectangles.Rectangle( 3, 3, new Coordinate( 5, 5 ) );
			grid.Place( someOtherRectangle );

			// Act
			Rectangles.Rectangle found = grid.Find( new Coordinate( x, y ) );

			// Assert
			found.Should( ).NotBeNull( );
			found.Should( ).Be( rectangleToBeFound );
		}
	}
}
