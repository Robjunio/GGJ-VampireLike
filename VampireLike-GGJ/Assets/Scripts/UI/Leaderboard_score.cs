using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard_score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameUI;
    [SerializeField] private TextMeshProUGUI killsUI;
    [SerializeField] private TextMeshProUGUI timeUI;

    public void setScore(string name, string time, string kills)
    {
        nameUI.text = name;
        killsUI.text = kills;
        timeUI.text = time;
    }
}
