/* 
This class manages the Win and Loss conditions of the game.

The Update function checks if the win condition has been met every frame.

The WinGame function runs when the game is won and it displays the WinScreen with the
accuracy and time taken statistics of the player. It also renables the cursor in view and unlocks
it from the center of the screen. Finally, it disables all audio.

The LoseGame function runs when the game is lost and it displays the LossScreen. It also re-enables the cursor
in view and unlocks it from the center of the screen. Finally, it disables all audio.

The Restart function runs when the restart button is pressed in the Loss or Win Screen and it reloads the
GameScene.
*/

using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class WinLossManager : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject lossScreen;
    [SerializeField] TextMeshProUGUI accuracyText;
    [SerializeField] TextMeshProUGUI timeText;
    private bool stopUpdate = false;

    void Update()
    {
        if(gun.currentTargetCount == 0)
        {
            WinGame();
        }

        if(uiManager.currentTime >= 60)
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        if(!stopUpdate)
        {
            accuracyText.text = "Accuracy: " + uiManager.accuracy.ToString();
            TimeSpan time = TimeSpan.FromSeconds(uiManager.currentTime);
            timeText.text = "Time Taken: " + time.ToString(@"mm\:ss\:fff");
            stopUpdate = true;
        }

        AudioListener.volume = 0f;
        winScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoseGame()
    {
        lossScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AudioListener.volume = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
