using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHealth : MonoBehaviour
{
    public int ricochetsRemaining;
    private float startTime;
    public float maxLifetime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime >= maxLifetime)
        {
            Destroy(gameObject);
        }
    }
private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning("Boop");
        ricochetsRemaining--;
        if (ricochetsRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }
}
