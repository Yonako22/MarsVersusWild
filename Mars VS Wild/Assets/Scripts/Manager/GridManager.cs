using System.Collections.Generic;
using UnityEngine;
 
public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField] private int _width, _height;
 
    [SerializeField] private Tile _tilePrefab;
 
    [SerializeField] private Transform _cam;
 
    private Dictionary<Vector2, Tile> _tiles;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("STOP! Grid");
            return;
        }

        instance = this;
    }

   public void GenerateGrid() 
    {
        _tiles = new Dictionary<Vector2, Tile>();
        
        for (int x = 0; x < _width; x++) 
        {
            for (int y = 0; y < _height; y++) 
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height / 2 - 0.5f,-10);
        _cam.transform.position = new Vector3(3.6f, _cam.transform.position.y, _cam.transform.position.z);
    }
 
    public Tile GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}