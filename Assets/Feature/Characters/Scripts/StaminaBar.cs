using Common.Scripts.Data.DataAsset;
using Feature.UpgradePu.Scripts;
using SuperMaxim.Messaging;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Feature.Characters.Scripts
{
    public class StaminaBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _txtStaminaCount;
        [SerializeField] private Slider _slider;
        [SerializeField] private StatUpgradeDataAsset _statUpgradeDataAsset;
        [SerializeField] private StatUpgradeConfig _statUpgradeConfig;

        private void Awake()
        {
            Messenger.Default.Subscribe<StatUpgradeSuccess>(OnUpgradeStatSuccess);
        }
        private void OnDestroy()
        {
            Messenger.Default.Unsubscribe<StatUpgradeSuccess>(OnUpgradeStatSuccess);
        }
        private void OnUpgradeStatSuccess(StatUpgradeSuccess payload)
        {
            int curStaminaLv = _statUpgradeDataAsset.GetStatUpgradeDataByType(EStatUpgrade.Stamina).Level;
            int originStaminaVal = _statUpgradeConfig.GeConfigByKey(EStatUpgrade.Stamina).OriginalVal;
            _maxStamina = curStaminaLv * originStaminaVal;
            
            _txtStaminaCount.text = payload.
        }
    }
}
