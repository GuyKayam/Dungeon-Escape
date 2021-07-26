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

    PlayerUiBombsHandler playerUIBombsHandler;
    // Start is called before the first frame update
    void Start()
    {
        playerUIBombsHandler = GetComponent<PlayerUiBombsHandler>();
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
            playerUIBombsHandler.UpdateBombAmount(numberOfBombs);
            Instantiate(bombPrefab, new Vector3(transform.position.x, 1, transform.position.z), bombPrefab.transform.rotation);
        }
    }

    public void ChangeBombsAmount(int changeNumber)
    {
        if (numberOfBombs + changeNumber <= 0)
        {
            numberOfBombs = 0;
        }
        else
        {
            numberOfBombs += changeNumber;
        }
        playerUIBombsHandler.UpdateBombAmount(numberOfBombs);

    }
}
