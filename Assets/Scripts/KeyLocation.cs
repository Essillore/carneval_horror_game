using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyBoolPairs
{
    public int keyNumber;
    public bool found;
}


public class KeyLocation : MonoBehaviour
{
    public bool key1Found = false;
    public bool key2Found = false; 
    public bool key3Found = false;

    public Dictionary<int, Keys> keyDict = new Dictionary<int, Keys>(); 

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

    public void KeyFound (Keys numberofKey)
    {

        if(keyDict.ContainsKey(numberofKey.ID))
        {
            keyDict[numberofKey.ID].found = true;
        }
        else
        {
            keyDict.Add(numberofKey.ID, numberofKey);
        }
    }
}
