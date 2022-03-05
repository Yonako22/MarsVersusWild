public class Barricade : Buildings
{
    void Update()
    {
        if (buildingLevel == 2)
        {
            buildingHP = 60;
        }
        if (buildingLevel == 3)
        {
            buildingHP = 70;
            canBeUpgrade = false;
        }
    }
}