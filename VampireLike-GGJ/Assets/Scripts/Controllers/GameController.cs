using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance; 
    
    private XpController _xpController;
    private XpDrop _xpDrop;

    [SerializeField] private EnemySpawn _enemySpawn;
    

    public GameInterface Interface;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TryGetComponent(out _xpDrop);
        
        _xpController = new XpController();
        _xpController.Start();
    }
    
    // The exp orb will get acess to the controller by this function
    public XpController GetXpController()
    {
        return _xpController;
    }

    public XpDrop GetXpDrop()
    {
        return _xpDrop;
    }

    public EnemySpawn GetEnemySpawn()
    {
        return _enemySpawn;
    }
}
