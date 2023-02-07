using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    public float Sensitivity = 0.8f;

    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;

    private bool _isRotating;

    void Update()
    {
        if (_isRotating)
        {
            _mouseOffset = Input.mousePosition - _mouseReference;
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * Sensitivity;
            transform.Rotate(_rotation);
            _mouseReference = Input.mousePosition;
        }
    }

    private void OnMouseDown()
    {
        _isRotating = true;

        _mouseReference = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        _isRotating = false;
    }
}
