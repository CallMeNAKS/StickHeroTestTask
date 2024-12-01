using UnityEngine;

[CreateAssetMenu(menuName = "Config/Camer", fileName = "CameraConfig", order = 0)]
public class CameraConfig : ScriptableObject
{
    [SerializeField] private float _moveDuration;
    
    public float MoveDuration => _moveDuration;
}