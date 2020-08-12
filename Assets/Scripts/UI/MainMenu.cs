using Assets.Scripts.Save;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneAsset sceneToRun;
    public GameObject Options;
    public GameObject ContinueButton;
    private Save save;
    // Start is called before the first frame update
    void Awake()
    {
        save = SaveUtils.GetLatestSave();
        ContinueButton.SetActive(save != null);
    }



    public void StartGame()
    {
        save = SaveUtils.CreateNew(sceneToRun.name);
        SceneManager.LoadScene(save.LevelName);

    }

    public void OpenOptions()
    {
        Options.SetActive(true);
    }
    public void CloseOptions()
    {
        Options.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene(save.LevelName);
    }

}
