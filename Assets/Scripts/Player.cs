using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _acceleration = 5f;
    [SerializeField] float _deceleration = 5f;
    [SerializeField] float _maxSpeed = 20f;
    [SerializeField] float _maxHealth = 100f;

    public float CurrentHealth;
    public int Score;

    public event Action HealthChanged;
    public event Action ScoreChanged;
    void Awake()
    {
        CurrentHealth = _maxHealth;
    }
    public float GetAcceleration()
    {
        return _acceleration;
    }
    public float GetDeceleration()
    {
        return _deceleration;
    }
    public float GetMaxSpeed()
    {
        return _maxSpeed;
    }
    public float GetCurrentHealthNormalised()
    {
        return CurrentHealth / _maxHealth;
    }
}
