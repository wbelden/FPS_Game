using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if(keyboard.digit7Key.wasPressedThisFrame) {
            Application.LoadLevel(0);
        }
        if(keyboard.digit8Key.wasPressedThisFrame) {
            if(Time.timeScale == 1) {
                Time.timeScale = 0;
            } else {
                Time.timeScale = 1;
            }
        }

        if(keyboard.digit9Key.wasPressedThisFrame) {
            Application.Quit(0);
        }

        if(keyboard.digit0Key.wasPressedThisFrame) {
            if(AudioListener.volume == 1) {
                AudioListener.volume = 0;
            } else {
                AudioListener.volume = 1;
            }
        }
    }
}
