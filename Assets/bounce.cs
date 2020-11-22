using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    private Rigidbody rigi;
    public float velocidad = 10;
    public float max_random=1;
    public float min_random=1;
    void Awake()
    {
        rigi = transform.GetComponent<Rigidbody>();
        rigi.AddForce(Vector3.right*velocidad*10*Random.Range(min_random,max_random));
    }
}
