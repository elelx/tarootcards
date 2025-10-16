using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (HammerManager.Instance != null && HammerManager.Instance.holdingHammer)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HammerManager.Instance.PickUpHammer();

            Destroy(gameObject);
        }
    }
}
