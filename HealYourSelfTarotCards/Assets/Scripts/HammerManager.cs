using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerManager : MonoBehaviour
{

    public static HammerManager Instance;

    public bool holdingHammer = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject); // Keep across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one exists
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpHammer()
    {
        holdingHammer = true;
    }

    public void DropHammer()
    {
        holdingHammer = false;
    }
}
