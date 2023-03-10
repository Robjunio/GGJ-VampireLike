using UnityEngine;
using UnityEngine.UI;

public class GameInterface : MonoBehaviour
{
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private GameObject DefeatPanel;
    [SerializeField] private GameObject LevelUpPanel;
    
    [SerializeField] private Slider _xpSlider;
    [SerializeField] private Text _levelInfo;
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
    }

    public void ActivateVictoryPanel()
    {
        GameController.Instance.GameEnded = true;
        VictoryPanel.SetActive(true);
    }

    public void ActivateDefeatPanel()
    {
        GameController.Instance.GameEnded = true;
        DefeatPanel.SetActive(true);
    }
}
