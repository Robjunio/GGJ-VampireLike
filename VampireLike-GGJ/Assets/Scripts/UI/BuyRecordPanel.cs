using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BuyRecordPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button _button;
        private int id;
        
        public void StartPanel(string Name, String Account, int id)
        {
            text.text = "Deseja acessar as informações do recorde de " + Name + " pertencente a " + Account + ". ";
            _button.onClick.AddListener(AskForAcess);
            this.id = id;
        }

        private async void AskForAcess()
        {
            await BCInteract.Instance.GetAcess(id);
        }
        
        
    }
}