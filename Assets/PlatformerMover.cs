using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMover : MonoBehaviour
{
    public Rigidbody rigi;
    public float forceAdded;
    public bool direction;
    private float randomSeed;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            StartCoroutine(MovePlatform(0.5f));
        }
    }

    IEnumerator MovePlatform(float time)
    {
        yield return new WaitForSeconds(time);
        randomSeed = Random.Range(-10.0f, 10.0f);
        direction = CalculateDirection(randomSeed);
        rigi.isKinematic = false;

        if (direction)
        {
            rigi.AddForce(transform.up * forceAdded);
        }
        else
        {
            rigi.AddForce(transform.up * -forceAdded);
        }
        StartCoroutine(ResetForces(1.0f));
    }

    bool CalculateDirection(float seed)
    {
        if (seed > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator ResetForces(float time)
    {
        yield return new WaitForSeconds(time);
        rigi.isKinematic = true;
        rigi.velocity = Vector3.zero;
    }
}
