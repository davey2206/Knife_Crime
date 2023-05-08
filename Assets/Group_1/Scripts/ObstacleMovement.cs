using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float x;
    private void OnEnable()
    {
        int rng = Random.Range(0,5);
        transform.localPosition = Vector3.zero;

        switch (rng)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x + 5.1f, transform.position.y, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x + 10.2f, transform.position.y, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x - 5.1f, transform.position.y, transform.position.z);
                break;
            case 4:
                transform.position = new Vector3(transform.position.x - 10.2f, transform.position.y, transform.position.z);
                break;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.localPosition.x, 0, -70), 0.1f);

        if (transform.localPosition.z <= -70)
        {
            gameObject.SetActive(false);
        }
    }
}
