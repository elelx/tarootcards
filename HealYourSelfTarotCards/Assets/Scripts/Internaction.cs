using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Internaction : MonoBehaviour
{

    public GameObject[] TextImages;

    public GameObject thankYouUI;


    public Animator animator;

    public EndAnimation EndAnimation;

    public DoorDestroy DoorDestroy;

    private int currentIndex = 0;
    private bool taskFinished = false;

    private bool inSpace = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < TextImages.Length; i++)
        {
            TextImages[i].SetActive(i == 0);
        }

        if (thankYouUI != null)
            thankYouUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inSpace && !taskFinished && Input.GetKeyDown(KeyCode.E))
        {
            CycleImages();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            inSpace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inSpace = false;
        }
    }



    void CycleImages()
    {

        TextImages[currentIndex].SetActive(false);

        currentIndex +=1;

        if (currentIndex >= TextImages.Length)
        {
            FinishTask();
            return;
        }

        // Show next image
        TextImages[currentIndex].SetActive(true);
    }

   public void FinishTask()
    {
        animator.SetTrigger("Victory");

        taskFinished = true;



        Debug.Log("finished");

        GameEvents.doorShouldBeDestroyed = true;

    }

}
