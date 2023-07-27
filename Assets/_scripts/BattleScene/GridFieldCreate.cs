using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFieldCreate : MonoBehaviour
{
    [SerializeField]private GameObject _playerGridParent;
    [SerializeField]private GameObject _enemyGridParent;
    [SerializeField]private int _width, _height;
    [SerializeField]private Tile _tilePrefab;
    [SerializeField]private Transform _cam;
    [SerializeField] private GameObject _player;
    private float _scale = 1.5f; //depends on tile scale
    void Start()
    {
        _playerGridParent.transform.position = new Vector3(-6f, -3f, 0);
        _enemyGridParent.transform.position=new Vector3(-6f, 2f,0);
        GenerateGrid(_playerGridParent);
        GenerateGrid(_enemyGridParent);

    }
    void GenerateGrid(GameObject fieldType)
    {
        for(int x = 0; x < _width; x++)
        {
            for(int y = 0; y < _height; y++)
            {
                var spawnedTile=Instantiate(_tilePrefab,new Vector3(x,y),Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.transform.parent = fieldType.transform;
                spawnedTile.transform.localPosition=new Vector3(x*_scale,y*_scale);
                var isOffSet = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                if (fieldType.name == "PlayerField"&&x==0&&y==0)
                {
                    var spawnedPlayer=Instantiate(_player,new Vector2(0,0),Quaternion.identity);
                    spawnedPlayer.transform.parent = spawnedTile.transform;
                    spawnedPlayer.transform.localPosition = new Vector2(0, 0);
                }
                spawnedTile.Init(isOffSet);
            }
        }
    }
}
