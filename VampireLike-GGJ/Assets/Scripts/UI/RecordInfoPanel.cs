using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RecordInfoPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI recordInfo;
        [SerializeField] private Button backButton;
        private int id;

        public void StartPanel(Record record)
        {
            recordInfo.text = "Usuário: " + record.ownerName + "\n";
            recordInfo.text += "Pontos: " + record.points + "\n";
            recordInfo.text += "Tempo: " + record.timeSpent + "\n";
            recordInfo.text += "Inimigos Eliminados: " + record.enemiesKilled + "\n";
            recordInfo.text += "Habilidades:\n" + record.skillsList;
        }
    }
}