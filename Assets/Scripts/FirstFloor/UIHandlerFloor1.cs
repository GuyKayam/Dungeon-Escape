using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandlerFloor1 : MonoBehaviour
{
    [SerializeField]
    GameObject heartContainer;
    [SerializeField]
    PlayerHealth playerHealthScript;
    GameObject[] heartContainersArr;
    [SerializeField]
    Transform parentPanel;

    [SerializeField]
    int xMargin = 5;
    [SerializeField]
    int yMargin = 40;
    [SerializeField]
    int startMargin = 460;
    Image[] heartRenderersArr;


    // Start is called before the first frame update
    void Start()
    {
        playerHealthScript.OnHealthChanged += ChangeHeartsAmount;
        Vector3 parentPosition = parentPanel.position;

        heartContainersArr = new GameObject[playerHealthScript.MaxHealth];
        heartRenderersArr = new Image[heartContainersArr.Length];

        for (int i = 0; i < playerHealthScript.StartHealth; i++)
        {
            heartContainersArr[i] = Instantiate(heartContainer, new Vector3(startMargin + parentPosition.x + (i * xMargin), parentPosition.y - yMargin, parentPosition.z), new Quaternion(0, 0, 0, 0)) as GameObject;
            heartContainersArr[i].transform.SetParent(parentPanel, false);
            heartRenderersArr[i] = heartContainersArr[i].transform.GetChild(0).GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHeartsAmount(int changeInHealth)
    {
        int currentHP = playerHealthScript.CurrentHealth - 1;
        int remainingHP = currentHP - changeInHealth;

        if (remainingHP+1 > 0)
        {
            for (int i = currentHP; i > remainingHP; i--)
            {
                heartRenderersArr[i].color = new Color(0, 0, 0);
            }
        }
        else
        {
            for (int i = currentHP; i >= 0; i--)
            {
                heartRenderersArr[i].color = new Color(0, 0, 0);
            }
        }

    }


    void UpdateHeartContainer(int amountToUpdate)
    {

    }
}
