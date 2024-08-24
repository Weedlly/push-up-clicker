using Common.Scripts.Data.DataAsset;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Feature.UpgradePu.Scripts
{
    [Serializable]
    public class CalculateStatUpgradeCoin
    {
        [SerializeField] private float _perLevelCoinFactor;

        public int GetNextLevelStatUpgradeCoin(int curLevel)
        {
            return (int)(_perLevelCoinFactor * (curLevel + 1));
        }
    }
    public class StatUpgradeViewModel : MonoBehaviour
    {
        [SerializeField] private CalculateStatUpgradeCoin _calculateStatUpgrade;
        [SerializeField] private StatUpgradeConfig _statUpgradeConfig;
        [SerializeField] private InventoryDataAsset _inventoryDataAsset;
        [SerializeField] private StatUpgradeDataAsset _statUpgradeDataAsset;
        [SerializeField] private List<SingleStatUpgradeView> _singleStatUpgradeViews;
        
        private int _coinNeedToUpgrade;
        
        private void Start()
        {
            ResetData();
        }
        private void ResetData()
        {
            // just for demo
            if (_singleStatUpgradeViews.Count == 3)
            {
                SetUpView(0, EStatUpgrade.Power);
                SetUpView(1, EStatUpgrade.Recovery);
                SetUpView(2, EStatUpgrade.Stamina);
            }
        }
        private void SetUpView(int idx, EStatUpgrade eStatUpgrade)
        {
            int curCoin = _inventoryDataAsset.GetInventoryDataByType(InventoryType.Coin).Amount;
            int curStatLevel = _statUpgradeDataAsset.GetStatUpgradeDataByType(eStatUpgrade).Level;
            _coinNeedToUpgrade = _calculateStatUpgrade.GetNextLevelStatUpgradeCoin(curStatLevel);
            bool isUpgradable = _coinNeedToUpgrade <= curCoin;

            int originalStatVal = _statUpgradeConfig.GeConfigByKey(eStatUpgrade).OriginalVal;
            
            _singleStatUpgradeViews[idx].SetUp(
                isUpgradable ? OnClickUpgrade : null,
                eStatUpgrade,
                statName: eStatUpgrade.ToString(),
                txtPreview: $"{originalStatVal * curStatLevel} -> {originalStatVal * (curStatLevel + 1)}",
                _coinNeedToUpgrade
            );
        }
        private void OnClickUpgrade(EStatUpgrade eStatUpgrade)
        {
            _inventoryDataAsset.TryChangeInventoryData(InventoryType.Coin,-_coinNeedToUpgrade);
            _statUpgradeDataAsset.UpgradeStat(eStatUpgrade);
            ResetData();
        }
    }
}
