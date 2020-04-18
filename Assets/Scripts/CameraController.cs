using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject cursorObject;
    [SerializeField] Sprite inactive, active;

    SpriteRenderer cursorRenderer;

    public Vector3 defaultPosition
    {
        get;
        private set;
    }

    void Start()
    {
        Cursor.visible = false;
        cursorRenderer = cursorObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        cursorObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)+Vector3.forward;
        if (Input.GetMouseButton(0))
            cursorRenderer.sprite = active;
        else
            cursorRenderer.sprite = inactive;
        transform.position = defaultPosition;

    }

    internal void SetDefaultPosition(Vector2 p)
    {
        this.defaultPosition = new Vector3(p.x, p.y, -10);
    }
}
