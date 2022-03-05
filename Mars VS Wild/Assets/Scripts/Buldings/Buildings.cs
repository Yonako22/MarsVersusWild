using UnityEngine;

public class Buildings : MonoBehaviour
{
  public float buildingHP;
  public Collider2D col;
  
  public float buildingPriceLvl1;
  public float buildingPriceLvl2;
  public float buildingPriceLvl3;

  public int buildingLevel;

  private void Awake()
  {
    col = gameObject.GetComponent<Collider2D>();
    buildingLevel = 1;
  }
}
