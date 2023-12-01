using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterFourWayController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public float spawnTime = 4.5f;
    public float maxProjectileLifeSpan = 100f;
    void Start()
    {
        spawnProjectiles();
    }

    void spawnProjectiles()
    {
        StartCoroutine(SpawnProjectilesCoroutine());
        IEnumerator SpawnProjectilesCoroutine()
        {
            while (true) {
                yield return new WaitForSeconds(spawnTime);
                GameObject left = Instantiate(projectile, transform.position, Quaternion.identity);
                BasicProjectileController c_left = left.GetComponent<BasicProjectileController>();
                c_left.setParams(Vector2.left, 3f);

                GameObject right = Instantiate(projectile, transform.position, Quaternion.identity);
                BasicProjectileController c_right = right.GetComponent<BasicProjectileController>();
                c_right.setParams(Vector2.right, 3f);

                GameObject up = Instantiate(projectile, transform.position, Quaternion.identity);
                BasicProjectileController c_up = up.GetComponent<BasicProjectileController>();
                c_up.setParams(Vector2.up, 3f);

                GameObject down = Instantiate(projectile, transform.position, Quaternion.identity);
                BasicProjectileController c_down = down.GetComponent<BasicProjectileController>();
                c_down.setParams(Vector2.down, 3f);

                Destroy(left, maxProjectileLifeSpan);
                Destroy(right, maxProjectileLifeSpan);
                Destroy(up, maxProjectileLifeSpan);
                Destroy(down, maxProjectileLifeSpan);
            }
        }
    }
}
