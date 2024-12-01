using System;
using UnityEngine;

namespace CodeBase.Bridge
{
    public class Bridge : MonoBehaviour
    {
        [SerializeField] private Transform _scaledTransform;
        
        public Transform ScaledTransform => _scaledTransform;
    }
}

