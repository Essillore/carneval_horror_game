using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKeyReturn : MonoBehaviour
{
    public KeyLocation keyHolder;
    //  public KeyBoolPairs keyPairs;
    // Start is called before the first frame update

    public GameObject endingPortal;
    void Start()
    {
        if(keyHolder.keyFound[0] == true)
        {
            
        }
        if (keyHolder.keyFound[1] == true)
        {

        }
        if (keyHolder.keyFound[2] == true)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carousel"))
        {
            if (keyHolder.keyFound[0] == true && keyHolder.keyFound[1] == true && keyHolder.keyFound[2] == true)
            {
                Vector3 endingPortalPosition = new Vector3(0f, 0f, 63f);
                Instantiate(endingPortal, endingPortalPosition, transform.rotation);
            }
            if (keyHolder.keyFound[0] == true)
            {

            }
            if (keyHolder.keyFound[1] == true)
            {

            }
            if (keyHolder.keyFound[2] == true)
            {

            }
        }
        if (other.CompareTag("Enemy"))
        {
            //play fade screen
          //  transform.position = new Vector3(0f, 0f, 0f);
        }
    }

}
