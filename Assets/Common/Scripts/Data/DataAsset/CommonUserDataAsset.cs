using System;
using UnityEngine;

namespace Common.Scripts.Data.DataAsset
{
    [Serializable]
    public struct CommonUserDataModel : IDefaultDataModel
    {
        public int CurEquipmentLevel;
        public bool IsEmpty()
        {
            return false;
        }
        public void SetDefault()
        {
            CurEquipmentLevel = 0;
        }
    }

    [CreateAssetMenu(fileName = "CommonUserDataAsset", menuName = "ScriptableObject/DataAsset/CommonUserDataAsset")]
    public class CommonUserDataAsset : LocalDataAsset<CommonUserDataModel>
    {
        public int CurEquipmentLevel
        {
            set
            {
                _model.CurEquipmentLevel = value;
            }
            get
            {
                return _model.CurEquipmentLevel;
            }
        }
    }
   
}
