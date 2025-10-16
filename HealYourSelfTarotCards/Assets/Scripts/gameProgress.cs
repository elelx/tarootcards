using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameProgress : MonoBehaviour
{

    public static bool vielTaskDone = false;
    public static bool snakeTaskDone = false;
    public static bool breakTaskDone = false;

    public static void CheckAllTasksComplete()
    {
        Debug.Log($"CheckAllTasksComplete: vielTaskDone={vielTaskDone}, snakeTaskDone={snakeTaskDone}, breakTaskDone={breakTaskDone}");

        if (vielTaskDone && snakeTaskDone && breakTaskDone)
        {

            Debug.Log("✅ All tasks complete. Loading final scene...");
            SceneManager.LoadScene("finalScene"); // <-- change this to your actual final scene name
        }
    }
}
