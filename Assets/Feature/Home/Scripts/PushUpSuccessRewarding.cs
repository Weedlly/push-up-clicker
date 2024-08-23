using Feature.Characters.Scripts;
using SuperMaxim.Messaging;
using UnityEngine;

namespace Feature.Home.Scripts
{
    public class PushUpSuccessRewarding : MonoBehaviour
    {
        [SerializeField] private PushUpRewardingEffect _pushUpRewardingEffect;
        private void Awake()
        {
            Messenger.Default.Subscribe<UserClickPayload>(OnRewarding);
        }
        private void OnDestroy()
        {
            Messenger.Default.Unsubscribe<UserClickPayload>(OnRewarding);
        }
        private void OnRewarding(UserClickPayload payload)
        {
            _pushUpRewardingEffect.PlayAnim();
        }
    }
}
