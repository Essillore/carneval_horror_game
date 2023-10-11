using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareClown : MonoBehaviour
{
    private const float Y = 180f;
    public GameObject player;

    public float howOften = 5f;
    public float randomiserScare;
    public float interval1 = 40f;
    public float interval2 = 60f;
    public float interval3 = 80f;
    public float interval4 = 100f;
    public float interval5 = 120f;
    public AudioSource laugh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonController");
        RandomizeHowOftenScare();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ScareInterval(float howOften)
    {
        yield return new WaitForSeconds(howOften);
        Scare();
    }

    public void RandomizeHowOftenScare()
    {
        randomiserScare = Random.Range(1f, 5f);
        if (randomiserScare <= 1f)
        {
            howOften = interval1;
        }
        else if (randomiserScare <=2f)
        {
            howOften = interval2;
        }
        else if (randomiserScare <= 3f)
        {
            howOften = interval3;
        }
        else if (randomiserScare <= 4f)
        {
            howOften = interval4;
        }
        else if (randomiserScare <= 5f)
        {
            howOften = interval5;
        }
        StartCoroutine(ScareInterval(howOften));
    }

    public void Scare()
    {
        //   player.GetPlayerPosition();
        transform.position = player.transform.position + player.transform.forward * 0.5f;
        Vector3 playerRotation = player.transform.rotation.eulerAngles;
        Vector3 tempRotation = new Vector3(0, 180f, 0f);
        Quaternion clownRotation = Quaternion.Euler(playerRotation.x + tempRotation.x, playerRotation.y + tempRotation.y, playerRotation.z + tempRotation.z);
        transform.rotation = clownRotation;
        transform.LookAt(player.transform.position, Vector3.up);
        laugh.Play();

        StartCoroutine(ScareEffects());


    }

    public IEnumerator ScareEffects()
    {
        //play scary noice
        //play animation
        yield return new WaitForSeconds(5f);
        transform.position = new Vector3(0f, -5f, 0f);
        RandomizeHowOftenScare();
    }
}
