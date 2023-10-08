using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Stats/EntityStats")]
public class Stats : ScriptableObject
{
    [SerializeField]
    private int health;

    public int Health => health;

    [SerializeField]
    private float speed;

    public float Speed => speed;
}