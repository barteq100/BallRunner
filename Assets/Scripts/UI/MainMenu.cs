using Assets.Scripts.Save;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneAsset sceneToRun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        var saveNumber = 0;
        if(PlayerPrefs.HasKey(SaveKeys.LAST_SAVE_NAME))
        {
           var lastSaveName = PlayerPrefs.GetString(SaveKeys.LAST_SAVE_NAME);
           var saveStringNumber = lastSaveName.Replace(string.Format(SaveKeys.SAVE_NAME_TEMPLATE, ""), "");
           saveNumber = int.Parse(saveStringNumber);
        }
        var newSaveName = string.Format(SaveKeys.SAVE_NAME_TEMPLATE, ++saveNumber);
        PlayerPrefs.SetString(SaveKeys.LAST_SAVE_NAME, newSaveName);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneToRun.name);

    }

    public void OpenOptions()
    {

    }

    public void QuitGame()
    {
       Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene(sceneToRun.name);
    }
}
