using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnEnable()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>(); 
        }
    }

    //TODO: Попадание в цель
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}