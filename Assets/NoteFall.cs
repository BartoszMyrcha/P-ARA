using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFall : MonoBehaviour {
    Rigidbody2D note;
	// Use this for initialization
	void Start () {
        note = GetComponent<Rigidbody2D>();
        note.velocity = new Vector3(0, -5, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
