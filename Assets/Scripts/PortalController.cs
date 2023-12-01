using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    // Start is called before the first frame update
    public int rotationSpeed = 75;
    public Object scene;
    public bool usable = true;
    public string nextSceneName;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && usable)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
