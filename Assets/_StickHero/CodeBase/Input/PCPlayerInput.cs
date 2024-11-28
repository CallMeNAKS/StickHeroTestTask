using System;
using UnityEngine;

namespace CodeBase.Input
{
    public class PCPlayerInput : MonoBehaviour, IInputHandler
    {
        public event Action StartPressing;
        public event Action EndPressing;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartPressing?.Invoke();
            }

            if (UnityEngine.Input.GetKeyUp(KeyCode.Mouse0))
            {
                EndPressing?.Invoke();
            }
        }
    }
}