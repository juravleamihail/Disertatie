using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject LocalXRRigGameobject;

    public GameObject AvatarHeadGameobject;
    public GameObject AvatarBodyGameobject;

    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine)
        {
            // The player is local
            LocalXRRigGameobject.SetActive(true);

            SetLayerRecursively(AvatarHeadGameobject, 6);
            SetLayerRecursively(AvatarBodyGameobject, 7);
        }
        else
        {
            // The player is remote
            LocalXRRigGameobject.SetActive(false);

            SetLayerRecursively(AvatarHeadGameobject, 0);
            SetLayerRecursively(AvatarBodyGameobject, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
