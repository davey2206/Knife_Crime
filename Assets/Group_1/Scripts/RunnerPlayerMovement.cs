using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerPlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 7)
            {
                transform.Translate(Vector3.right * 10 * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -7)
            {
                transform.Translate(Vector3.left * 10 * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
