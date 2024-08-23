using Feature.UpgradePu.Scripts;
using SuperMaxim.Messaging;
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

    public struct StatUpgradeSuccess
    {
        public EStatUpgrade EStatUpgrade;
    }
    [Serializable]
    public struct StatUpgradeDataModel : IDefaultDataModel
    {
        public List<StatUpgradeData> ListStatUpgradeData;
        public bool IsEmpty()
        {
            return ListStatUpgradeData == null || ListStatUpgradeData.Count == 0;
        }
        public void SetDefault()
        {
            ListStatUpgradeData = new List<StatUpgradeData>
            {
                new StatUpgradeData
                {
                    EStatUpgrade = EStatUpgrade.Power,
                    Level = 1,
                },
                new StatUpgradeData
                {
                    EStatUpgrade = EStatUpgrade.Stamina,
                    Level = 1,
                },
                new StatUpgradeData
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
        public void UpgradeStat(EStatUpgrade eStatUpgrade)
        {
            for (int i = 0; i < ListStatUpgradeData.Count; i++)
            {
                if (ListStatUpgradeData[i].EStatUpgrade != eStatUpgrade)
                    continue;
                StatUpgradeData statUpgradeData = ListStatUpgradeData[i];
                statUpgradeData.Level += 1;
                ListStatUpgradeData[i] = statUpgradeData; // Reassign the modified struct back to the list
        
                SaveData();

                Messenger.Default.Publish(new StatUpgradeSuccess
                {
                    EStatUpgrade = eStatUpgrade,
                });
                break;
            }
        }
    }
}
