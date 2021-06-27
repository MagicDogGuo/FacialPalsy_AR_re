using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 100;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //Start the object moving.
        rb2d.velocity = new Vector2(moveSpeed, 0);
    }

    void Update()
    {
        // If the game is over, stop scrolling.
        //if (MainGameManager.Instance.BirdisDead == true)
        //{
        //    rb2d.velocity = Vector2.zero;
        //}
    }
}
