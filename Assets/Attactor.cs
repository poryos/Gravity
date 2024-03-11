using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attactor : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private const float G = 6.674f;

    private int x = 0;
    public static List<Attactor> Attactors;

    private void FixedUpdate()
    {
        foreach (var attactor in Attactors)
        {
            if (true != this)
            {
                Attract(attactor);
            }
        }
    }

    private void OnEnable()
    {
        if (Attactors == null)
        {
            Attactors = new List<Attactor>();
        }
        Attactors.Add(this);
    }

    void Attract(Attactor other)
    {
        Rigidbody rb2 = other.rb;
        
        //F G(m1*m2)/r"2
        
        //find dictance between 2 object (get both magnitude and direction)
        Vector3 direction = rb.position - rb2.position;

        float distance = direction.magnitude;
        
        //find force between onjects
        float forceManitude = G * (rb.mass * rb2.mass) / Math.Pow(distance,2);
        Vector3 finalforce = direction.normalized forceManitude;
        
        rb2.AddForce(finalforce);

    }
}
