using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

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
        }
    }

    void OnTriggerEnter(Collider col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
            note = col.gameObject;
    }

    private void OnTriggerExit(Collider col)
    {
        active = false;
    }

    void AddPoint()
    {
        PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") + 1);
    }

    IEnumerator Pressed()
    {
        Color old = cr.material.color;
        cr.material.color = new Color(0, 255, 0);
        yield return new WaitForSeconds(0.05f);
        cr.material.color = old;
    }
}
