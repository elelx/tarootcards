using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameEvents
{
    public static bool doorShouldBeDestroyed = false;
}

public class DestroyDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameEvents.doorShouldBeDestroyed)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
