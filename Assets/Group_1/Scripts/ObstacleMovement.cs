using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float x;
    [SerializeField] AnimationCurve MoveSpeed;
    float time;
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
                transform.position = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x + 6f, transform.position.y, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
                break;
            case 4:
                transform.position = new Vector3(transform.position.x - 6f, transform.position.y, transform.position.z);
                break;
        }
    }

    public void updateTime(float t)
    {
        time = t;
    }

    private void Update()
    {
        transform.Translate(Vector3.back * MoveSpeed.Evaluate(time) * Time.deltaTime);

        if (transform.localPosition.z <= -100)
        {
            gameObject.SetActive(false);
        }
    }
}
