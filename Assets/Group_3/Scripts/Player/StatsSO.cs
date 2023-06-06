using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stat", menuName = "Stat")]
public class StatsSO : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float stoppingDistance;

    public int Health { get => health; }
    public float MovementSpeed { get => movementSpeed; }
    public float JumpHeight { get => jumpHeight; }
    public float StoppingDistance { get => stoppingDistance; }
}
