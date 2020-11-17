﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Button : MonoBehaviour
{

    [Tooltip(
        "The Local Y position of the button when it is pushed all the way down. Local Y position will never be less than this.")]
    public float MinLocalY = 0.25f;

    [Tooltip(
        "The Local Y position of the button when it is not being pushed. Local Y position will never be greater than this.")]
    public float MaxLocalY = 0.55f;

    [Tooltip("How far away from MinLocalY / MaxLocalY to be considered a click")]
    public float ClickTolerance = 0.01f;

    [Tooltip(
        "If true the button can be pressed by physical object by utiizing a Spring Joint. Set to false if you don't need / want physics interactions, or are using this on a moving platform.")]
    public bool AllowPhysicsForces = true;

    List<XRController> grabbers; // Grabbers in our trigger
    SpringJoint joint;

    bool clickingDown = false;
    public AudioClip ButtonClick;
    public AudioClip ButtonClickUp;

    public UnityEvent onButtonDown;
    public UnityEvent onButtonUp;

    AudioSource audioSource;
    Rigidbody rigid;

    void Start()
    {
        grabbers = new List<XRController>();
        joint = GetComponent<SpringJoint>();
        rigid = GetComponent<Rigidbody>();

        // Set to kinematic so we are not affected by outside forces
        if (!AllowPhysicsForces)
        {
            rigid.isKinematic = true;
        }

        // Start with button up top / popped up
        transform.localPosition = new Vector3(transform.localPosition.x, MaxLocalY, transform.localPosition.z);

        audioSource = GetComponent<AudioSource>();
    }

    // These have been hard coded for hand speed
    float ButtonSpeed = 15f;
    float SpringForce = 1500f;
    Vector3 buttonDownPosition;
    Vector3 buttonUpPosition;


    void Update()
    {

        buttonDownPosition = GetButtonDownPosition();
        buttonUpPosition = GetButtonUpPosition();
        bool grabberInButton = false;

        // Find a valid grabber to push down
        /*for (int x = 0; x < grabbers.Count; x++)
        {
            if (!grabbers[x].HoldingItem)
            {
                grabberInButton = true;
                break;
            }
        */

        // push button down
        if (grabberInButton)
        {
            float speed = ButtonSpeed;
            transform.localPosition = Vector3.Lerp(transform.localPosition, buttonDownPosition, speed * Time.deltaTime);
            joint.spring = 0;

        }
        else
        {
            // Let the spring push the button up if physics forces are enabled
            if (AllowPhysicsForces)
            {
                joint.spring = SpringForce;
            }
            // Need to lerp back into position if spring won't do it for us
            else
            {
                float speed = ButtonSpeed;
                transform.localPosition =
                    Vector3.Lerp(transform.localPosition, buttonUpPosition, speed * Time.deltaTime);
                joint.spring = 0;
            }
        }

        // Cap values
        if (transform.localPosition.y < MinLocalY)
        {
            transform.localPosition = buttonDownPosition;
        }
        else if (transform.localPosition.y > MaxLocalY)
        {
            transform.localPosition = buttonUpPosition;
        }

        // Click Down?
        float buttonDownDistance = transform.localPosition.y - buttonDownPosition.y;
        if (buttonDownDistance <= ClickTolerance && !clickingDown)
        {
            clickingDown = true;
            OnButtonDown();
        }

        // Click Up?
        float buttonUpDistance = buttonUpPosition.y - transform.localPosition.y;
        if (buttonUpDistance <= ClickTolerance && clickingDown)
        {
            clickingDown = false;
            OnButtonUp();
        }
    }

    public virtual Vector3 GetButtonUpPosition()
    {
        return new Vector3(transform.localPosition.x, MaxLocalY, transform.localPosition.z);
    }

    public virtual Vector3 GetButtonDownPosition()
    {
        return new Vector3(transform.localPosition.x, MinLocalY, transform.localPosition.z);
    }

    // Callback for ButtonDown
    public virtual void OnButtonDown()
    {

        // Play sound
        if (audioSource && ButtonClick)
        {
            audioSource.clip = ButtonClick;
            audioSource.Play();
        }

        // Call event
        if (onButtonDown != null)
        {
            onButtonDown.Invoke();
        }
    }

    // Callback for ButtonDown
    public virtual void OnButtonUp()
    {
        // Play sound
        if (audioSource && ButtonClickUp)
        {
            audioSource.clip = ButtonClickUp;
            audioSource.Play();
        }

        // Call event
        if (onButtonUp != null)
        {
            onButtonUp.Invoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        XRController grab = other.GetComponent<XRController>();
        if (grab != null)
        {
            if (grabbers == null)
            {
                grabbers = new List<XRController>();
            }

            if (!grabbers.Contains(grab))
            {
                grabbers.Add(grab);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        XRController grab = other.GetComponent<XRController>();
        if (grab != null)
        {
            if (grabbers.Contains(grab))
            {
                grabbers.Remove(grab);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Show Grip Point
        Gizmos.color = Color.blue;

        Vector3 upPosition =
            transform.TransformPoint(new Vector3(transform.localPosition.x, MaxLocalY, transform.localPosition.z));
        Vector3 downPosition =
            transform.TransformPoint(new Vector3(transform.localPosition.x, MinLocalY, transform.localPosition.z));

        Vector3 size = new Vector3(0.005f, 0.005f, 0.005f);

        Gizmos.DrawCube(upPosition, size);

        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(downPosition, size);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(upPosition, downPosition);
    }
}
