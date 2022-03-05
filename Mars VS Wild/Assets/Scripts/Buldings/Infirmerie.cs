using UnityEngine;

public class Infirmerie : MonoBehaviour
{
    public int buildingHP;
    public int buildingLevel = 1;

    public int bonus1 = 2;
    public int bonus2;
    public int bonus3;

    public int bonusTotal = 0;

    private bool hasUpgraded1 = false;
    private bool hasUpgraded2 = false;
    private bool hasUpgraded3 = false;

    void Start()
    {
        buildingHP = 20;
        buildingLevel = 1;
        bonus1 = 2;
        bonus2 = 1;
        bonus3 = 1;
    }

    void Update()
    {
        Upgrade();
        if (buildingHP <= 0)
        {
            #region RemoveTotalBonus
            AnimalAttacks.instance.perroquetCD += bonusTotal;
            AnimalAttacks.instance.perroquetCounter += bonusTotal;
            AnimalAttacks.instance.girafeCD += bonusTotal;
            AnimalAttacks.instance.girafeCounter += bonusTotal;
            AnimalAttacks.instance.gorilleCD += bonusTotal;
            AnimalAttacks.instance.gorilleCounter += bonusTotal;
            AnimalAttacks.instance.rhinoCD += bonusTotal;
            AnimalAttacks.instance.rhinoCounter += bonusTotal;
            #endregion
            Destroy(gameObject);
        }
    }

    private void Upgrade()
    {
        if (buildingLevel == 1 && !hasUpgraded1)
        {
            #region bonus1
            AnimalAttacks.instance.perroquetCD -= bonus1;
            AnimalAttacks.instance.perroquetCounter -= bonus1;
            AnimalAttacks.instance.girafeCD -= bonus1;
            AnimalAttacks.instance.girafeCounter -= bonus1;
            AnimalAttacks.instance.gorilleCD -= bonus1;
            AnimalAttacks.instance.gorilleCounter -= bonus1;
            AnimalAttacks.instance.rhinoCD -= bonus1;
            AnimalAttacks.instance.rhinoCounter -= bonus1;
            #endregion

            bonusTotal += bonus1;

            hasUpgraded1 = true;
        }
        
        if (buildingLevel == 2 && !hasUpgraded2)
        {
            #region bonus2
            AnimalAttacks.instance.perroquetCD -= bonus2;
            AnimalAttacks.instance.perroquetCounter -= bonus2;
            AnimalAttacks.instance.girafeCD -= bonus2;
            AnimalAttacks.instance.girafeCounter -= bonus2;
            AnimalAttacks.instance.gorilleCD -= bonus2;
            AnimalAttacks.instance.gorilleCounter -= bonus2;
            AnimalAttacks.instance.rhinoCD -= bonus2;
            AnimalAttacks.instance.rhinoCounter -= bonus2;
            #endregion

            bonusTotal += bonus2;

            hasUpgraded2 = true;
        }
        if (buildingLevel == 3 && !hasUpgraded3)
        {
            #region bonus3
            AnimalAttacks.instance.perroquetCD -= bonus3;
            AnimalAttacks.instance.perroquetCounter -= bonus3;
            AnimalAttacks.instance.girafeCD -= bonus3;
            AnimalAttacks.instance.girafeCounter -= bonus3;
            AnimalAttacks.instance.gorilleCD -= bonus3;
            AnimalAttacks.instance.gorilleCounter -= bonus3;
            AnimalAttacks.instance.rhinoCD -= bonus3;
            AnimalAttacks.instance.rhinoCounter -= bonus3;
            #endregion

            bonusTotal += bonus3;

            hasUpgraded3 = true;
        }
    }
}
