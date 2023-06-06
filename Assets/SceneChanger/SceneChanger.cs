using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] public string scenePath;

    public void changeScene()
    {
        SceneManager.LoadScene(scenePath, LoadSceneMode.Single);
    }

    private void OnTriggerEnter(Collider other)
    {
        changeScene();
    }
}
