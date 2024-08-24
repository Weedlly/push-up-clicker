using Common.Scripts.Data.DataAsset;
using Feature.Characters.Scripts;
using SuperMaxim.Messaging;
using System.Collections.Generic;
using UnityEngine;

namespace Feature.EquipmentPu.Scripts
{
    public enum EEquipmentStatus
    {
        Selected,
        UnOwned,
        OwnedAndUnSelected,
    }
    public class EquipmentViewModel : MonoBehaviour
    {
        [SerializeField] private EquipmentDataConfig _equipmentDataConfig;
        [SerializeField] private InventoryDataAsset _inventoryDataAsset;
        [SerializeField] private CommonUserDataAsset _commonUserDataAsset;
        [SerializeField] private List<SingleEquipmentView> _singleEquipmentViews;
        private void Start()
        {
            RefreshData();
        }
        private void RefreshData()
        {
            // just for demo
            if (_singleEquipmentViews.Count == 2)
            {
                SetUpView(0, _equipmentDataConfig.EquipmentInfos[0]);
                SetUpView(1, _equipmentDataConfig.EquipmentInfos[1]);
            }
        }
        private void SetUpView(int idx, EquipmentInfo equipmentInfo)
        {
            EEquipmentStatus eEquipmentStatus;
            int curLevelPower = _inventoryDataAsset.GetPowerLevel();

            if (equipmentInfo.UnlockLevel > curLevelPower)
            {
                eEquipmentStatus = EEquipmentStatus.UnOwned;
            }
            else if (idx == _commonUserDataAsset.CurEquipmentIdx)
            {
                eEquipmentStatus = EEquipmentStatus.Selected;
            }
            else
            {
                eEquipmentStatus = EEquipmentStatus.OwnedAndUnSelected;
            }

            bool isSelectable = eEquipmentStatus == EEquipmentStatus.OwnedAndUnSelected;
            
            _singleEquipmentViews[idx].SetUp(
                isSelectable ? OnSelected : null,
                idx: idx,
                txtKg: equipmentInfo.Kg.ToString(),
                txtPower : equipmentInfo.Power.ToString(),
                txtCoin : equipmentInfo.Coin.ToString(),
                eEquipmentStatus: eEquipmentStatus
            );
        }
        private void OnSelected(int idx)
        {
            _commonUserDataAsset.CurEquipmentIdx = idx;
            RefreshData();
            Messenger.Default.Publish(new EquipmentChangingPayload());
        }
    }
}
