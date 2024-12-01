using CodeBase.Platform;
using DG.Tweening;
using UnityEngine;

public class CameraMover
{
    private readonly Camera _camera;
    private readonly CameraConfig _cameraConfig;

    public CameraMover(Camera camera, CameraConfig cameraConfig)
    {
        _camera = camera;    
        _cameraConfig = cameraConfig;
    }
    
    public void MoveToPlatform(Platform currentPlatform)
    {
        var platformRenderer = currentPlatform.gameObject.GetComponent<SpriteRenderer>();
        
        float platformLeftEdge = platformRenderer.bounds.min.x;

        float cameraHalfWidth = _camera.orthographicSize * _camera.aspect;

        Vector3 newCameraPosition = _camera.transform.position;
        newCameraPosition.x = platformLeftEdge + cameraHalfWidth;
        _camera.transform.DOMove(newCameraPosition, _cameraConfig.MoveDuration);
    }
}