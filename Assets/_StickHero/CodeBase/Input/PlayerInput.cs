using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _maxScale = 10f;
    [SerializeField] private float _scaleSpeed = 3f;

    private Vector3 _initialScale;
    private Vector3 _initialPosition;

    private void Start()
    {
        _initialScale = _prefab.transform.localScale;
        _initialPosition = _prefab.transform.position;
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ScaleUp();
            Debug.Log("GetKeyDown");
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("GetKeyUp");
        }
    }

    private void ScaleUp()
    {
        if (_prefab.transform.localScale.y >= _maxScale) return;

        Vector3 newScale = _prefab.transform.localScale + Vector3.up * _scaleSpeed * Time.deltaTime;
        _prefab.transform.localScale = newScale;
    }
}
