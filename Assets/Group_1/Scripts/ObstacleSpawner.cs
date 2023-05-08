using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnUnit());
    }

    IEnumerator spawnUnit()
    {
        while (true)
        {
            int rng = Random.Range(0, transform.childCount);
            bool stop = true;

            foreach (Transform child in transform)
            {
                if (child.gameObject.activeInHierarchy) continue;

                stop = false;
            }

            while (transform.GetChild(rng).gameObject.activeInHierarchy && stop == false)
            {
                rng = Random.Range(0, transform.childCount);
            }

            transform.GetChild(rng).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
