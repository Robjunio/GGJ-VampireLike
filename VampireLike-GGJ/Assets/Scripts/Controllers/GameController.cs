using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance; 
    
    private XpController _xpController;
    private XpDrop _xpDrop;
    
    private NucleoController _nucleoController;
    private NucleoSpawner _nucleoSpawner;

    public GameInterface Interface;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TryGetComponent(out _nucleoSpawner);
        TryGetComponent(out _xpDrop);
        _nucleoController = new NucleoController();
        _xpController = new XpController();
        _xpController.Start();
        
        _nucleoSpawner.CreateNucleo(Vector3.one);
    }
    
    // The exp orb will get acess to the controller by this function
    public XpController GetXpController()
    {
        return _xpController;
    }

    public NucleoController GetNucleoController()
    {
        return _nucleoController;
    }

    public NucleoSpawner GetNucleoSpawner()
    {
        return _nucleoSpawner;
    }

    public XpDrop GetXpDrop()
    {
        return _xpDrop;
    }
}
