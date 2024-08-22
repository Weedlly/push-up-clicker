using Common.Scripts.Data.DataConfig;
using System;
using UnityEngine;

namespace Feature.UpgradePu.Scripts
{
    public enum EStatUpgrade
    {
        Power = 1,
        Stamina = 2,
        Recovery = 3,
    }
    [Serializable]
    public struct StatInfo
    {
        public int OriginalVal;
    }
    [CreateAssetMenu(fileName = "StatUpgradeConfig", menuName = "ScriptableObject/DataAsset/StatUpgradeConfig")]
    public class StatUpgradeConfig : DataConfigBase<EStatUpgrade, StatInfo>
    {
        
    }
}
