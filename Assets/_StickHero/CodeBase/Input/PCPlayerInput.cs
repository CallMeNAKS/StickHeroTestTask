using System;
using UnityEngine;

namespace CodeBase.Input
{
    public class PCPlayerInput : MonoBehaviour, IInputHandler
    {
        public event Action Pressed;
        public event Action EndPressing;
        public event Action Clicked;

        private void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.Mouse0))
            {
                Pressed?.Invoke();
            }

            if (UnityEngine.Input.GetKeyUp(KeyCode.Mouse0))
            {
                EndPressing?.Invoke();
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                Clicked?.Invoke();
            }
        }
    }
}