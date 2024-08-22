using Common.Scripts.Navigator;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Feature.Home.Scripts
{
    public class HomeScreen : Page
    {
        [SerializeField] private Button _btnUpgrade;
        [SerializeField] private Button _btnEquipment;

        private void Awake()
        {
            _btnUpgrade.onClick.AddListener(() =>
            {
                NavigatorController.MainModalContainer.Push(ResourceKey.Prefabs.UpgradeStatPu, false);
            });
            _btnEquipment.onClick.AddListener(() =>
            {
                NavigatorController.MainModalContainer.Push(ResourceKey.Prefabs.EquipmentPu, false);
            });
        }
    }
}
