using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CheckRoomClear))]
public class RoomCleared : MonoBehaviour
{

    GameObject playa;
    [SerializeField]
    Animator[] doorsAnimtors;

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
      //  playa = SceneManager.Instance.player;

    }

    private void OpenPortals()
    {
       //Enable Portals On Doors
    }

    public void GetDoorsAnimtors(Animator[] animators)
    {
        doorsAnimtors = animators;

    }

    private void DoDoorsAnimatons()
    {
        foreach (var animator in doorsAnimtors)
        {
            animator.SetTrigger("Open"); 
        }
        SpotLightAnimator.SetTrigger("Spread");
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
