using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Setting;
    bool settingsActive = false;
    public void PlayGame()
    {
        GetComponent<SceneChanger>().changeScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
