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
        ID = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            KeyLocation.KeyFound(ID);
        }
    }

}
