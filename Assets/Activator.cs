using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    Renderer cr;
    public KeyCode key;
    public static bool active;
    GameObject note;

    void Awake()
    {
        cr = GetComponent<Renderer>();
        PlayerPrefs.SetInt("Points", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            StartCoroutine(Pressed());
            if (active)
            {
                Destroy(note);
                AddPoint();
                active = false;
            }
            else
            {
                SubPoint();
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("OnTriggerEnter");
        active = true;
        if (col.gameObject.tag == "Note")
        {
            note = col.gameObject;
        }

    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("OnTriggerExit");
        SubPoint();
        active = false;
    }

    void AddPoint()
    {
        PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") + 1);
        Debug.Log("Score: " + PlayerPrefs.GetInt("Points"));
    }

    void SubPoint()
    {
        if (PlayerPrefs.GetInt("Points") > 0)
        {
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") - 1);
        }
        Debug.Log("Score: " + PlayerPrefs.GetInt("Points"));
    }
    IEnumerator Pressed()
    {
        Color old = cr.material.color;
        cr.material.color = new Color(0, 255, 0);
        yield return new WaitForSeconds(0.05f);
        cr.material.color = old;
    }
}
