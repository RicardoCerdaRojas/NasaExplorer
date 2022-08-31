namespace NasaExplorer.Entity;

public enum CardinalPoints
{
    North,
    South,
    East,
    West
}

public class DataNavigation {
    public int CoordinateX { get; set; }
    public int CoordinateY { get; set; }
    public CardinalPoints FacingDirection { get; set; }

    public void SetFacingDirectionFromString(string CardinalPoint)
    {
        switch (CardinalPoint)
        {
            case "N":
                FacingDirection = CardinalPoints.North;
                break;
            case "S":
                FacingDirection = CardinalPoints.South;
                break;
            case "E":
                FacingDirection = CardinalPoints.East;
                break;
            case "W":
                FacingDirection = CardinalPoints.West;
                break;
        }
    }

    public bool InstructionsAreValid(string instructions)
    {
        foreach (char instruction in instructions)
        {
            if (instruction.ToString() != "L" 
                && instruction.ToString() != "R" 
                && instruction.ToString() != "M")
                return false;
        }

        return true;
    }

    
}
