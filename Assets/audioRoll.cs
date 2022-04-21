using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioRoll : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource roll;
    void Start()
    {
        roll = GameObject.FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        // if(col.gameObject.name=="Ball")
        // {
            roll.Play();
        // }
    }
}
