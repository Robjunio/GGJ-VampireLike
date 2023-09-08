using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance; 
    
    private XpController _xpController;
    private XpDrop _xpDrop;

    [SerializeField] private EnemySpawn _enemySpawn;

    public bool GameEnded;
    public GameInterface Interface;
    
    private float currentTime = 0f;
    private string timeFormat = "00:00:00";

    private int EnemyKills = 0;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
    }

    private void Start()
    {
        TryGetComponent(out _xpDrop);
        
        _xpController = new XpController();
        _xpController.Start();
        
        var time = DateTime.Now.ToShortTimeString();
        // print(time);
    }
    
    private void Update()
    {
        if (GameEnded)
        {
            return;
        }
        // Update the timer every frame
        currentTime += Time.deltaTime;
        Interface.UpdateTimerUIText(FormatTime(currentTime));
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        return formattedTime;
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

    public string getRunTime()
    {
        return FormatTime(currentTime);
    }

    public void EnemyKilled()
    {
        EnemyKills += 1;
    }

    public int getEnemiesKilled()
    {
        return EnemyKills;
    }

    public float ReturnTimer()
    {
        return currentTime;
    }
}
