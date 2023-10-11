using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLocation : MonoBehaviour
{
    public bool key1Found = false;
    public bool key2Found = false;
    public bool key3Found = false;

    public int keyID;

    public GameObject keyObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeKeys()
    {
        int keyRandomisedLocation = Random.Range(1, 4);

        Instantiate(keyObject, transform.position, transform.rotation);
       // keyObject.keyID = 1;
    }

    public void KeyFound (int numberOfKey)
    {
        if (numberOfKey == 1)
        {
            key1Found = true;
        }
        if (numberOfKey == 2)
        {
            key2Found = true;
        }
        if (numberOfKey == 3)
        {
            key3Found = true;
        }
    }
}
