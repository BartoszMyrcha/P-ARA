﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNote : MonoBehaviour
{
    [SerializeField]
    GameObject note;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Reset"))
        {
            Destroy(note);
        }
    }
}