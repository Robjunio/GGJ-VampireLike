using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    private NucleoController _nucleoController;
    private NucleoSpawner _nucleoSpawner;

    [SerializeField] private Transform _test;
    private BoxCollider2D _boxCollider2D;
        
    [SerializeField] private GameObject _enemy1Prefab;
    [SerializeField] private GameObject _enemy2Prefab;
    [SerializeField] private GameObject _enemy3Prefab;

    [SerializeField] private float MaxX;
    [SerializeField] private float MinX;
    [SerializeField] private float MaxY;
    [SerializeField] private float MinY;

    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private int EnemyQnt = 5;
    
    private List<GameObject> EnemyList;

    //Controle de tempo
    
    private float currentTime;
    private int tier = 1;

    private void Awake()
    {
        _nucleoController = new NucleoController();
        TryGetComponent(out _nucleoSpawner);
        EnemyList = new List<GameObject>();

        _test.TryGetComponent(out _boxCollider2D);
    }

    private void Start()
    {
        _nucleoSpawner.CreateNucleo(_nucleoController.GetNucleoPosition());
    }


    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 10)
        {
            EnemyQnt += 2^tier;
            tier++;
            currentTime = 0;
        }
    }

    private void FixedUpdate()
    {
        if (EnemyList.Count < EnemyQnt)
        {
            CreateEnemy();
        }
    }

    private Vector3 EnemySpawnPos()
    {
        var pos = new Vector3(Random.Range(MaxX, MinX), Random.Range(MaxY, MinY), 0);
        if (TouchGround(pos))
        {
            print("Tocou na grama");
        }
        return pos;
    }

    private void CreateEnemy()
    {
        GameObject prefab;

        if (tier < 5)
        {
            prefab = _enemy1Prefab;
        }
        else
        {
            if (tier < 10)
            {
                prefab = Random.Range(0, 100) > 49 ? _enemy1Prefab : _enemy2Prefab;
            }
            else
            {
                prefab = Random.Range(0, 100) > 49 ? _enemy2Prefab : _enemy3Prefab;
            }
        }
        var pos = EnemySpawnPos();
        var obj = Instantiate(prefab, pos, Quaternion.identity);
        EnemyList.Add(obj);
    }
    
    

    public void RemoveEnemyFromList(GameObject obj)
    {
        EnemyList.Remove(obj);
    }

    public NucleoSpawner GetNucleoSpawner()
    {
        return _nucleoSpawner;
    }
    
    public NucleoController GetNucleoController()
    {
        return _nucleoController;
    }

    public bool TouchGround(Vector3 position)
    {
        _test.position = position;
        RaycastHit2D rcWall = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size,
            0, Vector2.down, 0f, whatIsGround);
        return rcWall.collider != null;
    }
}
