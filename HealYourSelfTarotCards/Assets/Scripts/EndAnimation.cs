using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class EndAnimation : MonoBehaviour

{
    public string mainSceneName = "SampleScene";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAnimationComplete()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
