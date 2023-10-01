using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats/EntityStats", menuName = "EntityStats")]
public class Stats : ScriptableObject
{
    [SerializeField]
    private float health;
    public float Health => health;

    [SerializeField]
    private float speed;
    public float Speed => speed;
}