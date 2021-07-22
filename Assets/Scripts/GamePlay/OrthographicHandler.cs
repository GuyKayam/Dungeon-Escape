using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicHandler : MonoBehaviour
{
    [SerializeField]
    GameObject room;

    float roomHeight;
    float roomWidth;
    float aspectRatio;
    // Start is called before the first frame update
    void Start()
    {
       roomHeight= room.transform.localScale.y;
        GetComponent<Camera>().orthographicSize  = roomHeight/2;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
