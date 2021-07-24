using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(NewRoomStart))]
public class CheckRoomClear : MonoBehaviour
{

    public delegate void RoomStateChanged();
    public event RoomStateChanged OnRoomClear;


    public void SubscribeToDeathEvents(List<BasicDeath> enemies)
    {
        foreach (var enemy in GetComponent<NewRoomStart>().Enemies)
        {
            enemy.OnDeath += CheckIfRoomCleared;
        }
    }

    public void FinishRoomNow()
    {
        OnRoomClear?.Invoke();
    }


    void CheckIfRoomCleared()
    {
        if (Enemies.enemyCount <= 0)
        {
            OnRoomClear?.Invoke();
        }
    }
}
