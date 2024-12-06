using System;
using UnityEngine;

namespace CodeBase.UI
{
    public abstract class UIView : MonoBehaviour
    {
        [SerializeField] private GameObject[] _uiElements;

        private void Awake()
        {
            foreach (var uiElement in _uiElements)
            {
                uiElement.SetActive(false);
            }
        }

        public void ShowUI()
        {
            ToggleUI(true);
        }

        public void HideUI()
        {
            ToggleUI(false);
        }

        private void ToggleUI(bool isEnable)
        {
            foreach (GameObject uiElement in _uiElements)
            {
                uiElement.SetActive(isEnable);
            }
        }
    }
}