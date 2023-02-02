using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance; 
    
    private XpController _xpController;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _xpController = new XpController();
    }
    
    // The exp orb will get acess to the controller by this function
    public XpController GetXpController()
    {
        return _xpController;
    }
}
