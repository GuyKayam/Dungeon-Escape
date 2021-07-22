using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CheckRoomClear))]
public class RoomCleared : MonoBehaviour
{
    [SerializeField]
    GameObject[] doors;

    [SerializeField]
    GameObject playerSpotLight;


    bool isDoorOpen = false;

    Animator doorAnimator;
    Animator SpotLightAnimator;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CheckRoomClear>().OnRoomClear += OpenPortals;
        gameObject.GetComponent<CheckRoomClear>().OnRoomClear += DoDoorsAnimatons;
        doorAnimator = doors[0].GetComponent<Animator>();
        SpotLightAnimator = playerSpotLight.GetComponent<Animator>();
    }

    private void OpenPortals()
    {
        //OpenPortals
    }

    private void DoDoorsAnimatons()
    {
        doorAnimator.SetTrigger("Open");
        SpotLightAnimator.SetTrigger("Spread");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
