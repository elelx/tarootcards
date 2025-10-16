using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwatTheSnake : MonoBehaviour
{

    public Internaction Internaction;


    public int swatTimeRequired = 10;
    public float currentSwatTime = 0f;

    public bool isSwatting = false;
    public bool hasWon = false;

    public GameObject snake;
    public GameObject man;

    private Animator snakeAnimator;
    private float swatTimeout = 1.0f;
    private float swatTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        snakeAnimator = snake.GetComponent<Animator>();
        snakeAnimator.SetBool("IsMoving", true);
    }

    // Update is called once per frame
    void Update()
    {

        if (hasWon) return;

        if (isSwatting)
        {
            currentSwatTime += Time.deltaTime;
            Debug.Log($"Swatting timer: {currentSwatTime:F2} seconds");

            if (currentSwatTime >= swatTimeRequired)
            {
                WinGame();
            }
        }

    }

    public void OnMouseDown()
    {
        if (hasWon) return;

        isSwatting = true;
        Debug.Log("Started swatting");

        if (snakeAnimator != null)
            snakeAnimator.SetBool("IsMoving", false);
        

    }

    public void OnMouseUp()
    {
        if (hasWon) return;

        isSwatting = false;
        Debug.Log("Stopped swatting");

        if (snakeAnimator != null)
            snakeAnimator.SetBool("IsMoving", true); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Man"))
        {
            SceneManager.LoadScene("Cup3");
        }
    }



    void WinGame()
    {
        hasWon = true;
        Debug.Log("You saved the man!");
        snakeAnimator.speed = 0f;



    //    snakeAnimator.SetBool("IsMoving", false);
     this.enabled = false;

        gameProgress.snakeTaskDone = true;

        gameProgress.CheckAllTasksComplete();

        Internaction.FinishTask();


    }
}
