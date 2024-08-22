using Common.Scripts.Navigator;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace Feature.UpgradePu.Scripts
{
    public class UpgradePu : Modal
    {
        [SerializeField] private Button _closeBtn;
        private void Awake()
        {
            _closeBtn.onClick.AddListener(() =>
            {
                NavigatorController.MainModalContainer.Pop(false);
            });
           
        }
    }
}
