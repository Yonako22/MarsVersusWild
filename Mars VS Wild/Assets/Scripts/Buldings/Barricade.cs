using UnityEngine;

public class Barricade : Buildings
{

    public SpriteRenderer _BaseSprite;

    public Sprite _spritelvl2;
    public Sprite _spritelvl3;
    
    void Update()
    {
        if (buildingLevel == 2)
        {
            buildingHP = 60;
            _BaseSprite.sprite = _spritelvl2;

        }
        if (buildingLevel == 3)
        {
            buildingHP = 70;
            canBeUpgrade = false;
            _BaseSprite.sprite = _spritelvl3;

        }
        
        if (buildingHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}