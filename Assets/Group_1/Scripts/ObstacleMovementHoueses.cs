using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementHoueses : MonoBehaviour
{
    [SerializeField] AnimationCurve MoveSpeed;
    float time;
    bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
        firstTime = false;
    }

    private void OnEnable()
    {
        if (!firstTime)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 75);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * MoveSpeed.Evaluate(time) * Time.deltaTime);

        if (transform.localPosition.z <= -104)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 75);
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            time = time + 0.1f;
        }
    }
}
