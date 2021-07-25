using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CheckRoomClear))]
public class RoomCleared : MonoBehaviour
{
    [SerializeField]
    List<EnteredThroughDoor> doors;

    BoxCollider[] doorsPortalColliders;
    Animator[] doorsAnimators;

    GameObject playerSpotLight;


    Animator SpotLightAnimator;

    private void Awake()
    {
        gameObject.GetComponent<CheckRoomClear>().OnRoomClear += OpenPortals;
        gameObject.GetComponent<CheckRoomClear>().OnRoomClear += DoDoorsAnimatons;
        SpotLightAnimator = PlayerReference.instance.transform.GetChild(3).GetComponent<Animator>();
    }  

    // Start is called before the first frame update
    void Start()
    {

    }
    public void GetDoorsAndCacheRef(Transform doorsParent)
    {
        doorsPortalColliders = doorsParent.GetComponentsInChildren<BoxCollider>();
        doorsAnimators = doorsParent.GetComponentsInChildren<Animator>();
    }

    private void OpenPortals()
    {

        foreach (var boxcollider in doorsPortalColliders)
        {
            boxcollider.enabled = true;
        }

      
    }



    private void DoDoorsAnimatons()
    {
        foreach (var animator in doorsAnimators)
        {
            animator.SetTrigger("Open");
        }
        SpotLightAnimator.SetTrigger("Spread");
        DestroySelf();
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
