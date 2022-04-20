using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioStrike : MonoBehaviour
{

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {

        // source = GameObject.FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball")
        {
            // Debug.Log("play");
            // Debug.Log(col.gameObject.name);
            source = GameObject.FindObjectOfType<AudioSource>();
            source.Play();
        }
    }
}
