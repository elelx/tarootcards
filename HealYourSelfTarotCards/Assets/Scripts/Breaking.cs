using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaking : MonoBehaviour
{
    // public GameObject breakThisWall;

    // public GameObject hammer;

    //private bool holdingHammer = false;

    public GameObject HammerSpeechUI;

    public GameObject particlePrefab;

    public bool allTileBroke = false;

    public Internaction Internaction;

    // Start is called before the first frame update
    void Start()
    {
        if (HammerSpeechUI != null)
            HammerSpeechUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseDown()
    {
        if (HammerManager.Instance.holdingHammer)
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(particlePrefab, mousePos, Quaternion.identity);

            Destroy(gameObject);

            CheckAllBroken();

        }

        else
        {

            if (HammerSpeechUI != null)
            {
                HammerSpeechUI.SetActive(!HammerSpeechUI.activeSelf);
                Debug.Log("UI should now be visible");


            }


            Debug.Log("you need to grab the hammer ");
        }
    }

    void CheckAllBroken()
    {
        int remaining = GameObject.FindGameObjectsWithTag("Breakable").Length;
        Debug.Log($"Remaining breakable tiles: {remaining}");


        if (remaining == 1)
        {
            allTileBroke = true;
            Debug.Log("All tiles are broken! Task finished.");



            gameProgress.breakTaskDone = true;
            Debug.Log("Set breakTaskDone = true");

            gameProgress.CheckAllTasksComplete();

            Internaction.FinishTask();


        }
    }
}



