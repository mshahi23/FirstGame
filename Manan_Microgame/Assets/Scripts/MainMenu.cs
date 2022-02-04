/* 
This class is used to control the MainMenu. However, it is also used for exit operations in the Win and Loss
screens.

The PlayGame function is used to load the GameScene when the PlayButton is pressed.

The Exit function is used to quit the game in the built application, or quit the game in the unity editor.

The Start function is used to initialize the Main Menu theme of the game. It checks whether the current scene is the main menu.
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource menuTheme;
    [SerializeField] GameObject infoScreen;
    private Scene currentScene;
    private string sceneName;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void InfoMenu()
    {
        infoScreen.SetActive(true);
    }

    public void Return()
    {
        infoScreen.SetActive(false);
    }

    public void Exit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if(sceneName == "MainMenu")
        {
            menuTheme.Play();
        }
    }
}
