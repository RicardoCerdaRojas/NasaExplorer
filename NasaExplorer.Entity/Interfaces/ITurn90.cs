namespace NasaExplorer.Entity.Interfaces;

public interface ITurn90
{
    DataNavigation Turn90(DataNavigation dataNavigation, string newFacingDirection);
}