using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUiBombsHandler : MonoBehaviour
{
    [SerializeField]
    Text bombAmount;
    // Start is called before the first frame update
    void Start()
    {
        bombAmount.text = GetComponent<PlayerBombsHandler>().NumberOfBombs.ToString();
    }

    public void reduceBombAmount(int amountLeft)
    {
        bombAmount.text = amountLeft.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
