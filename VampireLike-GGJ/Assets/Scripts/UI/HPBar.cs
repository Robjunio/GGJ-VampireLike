using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private Transform _hpBar;

        public void UpdateBar(int current, int max)
        {
            float percentage = (float) current / max;

            if (percentage < 0f)
            {
                percentage = 0f;
            }

            _hpBar.transform.localScale = new Vector3(percentage, 1f, 1f);
        }
    }

}