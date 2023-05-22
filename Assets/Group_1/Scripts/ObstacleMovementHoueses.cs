using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementHoueses : MonoBehaviour
{
    [SerializeField] AnimationCurve MoveSpeed;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        getObjectInFront();
        time = time + Time.deltaTime;

        transform.Translate(Vector3.right * MoveSpeed.Evaluate(time) * Time.deltaTime);

        if (transform.localPosition.z <= -104)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 75);
        }
    }

    public void getObjectInFront()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 5f))
        {
            transform.localPosition = new Vector3(0,0, hit.transform.parent.localPosition.z - 8);
        }
    }
}
