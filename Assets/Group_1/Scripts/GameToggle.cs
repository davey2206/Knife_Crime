using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToggle : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer playerModel;
    [SerializeField] MeshRenderer playerKnife;
    [SerializeField] SkinnedMeshRenderer enemyModel;
    [SerializeField] MeshRenderer enemyKnife;

    [SerializeField] DamageTracker playerDT;
    [SerializeField] DamageTracker enemyDT;

    [SerializeField] EnemyController enemyController;

    public void ToggleGame(bool isOn)
    {
        // cursed method dont read
        playerModel.enabled = isOn;
        enemyModel.enabled = isOn;

        playerKnife.enabled = isOn;
        enemyKnife.enabled = isOn;

        playerDT.ResetHitpoints();
        enemyDT.ResetHitpoints();

        enemyController.ToggleEnemyAI(isOn);
    }


}
