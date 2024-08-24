using Common.Scripts.Data.DataAsset;
using SuperMaxim.Messaging;
using UnityEngine;

namespace Common.Scripts.Inventory
{
    public class CommonInventoryDataViewModel : MonoBehaviour
    {
        [SerializeField] protected InventoryType _inventoryType;
        [SerializeField] protected CommonInventoryDataView _inventoryDataView;
        [SerializeField] protected InventoryDataAsset _inventoryDataAsset;
        private void Start()
        {
            SubscribeAmountChange();
            SetUpView();
        }
        private void OnDestroy()
        {
            UnSubscribeAmountChange();
        }
        private void OnInventoryChange(InventoryChangePayload payload)
        {
            SetUpView();
        }
        protected virtual void SetUpView()
        {
            InventoryData inventoryData = _inventoryDataAsset.GetInventoryDataByType(_inventoryType);
            _inventoryDataView.Setup(inventoryData.Amount);
        }
        private void SubscribeAmountChange()
        {
            Messenger.Default.Subscribe<InventoryChangePayload>(OnInventoryChange, payload => payload.InventoryType == _inventoryType);
        }
        private void UnSubscribeAmountChange()
        {
            Messenger.Default.Subscribe<InventoryChangePayload>(OnInventoryChange, payload => payload.InventoryType == _inventoryType);
        }
    }
}
