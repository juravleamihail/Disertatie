using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TennisRacket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var xrGrabInteractable = GetComponent<XRGrabInteractable>();

        if (xrGrabInteractable != null)
        {
            xrGrabInteractable.interactionManager = GameObject.FindGameObjectWithTag("XR Interaction Manager").GetComponent<XRInteractionManager>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TennisBall ball = collision.gameObject.GetComponent<TennisBall>();

        if(ball != null)
        {
            Vector3 normal = collision.GetContact(0).normal;
            ball.GetComponent<Rigidbody>().AddForce(normal * ball.bounceStrength);
        }
    }
}
