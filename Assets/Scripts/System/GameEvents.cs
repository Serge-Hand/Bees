using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        instance = this;
    }

    public event Action onCollectHoney;
    public void CollectHoney()
    {
        onCollectHoney?.Invoke();
    }

    public event Action onStopCollectHoney;
    public void StopCollectHoney()
    {
        onStopCollectHoney?.Invoke();
    }

    public event Action<int> onAddNectar;
    public void AddNectar(int amount)
    {
        onAddNectar?.Invoke(amount);
    }

    public event Action<int> onSubstractNectar;
    public void SubstractNectar(int amount)
    {
        onSubstractNectar?.Invoke(amount);
    }

    public event Action onLevelUp;
    public void LevelUp()
    {
        onLevelUp?.Invoke();
    }

    public event Action onSpeedUp;
    public void SpeedUp()
    {
        onSpeedUp?.Invoke();
    }

    public event Action onAddBee;
    public void AddBee()
    {
        onAddBee?.Invoke();
    }

}
