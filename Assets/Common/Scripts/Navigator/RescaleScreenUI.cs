using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Common.Scripts.Navigator
{
    public class RescaleScreenUI : MonoBehaviour
    {
        [SerializeField] CanvasScaler _canvasUi;

        private float _scaler;
        private int _width;
        private int _height;
        private static float GetScale(int width, int height, Vector2 scalerReferenceResolution, float scalerMatchWidthOrHeight)
        {
            return Mathf.Pow(width / scalerReferenceResolution.x, 1f - scalerMatchWidthOrHeight) *
                   Mathf.Pow(height / scalerReferenceResolution.y, scalerMatchWidthOrHeight);
        }
        void Awake()
        {
            SetCanvasScaler();
        }

        // Scaling canvas 
        private void SetCanvasScaler()
        {
            _height = Screen.height;
            _width = Screen.width;
            float screenScale = 16f/9;
            _scaler = GetScale(_height, _width, new Vector2(_width, _height),1f);
            if (_scaler >= screenScale)
            {
                if (_canvasUi != null)
                    _canvasUi.matchWidthOrHeight = 1;
            }
            else
            {
                if (_canvasUi != null)
                    _canvasUi.matchWidthOrHeight = 0;
            }
        }
    }
}