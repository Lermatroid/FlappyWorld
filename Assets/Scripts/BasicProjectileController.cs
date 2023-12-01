using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BasicProjectileController : MonoBehaviour
{
    Vector2 direction = Vector2.zero;
    float speed = 0f;
    bool hasBeenParmed = false;

    public void setParams(Vector2 directionToSet, float speedToSet)
    {
        direction = directionToSet;
        speed = speedToSet;
        hasBeenParmed = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasBeenParmed)
        {
            transform.position += speed * Time.fixedDeltaTime * (Vector3)direction;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enviroment") || other.gameObject.CompareTag("DangerZone"))
        {
            Destroy(this.gameObject);
        }
    }
}
