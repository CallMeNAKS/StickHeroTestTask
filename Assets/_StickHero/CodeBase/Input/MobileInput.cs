using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Input
{
    public class MobileInput : MonoBehaviour, IInputHandler
    {
        public event Action Pressed;
        public event Action EndPressing;
        public event Action Clicked;
        
        private bool _isPressed = false;

        private void Update()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                Touch touch = UnityEngine.Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _isPressed = true;
                    Clicked?.Invoke();
                }

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _isPressed = false;
                    EndPressing?.Invoke();
                }
            }

            if (_isPressed)
            {
                Pressed?.Invoke();
            }
        }
    }
}