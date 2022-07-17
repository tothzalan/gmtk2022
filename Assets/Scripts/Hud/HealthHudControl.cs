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
            if (_image == null)
                return;
            if (0 > health)
                _image.sprite = healthBar[0];
            _image.sprite = healthBar[health];
        }
    }
}
