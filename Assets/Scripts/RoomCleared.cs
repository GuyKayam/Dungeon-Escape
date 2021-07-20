using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CheckRoomClear))]
public class RoomCleared : MonoBehaviour
{
    [SerializeField]
    GameObject[] doors;


    bool isDoorOpen = false;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CheckRoomClear>().OnRoomClear += OpenPortals;
        gameObject.GetComponent<CheckRoomClear>().OnRoomClear += DoDoorsAnimatons;
      animator = doors[0].GetComponent<Animator>();
    }

    private void OpenPortals()
    {
        //OpenPortals
    }

    private void DoDoorsAnimatons()
    {
        animator.SetTrigger("Open");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
