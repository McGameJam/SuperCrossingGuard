﻿using UnityEngine;
using System.Collections;

public class ChracterController : MonoBehaviour {

    public float maxspeed = 3f;
    bool facingright = true;
    bool facingleft = false;
    Animator anim;
    float zPos;
    public float points = 0;
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
		zPos = transform.position.z;
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
       


    }


    void FixedUpdate() {

        float move = Input.GetAxis("Vertical");
        float movee = Input.GetAxis("Horizontal");

        anim.SetFloat("speedforward", Mathf.Abs(move));
        anim.SetFloat("speedright", Mathf.Abs(movee));


        Debug.Log(Mathf.Abs(move));

        if (move != 0)
        {

        }
        else if (movee != 0)
        {

        }

        GetComponent<Rigidbody>().velocity = new Vector3(movee * maxspeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);

        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, move * maxspeed);

        if (movee < 0 && facingright)
        {
            flip();

        }
        else if (movee > 0 && !facingright)
        {
            flip();

        }

        points = transform.position.z - zPos;



    }

    void flip()
    {
        facingright = !facingright;
        Vector3 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale; 
       
    }

	void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.tag == "Wire"){
           // Destroy(coll.gameObject); 
           audioSource.Play();
        }  
    }
}
