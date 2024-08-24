using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Feature.UpgradePu.Scripts
{
    public class SingleStatUpgradeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _txtName;
        [SerializeField] private TextMeshProUGUI _txtPreview;
        [SerializeField] private Button _btn;
        [SerializeField] private TextMeshProUGUI _txtCoinNeedToUpgrade;
        [SerializeField] private Color _upgradableColor;
        [SerializeField] private Color _unUpgradableColor;

        private Action<EStatUpgrade> _onUpgrade;
        private EStatUpgrade _eStatUpgrade;
        private void Awake()
        {
            _btn.onClick.AddListener(OnUpgrade);
        }
        private void OnUpgrade()
        {
            _onUpgrade?.Invoke(_eStatUpgrade);
        }
        public void SetUp(Action<EStatUpgrade> onUpgrade,EStatUpgrade eStatUpgrade, string statName, string txtPreview, int amountCoin)
        {
            _eStatUpgrade = eStatUpgrade;
            _btn.image.color = onUpgrade != null ? _upgradableColor : _unUpgradableColor;
            _txtCoinNeedToUpgrade.text = amountCoin.ToString();
            _txtName.text = statName;
            _txtPreview.text = txtPreview;
            _onUpgrade = onUpgrade;
        }
    }
}
