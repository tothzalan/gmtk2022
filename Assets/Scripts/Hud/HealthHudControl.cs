using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hud
{
    public class HealthHudControl : MonoBehaviour
    {
        public List<Sprite> healthBar;

        private Image _image;
    
        void Start()
        {
            _image = gameObject.GetComponent<Image>();
        }

        public void UpdateHealth(int health)
        {
            _image.sprite = healthBar[health];
        }
    }
}
