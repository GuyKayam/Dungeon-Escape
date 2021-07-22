using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(NewRoomStart))]
public class CheckRoomClear : MonoBehaviour
{

    public delegate void RoomStateChanged();
    public event RoomStateChanged OnRoomClear;



    int enemiesLeft;

    private void Start()
    {
        
    }


    public void SubscribeToDeathEvents(List<BasicDeath> enemies)
    {
        enemiesLeft = enemies.Count;
        foreach (var enemy in GetComponent<NewRoomStart>().Enemies)
        {
            enemy.OnDeath += EnemyDied;
        }
    }

    public void FinishRoomNow()
    {

        OnRoomClear?.Invoke();
    }



     void EnemyDied()
    {
        enemiesLeft--;
        if (enemiesLeft <= 0)
        {
            OnRoomClear?.Invoke();
        }
    }
}
