using Common.Scripts.Data.DataConfig;
using Feature.UpgradePu.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Feature.EquipmentPu.Scripts
{
    [Serializable]
    public struct EquipmentInfo
    {
        public int UnlockLevel;
        public Color Color;
        public int Power;
        public int Coin;
        public int Kg;
    }
    [CreateAssetMenu(fileName = "EquipmentDataConfig", menuName = "ScriptableObject/DataAsset/EquipmentDataConfig")]
    public class EquipmentDataConfig : ScriptableObject
    {
        public List<EquipmentInfo> EquipmentInfos;
    }
}
