using System;
using FluentAssertions;
using Rectangles;
using Xunit;

namespace UnitTests.Grid
{
	public class PlaceRectangleTests
	{
		[Fact]
		public void Should_SuccessfullyPlaceRectangle_When_DoesNotOverlapWithExisting( )
		{
			// Arrange
			var grid = new Rectangles.Grid( 20, 20 );
			var existingRectangle = new Rectangles.Rectangle( 5, 5, new Coordinate( 10, 10 ) );
			grid.Place( existingRectangle );

			// Act
			var rectangleToBePlaced = new Rectangles.Rectangle( 5, 5, new Coordinate( 0, 0 ) );
			Action result = ( ) => grid.Place( rectangleToBePlaced );

			// Assert
			result.Should( ).NotThrow( );
			grid.Rectangles.Count.Should( ).Be( 2 );
		}

		[Fact]
		public void Should_Throw_WhenRectangleExtendsBeyondTheEdgeOfTheGrid( )
		{
			// Arrange
			var grid = new Rectangles.Grid( 15, 10 );
			var rectangle = new Rectangles.Rectangle( 5, 5, new Coordinate( 50, 60 ) );

			// Act
			Action result = ( ) => grid.Place( rectangle );

			// Assert
			result.Should( ).Throw<ArgumentException>( ).WithMessage( "Rectangle extends beyond the edge of the grid." );
		}

		[Fact]
		public void Should_Throw_WhenRectanglesOverlap( )
		{
			// Arrange
			var grid = new Rectangles.Grid( 20, 20 );
			var existingRectangle = new Rectangles.Rectangle( 5, 5, new Coordinate( 10, 10 ) );
			grid.Place( existingRectangle );

			// Act
			var rectangleToBePlaced = new Rectangles.Rectangle( 5, 5, new Coordinate( 10, 10 ) );
			Action result = ( ) => grid.Place( rectangleToBePlaced );

			// Assert
			result.Should( ).Throw<InvalidOperationException>( ).WithMessage( "Rectangle overlaps with an existing rectangle." );
		}
	}
}
