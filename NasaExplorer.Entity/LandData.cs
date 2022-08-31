namespace NasaExplorer.Entity;

public class LandData
{
    public int MinX { get; set; }
    public int MaxX { get; set; }
    public int MinY { get; set; }
    public int MaxY { get; set; }

    public LandData()
    {
        MinX = 0;
        MinY = 0;
    }

    public bool IsCurrentPositionInsideBoundaries(DataNavigation dataNavigation)
    {
        if (dataNavigation.CoordinateX <= MaxX && dataNavigation.CoordinateY <= MaxY)
            return true;
        else
            return false;
    }
}