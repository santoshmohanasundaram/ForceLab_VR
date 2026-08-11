using UnityEngine;

public class LongPressToQuit : MonoBehaviour
{
    private float pressDuration = 2.0f; // Time in seconds for a long press
    private float pressStartTime;
    private bool isPressing = false;

    void Update()
    {
        if (Input.touchCount > 0) // Check if there's at least one touch
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began)
            {
                isPressing = true;
                pressStartTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isPressing = false;
            }

            // Check if the press duration exceeds the threshold
            if (isPressing && Time.time - pressStartTime >= pressDuration)
            {
                QuitApp();
            }
        }
        else
        {
            isPressing = false; // Reset if no touch detected
        }
    }

    void QuitApp()
    {
        Debug.Log("Quitting App...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
