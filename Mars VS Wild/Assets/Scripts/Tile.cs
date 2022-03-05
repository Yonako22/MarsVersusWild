using UnityEngine;
 
public class Tile : MonoBehaviour 
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    
    public GameObject building;

    private void Start()
    {
        _highlight.SetActive(false);
    }

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }
 
    void OnMouseEnter()
    {
        _highlight.SetActive(true);
        Debug.Log(name);
    }
 
    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}