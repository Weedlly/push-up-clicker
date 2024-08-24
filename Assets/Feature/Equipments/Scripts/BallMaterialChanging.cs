using Common.Scripts.Data.DataAsset;
using Feature.EquipmentPu.Scripts;
using SuperMaxim.Messaging;
using UnityEngine;

namespace Feature.Characters.Scripts
{
    public struct EquipmentChangingPayload
    {
    }

    public class BallMaterialChanging : MonoBehaviour
    {
        [SerializeField] private CommonUserDataAsset _commonUserDataAsset;
        [SerializeField] private EquipmentDataConfig _equipmentDataConfig;
        [SerializeField] private InventoryDataAsset _inventoryDataAsset;
        [SerializeField] private MeshRenderer _meshRenderer;
        private void Awake()
        {
            Messenger.Default.Subscribe<EquipmentChangingPayload>(OnEquipmentChanging);
        }
        private void OnDestroy()
        {
            Messenger.Default.Unsubscribe<EquipmentChangingPayload>(OnEquipmentChanging);
        }
        private void OnEquipmentChanging(EquipmentChangingPayload payload)
        {
            _meshRenderer.materials[0] = _equipmentDataConfig.EquipmentInfos[_commonUserDataAsset.CurEquipmentIdx].Material;
        }

    }
}
