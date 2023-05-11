using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DrawingBehaviour : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private bool _isMousePressed;
    private Vector3 _mousePosition;
    private Camera _mainCamera;
    private bool _isOffTheBoard;

    // Start is called before the first frame update
    private void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if(_lineRenderer == null) return;
        
        _isMousePressed = Input.GetMouseButton(0);
        if (_isMousePressed && (Vector2)Input.mousePosition != (Vector2)_mousePosition)
        {
            DrawLine();
        }
    }

    private void DrawLine()
    {
        _mousePosition = Input.mousePosition;
        if (!IsMouseOverCollider()) return;
        var ray = _mainCamera.ScreenToWorldPoint(_mousePosition);
        ray.z = 0;
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, ray);
    }

    public bool IsMouseOverCollider()
    {
        var ray = _mainCamera.ScreenPointToRay(_mousePosition);
        var colliders = Physics.RaycastAll(ray);
        var isButton = false;
        foreach (var collider2d in colliders)
        {
            if (collider2d.collider.CompareTag("Board"))
            {
                isButton = true;
            }
            else
            {
                isButton = false;
                break;
            }
        }
    
        return isButton;
    }

    public void SetCurrentLine(LineRenderer line)
    {
        _lineRenderer = line;
    }
}