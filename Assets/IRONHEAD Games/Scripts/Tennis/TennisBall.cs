using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TennisBall : MonoBehaviour
{
    public Vector3 StartPos;
    public float bounceStrength = 1;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        var xrGrabInteractable = GetComponent<XRGrabInteractable>();

        if(xrGrabInteractable != null)
        {
            xrGrabInteractable.interactionManager = GameObject.FindGameObjectWithTag("XR Interaction Manager").GetComponent<XRInteractionManager>();
        }

        Restart();
    }

    void Restart()
    {
        RestartVelocity();
        transform.localPosition = StartPos;
    }

    void RestartVelocity()
    {
        rigidbody.velocity = new Vector3(0f, 0f, 0f);
        rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Restart();
        }
    }
}
