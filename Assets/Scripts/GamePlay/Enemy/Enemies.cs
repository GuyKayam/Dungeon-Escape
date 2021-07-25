using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BasicDeath))]
public class Enemies : MonoBehaviour
{
    public static int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount++;
        GetComponent<BasicDeath>().OnDeath += ReduceEnemyCountByOne;
    }

    private void OnDestroy()
    {
        GetComponent<BasicDeath>().OnDeath -= ReduceEnemyCountByOne;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ReduceEnemyCountByOne()
    {
        enemyCount--;
    }
}
