using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOrange : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket")) 
        {
            Destroy(gameObject);
        }
        
    }
}
