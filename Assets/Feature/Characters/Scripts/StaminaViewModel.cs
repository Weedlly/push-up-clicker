using Common.Scripts.Data.DataAsset;
using Feature.UpgradePu.Scripts;
using SuperMaxim.Messaging;
using UnityEngine;

namespace Feature.Characters.Scripts
{
    public class StaminaViewModel : MonoBehaviour
    {
        [SerializeField] private InventoryDataAsset _inventoryDataAsset;
        [SerializeField] private StatUpgradeDataAsset _statUpgradeDataAsset;
        [SerializeField] private StatUpgradeConfig _statUpgradeConfig;
        [SerializeField] private StaminaBarView _staminaBarView;
        private int _staminaRecoverPerSecond;
        private int _maxStamina;
        private int _curStamina;

        private void Awake()
        {
            _curStamina = _inventoryDataAsset.GetInventoryDataByType(InventoryType.Stamina).Amount;
            CalculateRecoverPerSecondAndMaxStamina();
            _staminaBarView.Setup(_maxStamina,_curStamina);
            
            Messenger.Default.Subscribe<StatUpgradeSuccess>(OnUpgradeStatSuccess);
        }
        private void OnDestroy()
        {
            Messenger.Default.Unsubscribe<StatUpgradeSuccess>(OnUpgradeStatSuccess);
        }
        private float _oneSecond = 1f;
        private void Update()
        {
            _oneSecond -= Time.deltaTime;
            if (_oneSecond < 0)
            {
                _oneSecond = 1f;

                RecoverStamina();
            }
        }
        private void RecoverStamina()
        {
            _curStamina = _inventoryDataAsset.GetInventoryDataByType(InventoryType.Stamina).Amount;
            if (_curStamina == _maxStamina)
                return;
            
            if (_curStamina + _staminaRecoverPerSecond <= _maxStamina)
            {
                _inventoryDataAsset.TryChangeInventoryData(InventoryType.Stamina, _staminaRecoverPerSecond);
            }
            else
            {
                _inventoryDataAsset.TryChangeInventoryData(InventoryType.Stamina, _maxStamina - _curStamina);
            }
            
            _curStamina = _inventoryDataAsset.GetInventoryDataByType(InventoryType.Stamina).Amount;
            _staminaBarView.Setup(_maxStamina,_curStamina);
        }
        private void OnUpgradeStatSuccess(StatUpgradeSuccess payload)
        {
            CalculateRecoverPerSecondAndMaxStamina();
        }
        private void CalculateRecoverPerSecondAndMaxStamina()
        {
            int curRecoverLv = _statUpgradeDataAsset.GetStatUpgradeDataByType(EStatUpgrade.Recovery).Level;
            int originRecoverVal = _statUpgradeConfig.GeConfigByKey(EStatUpgrade.Recovery).OriginalVal;
            _staminaRecoverPerSecond = originRecoverVal * curRecoverLv;
            
            int curStaminaLv = _statUpgradeDataAsset.GetStatUpgradeDataByType(EStatUpgrade.Stamina).Level;
            int originStaminaVal = _statUpgradeConfig.GeConfigByKey(EStatUpgrade.Stamina).OriginalVal;
            _maxStamina = curStaminaLv * originStaminaVal;
        }
    }
}
