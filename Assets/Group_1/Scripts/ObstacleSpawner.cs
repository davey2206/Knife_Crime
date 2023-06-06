using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] AnimationCurve SpawnSpeed;
    [SerializeField] AnimationCurve NumberOfSpawns;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnUnit());
        time = 0;
    }

    void Update()
    {
        time = time + Time.deltaTime;

        foreach (Transform child in transform)
        {
            child.GetComponent<ObstacleMovement>().updateTime(time);
        }
    }

    IEnumerator spawnUnit()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(1, (int)NumberOfSpawns.Evaluate(time)); i++)
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
                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(SpawnSpeed.Evaluate(time));
        }
    }
}
