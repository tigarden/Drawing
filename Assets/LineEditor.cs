using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineEditor : MonoBehaviour
{
    [SerializeField] private LineRenderer _linePrefab;
    [SerializeField] private GameObject _lineBehaviour;
    private LineRenderer _newLine;
    
    
    // public void ChangeColor()
    // {
    //     if (_newLine != null)
    //     {
    //         
    //     }
    //     _newLine.material.color = GetComponent<Image>().color;
    // }

    public void ResetLines()
    {
        var lines = FindObjectsOfType<LineRenderer>();
        if (lines.Length <= 0) return;
        foreach (var t in lines)
        {
            Destroy(t.gameObject);
        }

    }

    public void CreateLine()
    {
        var newLine = Instantiate(_linePrefab);
        newLine.material.color = GetComponent<Image>().color;
        newLine.material.color = GetComponent<Image>().color;
        _lineBehaviour.GetComponent<DrawingBehaviour>().SetCurrentLine(newLine);
    }
}
