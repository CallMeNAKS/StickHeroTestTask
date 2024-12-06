using System.Collections;
using CodeBase.Platform;
using DG.Tweening;
using UnityEngine;

public class CameraMover
{
    private readonly Camera _camera;
    private readonly CameraConfig _cameraConfig;
    private readonly Vector3 _startPosition;

    private float _startCameraSize;

    public CameraMover(Camera camera, CameraConfig cameraConfig)
    {
        _camera = camera;    
        _cameraConfig = cameraConfig;
        _startPosition = camera.transform.position;
    }
    
    public void MoveToPlatform(Platform currentPlatform)
    {
        float platformLeftEdge = currentPlatform.MinX;

        float cameraHalfWidth = _cameraConfig.CameraSize * _camera.aspect;

        Vector3 newCameraPosition = _camera.transform.position;
        newCameraPosition.x = platformLeftEdge + cameraHalfWidth;
        _camera.transform.DOMove(newCameraPosition, _cameraConfig.MoveDuration);
    }

    public IEnumerator ScaleCamera()
    {
        _startCameraSize = _camera.orthographicSize;
        yield return _camera.DOOrthoSize(_cameraConfig.CameraSize, _cameraConfig.CameraReSizeDuration).WaitForCompletion();
    }

    public void ResetCamera()
    {
        _camera.transform.position = _startPosition;
        _camera.orthographicSize = _startCameraSize;
    }
}