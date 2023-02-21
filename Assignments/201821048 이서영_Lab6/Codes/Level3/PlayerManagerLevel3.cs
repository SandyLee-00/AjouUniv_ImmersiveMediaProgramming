using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerManagerLevel3 : MonoBehaviour
{

    private int enemyCnt = 0;
    public AudioSource audio1;
    public GameObject Enemies;

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy:");
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");
            Debug.Log("Points :" + enemyCnt);
            audio1.Play();
        }
        
    }

    public void OnGrabUTS(SelectEnterEventArgs args)
    {
        // Destroy all remaining enemies
        while(Enemies.transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        Debug.Log("Level Cleared");
        Debug.Log("Points :" + enemyCnt);

    }
}
