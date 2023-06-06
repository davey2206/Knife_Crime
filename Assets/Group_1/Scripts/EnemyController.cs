using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] AnimationsControllerTest animationsController;
    [SerializeField] GameObject target;
    [SerializeField] float attackInterval;
    private float attackIntervalBackup;
    private bool on = false;

    private void Awake()
    {
        attackIntervalBackup = attackInterval;
    }

    public void ToggleEnemyAI(bool isOn)
    {
        on = isOn;
        attackInterval = attackIntervalBackup;
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            attackInterval = attackInterval - Time.deltaTime;
            if (attackInterval <= 0)
            {
                attackInterval = attackIntervalBackup + Random.Range(-1, 1);
                StartCoroutine(animationsController.stab());
            }
        }
    }
}
