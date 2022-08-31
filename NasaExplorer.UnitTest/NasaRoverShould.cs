using NasaExplorer.Entity;

namespace NasaExplorer.UnitTest;
using Xunit;

public class NasaRoverShould
{
    [Theory]
    [InlineData(CardinalPoints.North, "L", "W")]
    [InlineData(CardinalPoints.North, "R", "E")]
    [InlineData(CardinalPoints.South, "L", "E")]
    [InlineData(CardinalPoints.South, "R", "W")]
    [InlineData(CardinalPoints.East, "L", "N")]
    [InlineData(CardinalPoints.East, "R", "S")]
    [InlineData(CardinalPoints.West, "L", "S")]
    [InlineData(CardinalPoints.West, "R", "N")]
    public void ValidateTurn90(CardinalPoints currentFacingDirection, string newFacingDirection, string expected)
    {
        //Arrange
        var nasaRover = new NasaRover();
        var dataNavigation = new DataNavigation();
        dataNavigation.CoordinateX = 1;
        dataNavigation.CoordinateY = 1;
        dataNavigation.FacingDirection = currentFacingDirection;
        
        //Act
        nasaRover.Turn90(dataNavigation, newFacingDirection);

        //Assert
        Assert.Equal(dataNavigation.FacingDirection.ToString()[0].ToString(), expected);
    }

    [Theory]
    [InlineData(1,1, CardinalPoints.North, 1,2, CardinalPoints.North)]
    [InlineData(1,1, CardinalPoints.South, 1,0, CardinalPoints.South)]
    [InlineData(1,1, CardinalPoints.East, 2,1, CardinalPoints.East)]
    [InlineData(1,1, CardinalPoints.West, 0,1, CardinalPoints.West)]
    public void ValidateMoveFordward(int coordinateX, 
                                    int coordinateY, 
                                    CardinalPoints facingDirection, 
                                    int expectedX,
                                    int expectedY,
                                    CardinalPoints expectedFacingDirection)
    {
        //Arrange
        var dataNavigation = new DataNavigation();
        dataNavigation.CoordinateX = coordinateX;
        dataNavigation.CoordinateY = coordinateY;
        dataNavigation.FacingDirection = facingDirection;

        
        var expectedDataNavigation = new DataNavigation();
        expectedDataNavigation.CoordinateX = expectedX;
        expectedDataNavigation.CoordinateY = expectedY;
        expectedDataNavigation.FacingDirection = expectedFacingDirection;

        string expectedInlineData = expectedDataNavigation.CoordinateX.ToString() + expectedDataNavigation.CoordinateY.ToString() +
                                    expectedDataNavigation.FacingDirection.ToString();
        
        //Acts
        var marsRover = new NasaRover();
        marsRover.MoveFordward(dataNavigation);
        
        string inlineData = dataNavigation.CoordinateX.ToString() + dataNavigation.CoordinateY.ToString() +
                            dataNavigation.FacingDirection.ToString();

        //Assets
        Assert.True(expectedInlineData.Equals(inlineData));
        

    }

    [Theory]
    [InlineData(1, 2, CardinalPoints.North, "LMLMLMLMM", "13N")]
    [InlineData(3, 3, CardinalPoints.East, "MMRMMRMRRM", "51E")]
    public void MoveInTheRightPad(int coordinateX, 
                                int coordinateY,
                                CardinalPoints facingDirection,
                                string roadInstructions,
                                string expectedNewPosition)
    {
        #region Processing the instructions

        //Arrange
        var nasaRover = new NasaRover();
        var dataNavigation = new DataNavigation();
        dataNavigation.CoordinateX = coordinateX;
        dataNavigation.CoordinateY = coordinateY;
        dataNavigation.FacingDirection = facingDirection;
        
        
        //Acts
        foreach (char instruction in roadInstructions)
        {
            if (instruction.ToString() == "L"
                || instruction.ToString() == "R")
            {
            
                nasaRover.Turn90(dataNavigation, instruction.ToString());
            }
            if (instruction.ToString() == "M")
            {
                nasaRover.MoveFordward(dataNavigation);
            }
            //if you want to check step by step route
            /*Console.WriteLine("Current Position (X,Y):{0},{1} Facing Direction:{2} ", dataNavigation.CoordinateX, 
                                                                        dataNavigation.CoordinateY, 
                                                                        dataNavigation.FacingDirection);*/
        }
        string  currentPosition =  string.Format("{0}{1}{2}", dataNavigation.CoordinateX, 
            dataNavigation.CoordinateY, 
            dataNavigation.FacingDirection.ToString()[0]);

        
        //Assets 
        Assert.True(expectedNewPosition.Equals(currentPosition));

        #endregion Processing the instructions
        
    }
    
}