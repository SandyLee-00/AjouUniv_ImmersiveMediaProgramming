using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerManager : MonoBehaviour
{

    private int enemyCnt = 0;
    public AudioSource audio1;

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy:");
        }

    }
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("Enemy"))
        {
            GameObject pointingObj = args.interactableObject.transform.gameObject;
            Destroy(pointingObj);

            enemyCnt += 1;
            Debug.Log("Points :" + enemyCnt);
            Debug.Log("remained Enemy :" + (10 - enemyCnt));
            if (enemyCnt >= 10)
            {
                Debug.Log("Level Cleared");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game Over");
        audio1.Play();
        Application.Quit();
    }
}
