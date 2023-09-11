using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard_score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameUI;
    [SerializeField] private TextMeshProUGUI pointsUI;
    [SerializeField] private GameObject BuyPanel;
    private GameObject Panel;
    [SerializeField] private Button _button;
    private int _id;

    public void setScore(string name, string points, int id)
    {
        nameUI.text = name;
        pointsUI.text = points;
        _id = id;
        
        _button.onClick.AddListener(CreatePanel);
    }

    private async void CreatePanel()
    {
        if (Panel == null)
        {
            Panel = Instantiate(BuyPanel, transform.parent);
            var recordInfo = await BCInteract.Instance.GetRecord(_id);
            var panel = Panel.transform.GetChild(0).GetComponent<BuyRecordPanel>();
            panel.StartPanel(recordInfo[2].ToString(), recordInfo[1].ToString(), _id);
            
        }
        else
        {
            Panel.SetActive(true);
        }
        
    }

    public int GetId()
    {
        return _id;
    }
}
