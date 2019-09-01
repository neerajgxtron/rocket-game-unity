using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {
    Rigidbody rigidbody;
    AudioSource audioSource;
    float rcsThrust = 100f;
    // Use this for initialization
    void Start ()
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
{ 
        
        Thrust();
        Rotate();

    }
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * 2);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true;
        
        float rotationSpeed = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.forward*rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        rigidbody.freezeRotation = false;
    }

    
}
