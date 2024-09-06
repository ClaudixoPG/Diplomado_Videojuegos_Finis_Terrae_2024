using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f;
    [SerializeField] private Vector2 direction = new Vector2(0, 1);
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private Sprite Sprite;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //Method to move the bullet
    public void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    //check if the bullet is out of the main camera view
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
