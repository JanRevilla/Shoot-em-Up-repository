using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int MaxHealth = 3;
    public event Action OnHitReceived;
    public event Action OnLifeDepleted;

    private int currentHealth;

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public void Hit()
    {
        currentHealth -= 1;

        OnHitReceived?.Invoke();

        if (currentHealth <= 0)
        {
            OnLifeDepleted?.Invoke();
        }
    }
}
