using FluentAssertions;
using Rectangles;
using Xunit;

namespace UnitTests.Rectangle
{
	public class IsOverlappingTests
	{
		/*
			   ◄─────────20──────────►

			 (600,150)               (620,150)
			   ┌──────────────────────┐
		 ▲     │                      │
		 │     │                      │
		 │     │                      │
		 10    │                      │
		 │     │                      │
		 ▼     └──────────────────────┘
			 (600,160)               (620,160)
		 */
		private const int ThisRectangleX = 600;
		private const int ThisRectangleY = 150;
		private const int ThisRectangleWidth = 20;
		private const int ThisRectangleHeight = 10;
		private const int ThisRectangleXEnd = ThisRectangleX + ThisRectangleWidth;
		private const int ThisRectangleYEnd = ThisRectangleY + ThisRectangleHeight;

		/*
					30
			  ┌────────────┐
			  │            │
			  │            │
			  │            │
		   40 │            │
			  │            │
			  │            │
			  │            │
			  └────────────┘
		 */
		private const int OtherRectangleWidth = 30;
		private const int OtherRectangleHeight = 40;

		[Theory]
		[InlineData( ThisRectangleX - 100, ThisRectangleY - 100 )] // Both X and Y are away to left and up
		[InlineData( ThisRectangleXEnd + 100, ThisRectangleYEnd + 100 )] // Both X and Y are away to right and down
		[InlineData( ThisRectangleXEnd + 100, ThisRectangleY )] // Same Y, but X is far away to right
		[InlineData( ThisRectangleX, ThisRectangleYEnd + 100 )] // Same X, but Y is far away to down
		public void Should_ReturnFalse_ForRectanglesFarApart( int otherBasePositionX, int otherBasePositionY )
		{
			var thisRectangle = new Rectangles.Rectangle(
				ThisRectangleWidth,
				ThisRectangleHeight,
				new Coordinate( ThisRectangleX, ThisRectangleY ) );

			var otherRectangle = new Rectangles.Rectangle(
				OtherRectangleWidth,
				OtherRectangleHeight,
				new Coordinate( otherBasePositionX, otherBasePositionY ) );

			thisRectangle.IsOverlapping( otherRectangle ).Should( ).BeFalse( );
			otherRectangle.IsOverlapping( thisRectangle ).Should( ).BeFalse( );
		}

		[Theory]
		[InlineData( ThisRectangleXEnd, ThisRectangleY )] // Touching right line
		[InlineData( ThisRectangleX - OtherRectangleWidth, ThisRectangleY )] // Touching left line
		[InlineData( ThisRectangleX, ThisRectangleY - OtherRectangleHeight )] // Touching top line
		[InlineData( ThisRectangleX, ThisRectangleYEnd )] // Touching bottom line
		public void Should_ReturnFalse_ForRectanglesTouchingButNotOverlapping( int otherBasePositionX, int otherBasePositionY )
		{
			var thisRectangle = new Rectangles.Rectangle(
				ThisRectangleWidth,
				ThisRectangleHeight,
				new Coordinate( ThisRectangleX, ThisRectangleY ) );

			var otherRectangle = new Rectangles.Rectangle(
				OtherRectangleWidth,
				OtherRectangleHeight,
				new Coordinate( otherBasePositionX, otherBasePositionY ) );

			thisRectangle.IsOverlapping( otherRectangle ).Should( ).BeFalse( );
			otherRectangle.IsOverlapping( thisRectangle ).Should( ).BeFalse( );
		}

		[Theory]
		[InlineData( ThisRectangleX, ThisRectangleY )]
		[InlineData( ThisRectangleX - 1, ThisRectangleY - 1 )]
		[InlineData( ThisRectangleX + 1, ThisRectangleY + 1 )]
		[InlineData( ThisRectangleX - 1, ThisRectangleY + 1 )]
		[InlineData( ThisRectangleX + 1, ThisRectangleY - 1 )]
		public void Should_ReturnTrue_ForRectanglesOverlapping( int otherBasePositionX, int otherBasePositionY )
		{
			var thisRectangle = new Rectangles.Rectangle(
				ThisRectangleWidth,
				ThisRectangleHeight,
				new Coordinate( ThisRectangleX, ThisRectangleY ) );

			var otherRectangle = new Rectangles.Rectangle(
				OtherRectangleWidth,
				OtherRectangleHeight,
				new Coordinate( otherBasePositionX, otherBasePositionY ) );

			thisRectangle.IsOverlapping( otherRectangle ).Should( ).BeTrue( );
			otherRectangle.IsOverlapping( thisRectangle ).Should( ).BeTrue( );
		}

		[Fact]
		public void Should_ReturnTrue_ForRectanglesOverlappingExactlyOnTop( )
		{
			var thisRectangle = new Rectangles.Rectangle( 10, 20, new Coordinate( 200, 100 ) );
			var otherRectangle = new Rectangles.Rectangle( 10, 20, new Coordinate( 200, 100 ) );

			thisRectangle.IsOverlapping( otherRectangle ).Should( ).BeTrue( );
			otherRectangle.IsOverlapping( thisRectangle ).Should( ).BeTrue( );
		}
	}
}
