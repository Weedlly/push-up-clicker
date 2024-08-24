using SuperMaxim.Messaging;
using UnityEngine;

namespace Feature.Characters.Scripts
{
    public struct PushUpSuccessPayload {}
    public struct UserClickPayload { }
    public class ClickToPushUp : MonoBehaviour
    {
        private bool _isDragging;
        public void Update()
        {
            if (_isDragging && Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
                
                Messenger.Default.Publish(new UserClickPayload());
            }
            else if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;
            }
        }
    }
}
