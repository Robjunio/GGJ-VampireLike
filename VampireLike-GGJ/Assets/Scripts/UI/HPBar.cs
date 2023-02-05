using UnityEngine;

namespace UI
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private Transform hpBar;

        public void UpdateBar(float current, float max)
        {
            float percentage = current / max;

            if (percentage < 0f)
            {
                percentage = 0f;
            }

            hpBar.transform.localScale = new Vector3(percentage, 1f, 1f);
        }
    }

}