using Common.Scripts.Data.DataAsset;
using Feature.Characters.Scripts;
using Feature.EquipmentPu.Scripts;
using SuperMaxim.Messaging;
using UnityEngine;

namespace Feature.Home.Scripts
{
    public class PushUpSuccessRewarding : MonoBehaviour
    {
        [SerializeField] private CommonUserDataAsset _commonUserDataAsset;
        [SerializeField] private EquipmentDataConfig _equipmentDataConfig;
        [SerializeField] private InventoryDataAsset _inventoryDataAsset;
        [SerializeField] private PushUpRewardingEffect _pushUpRewardingEffect;
        private void Awake()
        {
            Messenger.Default.Subscribe<PushUpSuccessPayload>(OnRewarding);
        }
        private void OnDestroy()
        {
            Messenger.Default.Unsubscribe<PushUpSuccessPayload>(OnRewarding);
        }
        private async void OnRewarding(PushUpSuccessPayload payload)
        {
            await _pushUpRewardingEffect.PlayAnim();
            EquipmentInfo equipmentInfo = _equipmentDataConfig.EquipmentInfos[_commonUserDataAsset.CurEquipmentIdx];
            
            _inventoryDataAsset.TryChangeInventoryData(InventoryType.Coin, equipmentInfo.Coin);
            _inventoryDataAsset.TryChangeInventoryData(InventoryType.Power, equipmentInfo.Power);
        }
    }
}
