using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombsHandler : MonoBehaviour
{

    [SerializeField]
    int numberOfBombs;

    public int NumberOfBombs
    {
        get { return numberOfBombs; }
        set { numberOfBombs = value; }
    }

    [SerializeField]
    GameObject bombPrefab;

    [SerializeField]
    PlayerUiBombsHandler playerUIBombsHandler;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropBomb()
    {
        if (numberOfBombs > 0)
        {
            numberOfBombs--;
            playerUIBombsHandler.reduceBombAmount(numberOfBombs);
            Instantiate(bombPrefab, new Vector3(transform.position.x, 1, transform.position.z), bombPrefab.transform.rotation);
        }
    }
}
