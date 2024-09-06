using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private int health = 1;
    [SerializeField] private GameObject explosionPrefab;

    protected virtual void Start()
    {
        // Inicializaci�n si es necesario
    }

    protected virtual void Update()
    {
        // Actualizaci�n com�n para todos los enemigos
        Move();
    }

    protected void Move()
    {
        // Movimiento simple hacia abajo (puedes personalizarlo seg�n tu juego)
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
