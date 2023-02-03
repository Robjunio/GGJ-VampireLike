using System;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [HideInInspector] public float currentHealth;
        [HideInInspector] public float currentSpeed;
        public PlayerScriptableObject playerData;

        private void Awake()
        {
            currentHealth = playerData.MaxHealth;
            currentSpeed = playerData.Speed;
        }
    }
}
