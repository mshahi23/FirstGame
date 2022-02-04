/* 
This class is responsible in controlling the in-game UI.

The Start function initializes the values of the currenTime, accuracy and timeRemaining when the game starts.

The Update function updates the UI every frame. This calculates and updates the player stats like the remaining
number of targets, accuracy and the remmaing time. For the time deltaTime is used to make sure that the 
update are constant even when the frame rate is not constant. For calculating the accuracy there is an if statement
to make sure that we are not dividing by 0.
*/

using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] TextMeshProUGUI timeRemaingText;
    [SerializeField] TextMeshProUGUI accuracyText;
    [SerializeField] TextMeshProUGUI targetCountText;
    public float accuracy;
    public float currentTime;
    public float timeRemaining;

    void Start()
    {
        currentTime = 0;
        timeRemaining = 60;
        accuracy = 0;
    }

    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        timeRemaining = timeRemaining - Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timeRemaining);
        timeRemaingText.text = "Time Remaining: " + time.ToString(@"mm\:ss\:fff");

        if(gun.shootCount != 0)
        {
            accuracy = (gun.hitCount / gun.shootCount) * 100f;
            accuracyText.text = "Accuracy: " + accuracy.ToString("f2");
        }

        targetCountText.text =  "Targets Remaining: " + gun.currentTargetCount.ToString();
    }
}
