using System.Diagnostics;
using NasaExplorer.Entity.Interfaces;

namespace NasaExplorer.Entity;

public class NasaRover: ITurn90, ISpeedUp
{
    public DataNavigation Turn90(DataNavigation dataNavigation, string newFacingDirection)
    {
        try
        {
            string ruleToMove = dataNavigation.FacingDirection.ToString()[0] + newFacingDirection;
            
            if(ruleToMove == "NL" || ruleToMove == "SR")
                dataNavigation.FacingDirection = CardinalPoints.West;

            if(ruleToMove == "NR" || ruleToMove == "SL")
                dataNavigation.FacingDirection = CardinalPoints.East;

            if(ruleToMove == "WL" || ruleToMove == "ER")
                dataNavigation.FacingDirection = CardinalPoints.South;

            if(ruleToMove == "WR" || ruleToMove == "EL")
                dataNavigation.FacingDirection = CardinalPoints.North;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return dataNavigation;
    }

    public DataNavigation MoveFordward(DataNavigation dataNavigation)
    {
        try
        {
            switch (dataNavigation.FacingDirection)
            {
                case CardinalPoints.West:
                    dataNavigation.CoordinateX -= 1;
                    break;
                case CardinalPoints.South:
                    dataNavigation.CoordinateY -= 1;
                    break;
                case CardinalPoints.East:
                    dataNavigation.CoordinateX += 1;
                    break;
                case CardinalPoints.North:
                    dataNavigation.CoordinateY += 1;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return dataNavigation;
    }
    
}