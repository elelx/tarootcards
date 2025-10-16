using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkViel : MonoBehaviour
{

    public float vielTapCountdown = 5;
    public GameObject viel;

    public float PlayerHealth = 10;

    private Internaction Internaction;

    public float playerNearness = 2f;
    public bool canTap = false;

    public Transform player;
    public GameObject Player;

    public Animator snakeAnimator;

    // Start is called before the first frame update
    void Start()
    {
       
 
        if (Player != null)
        {
            player = Player.transform;
        }

        if (snakeAnimator == null)
        {
            snakeAnimator = GetComponent<Animator>();
        }

        if (Internaction == null)
        {
            Internaction = GetComponent<Internaction>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(player.position, transform.position);

            canTap = distance <= playerNearness;

            if (canTap && vielTapCountdown <= 0)
            {
                FinishViel();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth -= 1 * Time.deltaTime;

            Debug.Log("touched me" + PlayerHealth);

            CheckPlayerHealth();
        }
    }

    void CheckPlayerHealth()
    {
        if (PlayerHealth <= 0)
        {
            Debug.Log("Player is dead!");

            SceneManager.LoadScene("Cup2");
        }
    }



     void OnMouseDown()
    {
        if(canTap && vielTapCountdown > 0)
        {
            vielTapCountdown -= 1;

            Debug.Log("viel lifted" + vielTapCountdown);
        }
 

    }

   void FinishViel()
    {
        if(vielTapCountdown <= 0)
        {

        
            Debug.Log("you got it off!");


            gameProgress.vielTaskDone = true;
            gameProgress.CheckAllTasksComplete();
            Internaction.FinishTask();


        }


        if (viel != null)
        {
            viel.SetActive(false);
        }

        canTap = false;
    }

}

