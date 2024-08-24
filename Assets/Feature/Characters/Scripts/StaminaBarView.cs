using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Feature.Characters.Scripts
{
    public class StaminaBarView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _txtStaminaCount;
        [SerializeField] private Slider _slider;
        
        public void Setup(int maxStamina, int curStamina)
        {
            _txtStaminaCount.text = $"{curStamina}/{maxStamina}";
            _slider.value = curStamina * 1.0f / maxStamina;
        }
    }
}
