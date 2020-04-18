using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject cursorObject;

    public Vector3 defaultPosition
    {
        get;
        private set;
    }

    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        cursorObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)+Vector3.forward;
        transform.position = defaultPosition;
    }

    internal void SetDefaultPosition(Vector2 p)
    {
        this.defaultPosition = new Vector3(p.x, p.y, -10);
    }
}
