using System;
using UnityEngine;

namespace Common.Scripts.Data.DataAsset
{
    [Serializable]
    public struct CommonUserDataModel : IDefaultDataModel
    {
        public int CurEquipmentIdx;
        public bool IsEmpty()
        {
            return false;
        }
        public void SetDefault()
        {
            CurEquipmentIdx = 0;
        }
    }

    [CreateAssetMenu(fileName = "CommonUserDataAsset", menuName = "ScriptableObject/DataAsset/CommonUserDataAsset")]
    public class CommonUserDataAsset : LocalDataAsset<CommonUserDataModel>
    {
        public int CurEquipmentIdx
        {
            set
            {
                _model.CurEquipmentIdx = value;
            }
            get
            {
                return _model.CurEquipmentIdx;
            }
        }
    }
   
}
