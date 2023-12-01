using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterOneDirController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public float spawnTime = 4.5f;
    public float maxProjectileLifeSpan = 100f;
    public float projectileSpeed = 3f;

    public enum Direction {
        Left,
        Right,
        Up,
        Down
    }
    public Direction direction;
    Vector2 selectedDir;

    void Start()
    {
        if(direction == Direction.Left)
        {
            selectedDir = Vector2.left;
        }
        else if (direction == Direction.Right)
        {
            selectedDir = Vector2.right;
        }
        else if (direction == Direction.Down)
        {
            selectedDir = Vector2.down;
        }
        else
        {
            selectedDir = Vector2.up;
        }
        spawnProjectiles();
    }

    void spawnProjectiles()
    {
        StartCoroutine(SpawnProjectilesCoroutine());
        IEnumerator SpawnProjectilesCoroutine()
        {
            while (true) {
                yield return new WaitForSeconds(spawnTime);
                GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity);
                BasicProjectileController c = obj.GetComponent<BasicProjectileController>();
                c.setParams(selectedDir, projectileSpeed);

                Destroy(obj, projectileSpeed);
            }
        }
    }
}
