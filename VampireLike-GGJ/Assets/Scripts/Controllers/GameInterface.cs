using System;
using BlockChain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameInterface : MonoBehaviour
{
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private GameObject DefeatPanel;
    [SerializeField] private GameObject LevelUpPanel;
    
    [SerializeField] private Slider _xpSlider;
    [SerializeField] private Text _levelInfo;

    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private TextMeshProUGUI EndResultTimer;
    [SerializeField] private TextMeshProUGUI EndResultEnemiesKill;
    [SerializeField] private TMP_InputField NameInput;

    [SerializeField] private FadeCall _fadeCall;

    public void UpdateXpText()
    {
        var info = GameController.Instance.GetXpController().GetXpInfo();

        _xpSlider.maxValue = info[2];
        _xpSlider.value = info[1];
        _levelInfo.text = info[0].ToString();
    }

    public void ActivateLevelUpPanel()
    {
        LevelUpPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ActivateVictoryPanel()
    {
        Time.timeScale = 0;
        
        var time = GameController.Instance.getRunTime();
        var enemiesKill = GameController.Instance.getEnemiesKilled().ToString();

        GameController.Instance.GameEnded = true;
        EndResultEnemiesKill.text = enemiesKill;
        EndResultTimer.text = time;

        VictoryPanel.SetActive(true);
    }

    public void WinAddToHistoric()
    {
        var time = GameController.Instance.getRunTime();
        var enemiesKill = GameController.Instance.getEnemiesKilled().ToString();
        
        if (NameInput.text != null)
        {
            ChainManager.Instance.AddNewRecord(NameInput.text + " | " + time  + " | " + enemiesKill);
        }
    }

    public void ActivateDefeatPanel()
    {
        if (GameController.Instance.GameEnded)
        {
            return;
        }
        GameController.Instance.GameEnded = true;
        DefeatPanel.SetActive(true);
    }

    public void UpdateTimerUIText(string time)
    {
        timerText.text = time;
    }
}
