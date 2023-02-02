using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance; 
    
    private XpController _xpController;

    public GameInterface Interface;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _xpController = new XpController();
        _xpController.Start();
    }
    
    // The exp orb will get acess to the controller by this function
    public XpController GetXpController()
    {
        return _xpController;
    }
}
