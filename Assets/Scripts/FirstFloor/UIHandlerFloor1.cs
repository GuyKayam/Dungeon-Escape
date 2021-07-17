using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandlerFloor1 : MonoBehaviour
{
    [SerializeField]
    GameObject heartContainer;
    [SerializeField]
    PlayerStats playerScript;
    GameObject[] heartContainersArr;
    [SerializeField]
    Transform parentPanel;

    [SerializeField]
    int xMargin = 50;
    [SerializeField]
    int yMargin = 40;

    Image[] heartRenderersArr;


    // Start is called before the first frame update
    void Start()
    {


        Vector3 parentPosition = parentPanel.position;

        heartContainersArr = new GameObject[playerScript.MaxHealth];
        heartRenderersArr = new Image[heartContainersArr.Length];

        for (int i = 0; i < playerScript.StartHealth; i++)
        {
            heartContainersArr[i] = Instantiate(heartContainer, new Vector3(-xMargin + parentPosition.x - (i * xMargin), parentPosition.y - 40, parentPosition.z), parentPanel.rotation) as GameObject;
            heartContainersArr[i].transform.SetParent(parentPanel);
            heartRenderersArr[i] = heartContainersArr[i].transform.GetChild(0).GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHeartsAmount()
    {
        heartRenderersArr[playerScript.CurrentHealth].color = new Color(0, 0, 0);
    }


    void UpdateHeartContainer(int amountToUpdate)
    {

    }
}
