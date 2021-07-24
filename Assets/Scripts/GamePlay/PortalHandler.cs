using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHandler : MonoBehaviour
{
    public delegate void PortalTransportation();
    public event PortalTransportation OnPortalEntered;




    [SerializeField]
    Vector3 transportPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = transportPosition;
        OnPortalEntered?.Invoke();

    }
}
