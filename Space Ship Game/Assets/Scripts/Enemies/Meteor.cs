using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float spinSpeed = 10.0f;

    protected override void Start()
    {
        base.Start();
        // Inicialización específica para Meteor si es necesario
    }

    protected override void Update()
    {
        base.Update();
        Spin();
    }

    private void Spin()
    {
        // Hacer que el meteorito gire
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }
}
