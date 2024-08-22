using Feature.UpgradePu.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Scripts.Data.DataAsset
{
    [Serializable]
    public struct StatUpgradeData
    {
        public EStatUpgrade EStatUpgrade;
        public int Level;
    }
    
    [Serializable]
    public struct StatUpgradeDataModel : IDefaultDataModel
    {
        public List<StatUpgradeData> ListStatUpgradeData;
        public bool IsEmpty()
        {
            return false;
        }
        public void SetDefault()
        {
            ListStatUpgradeData = new List<StatUpgradeData>
            {
                new StatUpgradeData()
                {
                    EStatUpgrade = EStatUpgrade.Power,
                    Level = 1,
                },
                new StatUpgradeData()
                {
                    EStatUpgrade = EStatUpgrade.Stamina,
                    Level = 1,
                },
                new StatUpgradeData()
                {
                    EStatUpgrade = EStatUpgrade.Recovery,
                    Level = 1,
                },
            };
        }
    }
    
    [CreateAssetMenu(fileName = "StatUpgradeDataAsset", menuName = "ScriptableObject/DataAsset/StatUpgradeDataAsset")]
    public class StatUpgradeDataAsset : LocalDataAsset<StatUpgradeDataModel>
    {
        public List<StatUpgradeData> ListStatUpgradeData
        {
            get
            {
                return _model.ListStatUpgradeData ?? (_model.ListStatUpgradeData = new List<StatUpgradeData>
                {
                    new StatUpgradeData()
                    {
                        EStatUpgrade = EStatUpgrade.Power,
                        Level = 1,
                    },
                    new StatUpgradeData()
                    {
                        EStatUpgrade = EStatUpgrade.Stamina,
                        Level = 1,
                    },
                    new StatUpgradeData()
                    {
                        EStatUpgrade = EStatUpgrade.Recovery,
                        Level = 1,
                    },
                });
            }
            set
            {
                _model.ListStatUpgradeData = value;
            }
        }
        
        public StatUpgradeData GetStatUpgradeDataByType(EStatUpgrade type)
        {
            return ListStatUpgradeData.Find(data => data.EStatUpgrade == type);
        }
    }
}
