using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBuddyController : MonoBehaviour
{
    public AudioSource audio1;
    int trashNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        //GameManager.scoreTask2 += 1;
        Destroy(other);
        trashNum += 1;
        Debug.Log("point : " + trashNum);

        if(trashNum >= 7)
        {
            Debug.Log("Level Cleared");
        }
        audio1.Play();

    }
}
