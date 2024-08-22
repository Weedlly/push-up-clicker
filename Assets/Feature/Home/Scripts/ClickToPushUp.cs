using SuperMaxim.Messaging;
using UnityEngine;

namespace Feature.Home.Scripts
{
    public struct PushUpSuccessPayload
    {
        
    }
    public class ClickToPushUp : MonoBehaviour
    {
        private bool _isDragging;
        public void Update()
        {
            if (_isDragging && Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
                Debug.Log("Release click");
                Messenger.Default.Publish(new PushUpSuccessPayload());
            }
            else if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;
            }
        }
    }
}
