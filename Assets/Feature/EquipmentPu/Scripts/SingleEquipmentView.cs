using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Feature.EquipmentPu.Scripts
{
    public class SingleEquipmentView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _txtKg;
        [SerializeField] private TextMeshProUGUI _txtPower;
        [SerializeField] private TextMeshProUGUI _txtCoin;
        [SerializeField] private TextMeshProUGUI _txtSelect;
        [SerializeField] private Button _btn;
        [SerializeField] private Color _selectableColor;
        [SerializeField] private Color _unOwnedColor;
        [SerializeField] private Color _selectedColor;
        
        private Action<int> _onSelect;
        private int _idx;
        private void Awake()
        {
            _btn.onClick.AddListener(OnSelect);
        }
        private void OnSelect()
        {
            _onSelect?.Invoke(_idx);
        }
        public void SetUp(Action<int> onSelect,int idx, string txtKg, string txtPower, string txtCoin, EEquipmentStatus eEquipmentStatus)
        {
            _idx = idx;

            _txtKg.text = txtKg;
            _txtPower.text = txtPower;
            _txtCoin.text = txtCoin;
            _onSelect = onSelect;
            
            _btn.image.color = onSelect != null ? _selectableColor : _selectedColor;
            switch (eEquipmentStatus)
            {
                case EEquipmentStatus.Selected:
                    {
                        _btn.image.color = _selectedColor;
                        _txtSelect.text = "Selected";
                        break;
                    }
                case EEquipmentStatus.UnOwned: {
                        _btn.image.color = _unOwnedColor;
                        _txtSelect.text = "UnOwned";
                        break;
                    }
                case EEquipmentStatus.OwnedAndUnSelected: {
                        _btn.image.color = _selectableColor;
                        _txtSelect.text = "Select";
                        break;
                    }
            }
        }
    }
}
