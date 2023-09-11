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
    [SerializeField] private GameObject RecordInfoPanel;
    [SerializeField] private Button _button;
    
    private GameObject buyPanelÓbject;
    private GameObject recordInfoPanelÓbject;
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
        Record recordInfo = await BCInteract.Instance.GetRecord(_id);
        List<string> addressPermited = await BCInteract.Instance.GetAddressPermited(_id);
        string userAddress = PlayerPrefs.GetString("Account");

        if (userAddress != recordInfo.owner && !addressPermited.Contains(userAddress))
        {
            if (!buyPanelÓbject)
            {
                GameObject canvas = GameObject.Find("Canvas");
                buyPanelÓbject = Instantiate(BuyPanel, canvas.transform);
                var buyPanel = buyPanelÓbject.transform.GetChild(0).GetComponent<BuyRecordPanel>();
                buyPanel.StartPanel(recordInfo.ownerName, recordInfo.owner, recordInfo.id);
            }
            else
            {
                buyPanelÓbject.SetActive(true);
            }
        }

        else
        {
            if (!recordInfoPanelÓbject)
            {
                GameObject canvas = GameObject.Find("Canvas");
                recordInfoPanelÓbject = Instantiate(RecordInfoPanel, canvas.transform);
                var recordInfoPanel = recordInfoPanelÓbject.transform.GetChild(0).GetComponent<RecordInfoPanel>();
                recordInfoPanel.StartPanel(recordInfo);
            }
            else
            {
                recordInfoPanelÓbject.SetActive(true);
            }
        }
    }

    public int GetId()
    {
        return _id;
    }
}
