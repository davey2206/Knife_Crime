using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToggle : MonoBehaviour
{
    [SerializeField] MeshRenderer playerKnife;
    [SerializeField] MeshRenderer enemyKnife;

    [SerializeField] DamageTracker playerDT;
    [SerializeField] DamageTracker enemyDT;

    [SerializeField] EnemyController enemyController;
    [SerializeField] PlayerController playerController;

    public void ToggleGame(bool isOn)
    {
        // cursed method dont read
        foreach(SkinnedMeshRenderer SMR in GetComponentsInChildren<SkinnedMeshRenderer>(true))
        {
            SMR.enabled = isOn;
        }

        playerKnife.enabled = isOn;
        enemyKnife.enabled = isOn;

        playerDT.ResetHitpoints();
        enemyDT.ResetHitpoints();

        enemyController.ToggleEnemyAI(isOn);
        playerController.ignoreNextHit();
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
