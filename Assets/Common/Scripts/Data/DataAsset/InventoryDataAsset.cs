using CustomInspector;
using SuperMaxim.Messaging;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Scripts.Data.DataAsset
{
    public enum InventoryType
    {
        Power = 1,
        Stamina = 3,
        Coin = 2,
    }

    [Serializable]
    public struct InventoryData
    {
        public InventoryType InventoryType;
        public int Amount;
    }

    [Serializable]
    public struct InventoryDataModel : IDefaultDataModel
    {
        public List<InventoryData> ListInventoryData;
        public bool IsEmpty()
        {
            return false;
        }
        public void SetDefault()
        {
            ListInventoryData = new List<InventoryData>
            {
                new InventoryData
                {
                    InventoryType = InventoryType.Power,
                    Amount = 0,
                },
                new InventoryData
                {
                    InventoryType = InventoryType.Coin,
                    Amount = 0,
                },
                new InventoryData
                {
                    InventoryType = InventoryType.Stamina,
                    Amount = 10,
                },
            };
        }
    }

    [CreateAssetMenu(fileName = "InventoryDataAsset", menuName = "ScriptableObject/DataAsset/InventoryDataAsset")]
    public class InventoryDataAsset : LocalDataAsset<InventoryDataModel>
    {
        public List<InventoryData> InventoryDatas
        {
            get
            {
                return _model.ListInventoryData ??= new List<InventoryData>();
            }
        }
#if UNITY_EDITOR
        [Button("TestTryChangeInventoryData")]
        public InventoryType TestInventoryType;
        public int TestAmountChange;
        public void TestTryChangeInventoryData()
        {
            TryChangeInventoryData(TestInventoryType, TestAmountChange);
        }
#endif
        public void TryChangeInventoryData(InventoryType type, int amountChange)
        {
            for (int i = 0; i < InventoryDatas.Count; i++)
            {
                if (InventoryDatas[i].InventoryType != type)
                    continue;
                InventoryData updatedInventory = InventoryDatas[i];
                updatedInventory.Amount += amountChange;
                InventoryDatas[i] = updatedInventory; // Reassign the modified struct back to the list

                SaveData();
                
                NotifyAmountChange(type);
                break;
            }
        }
        private static void NotifyAmountChange(InventoryType inventoryType)
        {
            Messenger.Default.Publish(new InventoryChangePayload
            {
                InventoryType = inventoryType,
            });
        }
        public InventoryData GetInventoryDataByType(InventoryType type)
        {
            return InventoryDatas.Find(data => data.InventoryType == type);
        }
        public List<InventoryData> GetInventoryData()
        {
            return InventoryDatas;
        }
        public int GetPowerLevel()
        {
            //todo
            // replace with another class to calculate level
            return (GetInventoryDataByType(InventoryType.Power).Amount / 100) + 1;
        }
    }

    public struct InventoryChangePayload
    {
        public InventoryType InventoryType;
    }
}