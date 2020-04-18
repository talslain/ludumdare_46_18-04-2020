using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Interact : MonoBehaviour
{
    [SerializeField] Light2D interactLight;
    [SerializeField] string intereactType;
    [SerializeField] Toggler toggle;

    bool targetted, action;
    Vector2 lastPosition;

    private void Start()
    {
        this.interactLight.color = EventManager.INTERACT_LIGHT;
    }

    public void Targetted(bool t)
    {
        this.targetted = t;
        this.interactLight.enabled = t;
    }

    public void ContactWith(GameObject gameObject)
    {
        this.lastPosition = gameObject.transform.position;
        this.action = false;
    }

    public void InteractWith(GameObject gameObject)
    {
        switch (intereactType)
        {
            case "drag":
                Vector2 positionDifference = ((Vector2) gameObject.transform.position) - this.lastPosition;
                this.transform.position = this.transform.position + new Vector3(positionDifference.x, positionDifference.y, 0);
                this.lastPosition = gameObject.transform.position;
                break;
            case "toggle":
                if (!this.action)
                {
                    toggle.toggle = !toggle.toggle;
                    action = true;
                }
                break;
        }
    }
}
