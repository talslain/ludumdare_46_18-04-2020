using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;

    Interact intereactTarget;

    CameraController mainCamera;
    Animator animator;

    void Start()
    {
        mainCamera = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Walk Calculations
        float movementSpeed = (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed);
        Vector3 move = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        );
        Vector2 newPosition = transform.position + move * movementSpeed * Time.deltaTime;
        transform.position = newPosition;
        mainCamera.SetDefaultPosition(newPosition);

        //Turning Calculation
        Vector2 mouPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;
        Vector2 dir = mouPos - myPos;
        float angle =(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //Interaction
        if (Input.GetMouseButtonDown(0))
            InteractWithWorld(true);
        else if (Input.GetMouseButton(0))
            InteractWithWorld(false);

        if(move.magnitude > 0)
            this.animator.SetBool("moving", true);
        else
            this.animator.SetBool("moving", false);
        if (!Input.GetMouseButton(0))
            this.animator.SetBool("interact", false);
    }

    void InteractWithWorld(bool first)
    {
        this.animator.SetBool("interact", true);
        if(this.intereactTarget)
            if(first)
                this.intereactTarget.ContactWith(gameObject);
            else
                this.intereactTarget.InteractWith(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Intereact"))
        {
            if (this.intereactTarget == null)
            {
                Interact target = collision.GetComponent<Interact>();
                this.intereactTarget = target;
                target.Targetted(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Intereact"))
        {
            if (this.intereactTarget != null)
            {
                Interact target = collision.GetComponent<Interact>();
                if (target == this.intereactTarget)
                {
                    this.intereactTarget = null;
                    target.Targetted(false);
                }
            }
        }
    }
}
