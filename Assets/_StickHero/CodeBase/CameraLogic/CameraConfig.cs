using UnityEngine;

[CreateAssetMenu(menuName = "Config/Camer", fileName = "CameraConfig", order = 0)]
public class CameraConfig : ScriptableObject
{
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _cameraSize = 5f;
    [SerializeField] private float _cameraReSizeDuration = 1f;
    
    public float MoveDuration => _moveDuration;
    public float CameraSize => _cameraSize;
    public float CameraReSizeDuration => _cameraReSizeDuration;
}