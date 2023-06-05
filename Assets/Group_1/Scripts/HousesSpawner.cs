using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesSpawner : MonoBehaviour
{
    float time;

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        foreach (Transform child in transform)
        {
            child.GetComponent<MovementHoueses>().updateTime(time);
        }
    }

    public void Spawn(string name)
    {
        foreach (Transform child in transform)
        {
            if (!child.transform.gameObject.activeInHierarchy && child.gameObject.name != name)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
