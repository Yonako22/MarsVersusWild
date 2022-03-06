using UnityEngine;

public class Infirmerie : Buildings
{
    //Variables déjà serializé dans les class parent.
    // public int buildingHP;
    // public int buildingLevel = 1;

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
            #region Particle System

            GetComponent <ParticleSystem>().Play ();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;

            #endregion
            
            #region RemoveTotalBonus
            AnimalManager.instance.perroquetCD += bonusTotal;
            AnimalManager.instance.perroquetCounter += bonusTotal;
            AnimalManager.instance.girafeCD += bonusTotal;
            AnimalManager.instance.girafeCounter += bonusTotal;
            AnimalManager.instance.gorilleCD += bonusTotal;
            AnimalManager.instance.gorilleCounter += bonusTotal;
            AnimalManager.instance.rhinoCD += bonusTotal;
            AnimalManager.instance.rhinoCounter += bonusTotal;
            #endregion
            Destroy(gameObject);
        }
    }

    private void Upgrade()
    {
        if (buildingLevel == 1 && !hasUpgraded1)
        {
            #region bonus1
            AnimalManager.instance.perroquetCD -= bonus1;
            AnimalManager.instance.perroquetCounter -= bonus1;
            AnimalManager.instance.girafeCD -= bonus1;
            AnimalManager.instance.girafeCounter -= bonus1;
            AnimalManager.instance.gorilleCD -= bonus1;
            AnimalManager.instance.gorilleCounter -= bonus1;
            AnimalManager.instance.rhinoCD -= bonus1;
            AnimalManager.instance.rhinoCounter -= bonus1;
            #endregion

            bonusTotal += bonus1;

            hasUpgraded1 = true;
        }
        
        if (buildingLevel == 2 && !hasUpgraded2)
        {
            #region bonus2
            AnimalManager.instance.perroquetCD -= bonus2;
            AnimalManager.instance.perroquetCounter -= bonus2;
            AnimalManager.instance.girafeCD -= bonus2;
            AnimalManager.instance.girafeCounter -= bonus2;
            AnimalManager.instance.gorilleCD -= bonus2;
            AnimalManager.instance.gorilleCounter -= bonus2;
            AnimalManager.instance.rhinoCD -= bonus2;
            AnimalManager.instance.rhinoCounter -= bonus2;
            #endregion

            bonusTotal += bonus2;

            hasUpgraded2 = true;
        }
        if (buildingLevel == 3 && !hasUpgraded3)
        {
            #region bonus3
            AnimalManager.instance.perroquetCD -= bonus3;
            AnimalManager.instance.perroquetCounter -= bonus3;
            AnimalManager.instance.girafeCD -= bonus3;
            AnimalManager.instance.girafeCounter -= bonus3;
            AnimalManager.instance.gorilleCD -= bonus3;
            AnimalManager.instance.gorilleCounter -= bonus3;
            AnimalManager.instance.rhinoCD -= bonus3;
            AnimalManager.instance.rhinoCounter -= bonus3;
            #endregion

            bonusTotal += bonus3;

            hasUpgraded3 = true;
        }
    }
}
