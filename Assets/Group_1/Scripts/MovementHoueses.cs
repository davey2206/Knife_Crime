using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHoueses : MonoBehaviour
{
    [SerializeField] AnimationCurve MoveSpeed;
    float time;
    bool firstTime;

    private void Awake()
    {
        firstTime = true;
    }

    private void OnEnable()
    {
        if (!firstTime)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 120);
        }
    }

    public void updateTime(float t)
    {
        time = t;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * MoveSpeed.Evaluate(time) * Time.deltaTime);

        if (transform.localPosition.z <= -104)
        {
            GetComponentInParent<HousesSpawner>().Spawn(gameObject.name);
            gameObject.SetActive(false);
            firstTime = false;
        }
    }
}
