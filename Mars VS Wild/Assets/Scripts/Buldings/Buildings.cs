using System;
using UnityEngine;

public class Buildings : MonoBehaviour
{
  public float buildingHP;
  public Collider2D col;

  public bool canBeUpgrade;
  
  public float buildingPriceLvl1;
  public float buildingPriceLvl2;
  public float buildingPriceLvl3;

  public int buildingLevel;

  private void Awake()
  {
    col = gameObject.GetComponent<Collider2D>();
    buildingLevel = 1;
    canBeUpgrade = true;
  }

  public void Update()
  {
    if (buildingHP <= 0)
    {
      Destroy(gameObject);
    }
  }
}
