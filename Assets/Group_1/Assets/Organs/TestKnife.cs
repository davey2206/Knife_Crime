using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKnife : MonoBehaviour
{
    // this script is purely for testing knife collision prior to a knife being implemented
    // let Ben(me) or Davey know if you find this after it is redundant
    // so that we can remove it without creating a git conflict

    [SerializeField] public float min = 4f;
    [SerializeField] public float max = 4f;
    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
    }

}
