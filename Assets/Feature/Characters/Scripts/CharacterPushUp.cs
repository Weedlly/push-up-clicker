using Common.Scripts.Data.DataAsset;
using Feature.EquipmentPu.Scripts;
using SuperMaxim.Messaging;
using UnityEngine;

namespace Feature.Characters.Scripts
{
    public class CharacterPushUp : MonoBehaviour
    {
        [SerializeField] private CommonUserDataAsset _commonUserDataAsset;
        [SerializeField] private EquipmentDataConfig _equipmentDataConfig;
        [SerializeField] private InventoryDataAsset _inventoryDataAsset;
        [SerializeField] private CharacterPushUpAnimation _characterPushUpAnimation;
        [SerializeField] private float _delayNextStep;

        private float _curDelayNextStep;
        private void Awake()
        {
            _characterPushUpAnimation.Setup();
            Messenger.Default.Subscribe<UserClickPayload>(OnUserClick);
        }
        private void OnDestroy()
        {
            Messenger.Default.Unsubscribe<UserClickPayload>(OnUserClick);
        }
        private void Update()
        {
            if (_curDelayNextStep > 0)
                _curDelayNextStep -= Time.deltaTime;
        }
        private void OnUserClick(UserClickPayload payload)
        {
            if (_curDelayNextStep > 0)
                return;

            if (IsEnoughStaminaPushUp())
            {
                _inventoryDataAsset.TryChangeInventoryData(InventoryType.Stamina, - _equipmentDataConfig.EquipmentInfos[_commonUserDataAsset.CurEquipmentIdx].Kg);
                _characterPushUpAnimation.PlayAnim();
                
                if (_characterPushUpAnimation.IsFinalStep())
                    Messenger.Default.Publish(new PushUpSuccessPayload());
                
                _curDelayNextStep = _delayNextStep;
            }
           
        }
        bool IsEnoughStaminaPushUp()
        {
            return _equipmentDataConfig.EquipmentInfos[_commonUserDataAsset.CurEquipmentIdx].Kg <= _inventoryDataAsset.GetInventoryDataByType(InventoryType.Stamina).Amount;
        }
    }
}
