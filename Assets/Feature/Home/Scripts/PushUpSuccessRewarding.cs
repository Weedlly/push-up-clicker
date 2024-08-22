using SuperMaxim.Messaging;
using UnityEngine;

namespace Feature.Home.Scripts
{
    public class PushUpSuccessRewarding : MonoBehaviour
    {
        [SerializeField] private PushUpRewardingEffect _pushUpRewardingEffect;
        private void Awake()
        {
            Messenger.Default.Subscribe<PushUpSuccessPayload>(OnRewarding);
        }
        private void OnDestroy()
        {
            Messenger.Default.Subscribe<PushUpSuccessPayload>(OnRewarding);
        }
        private void OnRewarding(PushUpSuccessPayload payload)
        {
            _pushUpRewardingEffect.PlayAnim();
        }
    }
}
