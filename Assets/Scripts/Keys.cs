using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public int ID;
    public bool found;

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
        if(other.CompareTag("Player"))
        {
            KeyLocation keyLocation = GameObject.FindObjectOfType<KeyLocation>();
            keyLocation.KeyFound(this);
        }
    }  
}
