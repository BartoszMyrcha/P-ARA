using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class GenerateNote : MonoBehaviour {

    [SerializeField]
    GameObject emptyNote;
    [SerializeField]
    GameObject noteOne;
    [SerializeField]
    GameObject noteTwo;
    [SerializeField]
    GameObject noteThree;
    [SerializeField]
    GameObject noteFour;
    [SerializeField]
    GameObject noteGenerator;
    [SerializeField]
    GameObject nextNoteTrigger;

    string[] file_content;
    string song_name = "Eye-of-the-Tiger_v3";
    public static int[] notes;
    public static float bpm;
    public static int note_counter;
    float[] time = new float[100];
    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

    int currentNote = 0;

    // Use this for initialization
    void Start () {

        file_content = Load_song("songs/" + song_name + ".txt");

        notes = Array.ConvertAll<string, int>(file_content[0].Split(' '), int.Parse);
        bpm = Int32.Parse(file_content[1]);

        nextNoteTrigger = GameObject.FindGameObjectsWithTag("NextNote")[0];

        //float posDiff = -0.034f*bpm + 5.9844f;
        float posDiff = 248f / bpm;
        //float posDiff = 0.0004f * bpm * bpm - 0.1042f * bpm + 8.9774f;
        Vector3 noteTriggerVector = new Vector3(0, 6.3f - posDiff, 0);
        Debug.Log(noteTriggerVector);
        nextNoteTrigger.transform.position = noteTriggerVector;
        stopwatch.Start();

        switch (notes[0])
        {
            case 0:
                Instantiate(emptyNote);
                break;
            case 1: 
                Instantiate(noteOne);
                break;
            case 2:
                Instantiate(noteTwo);
                break;
            case 3:
                Instantiate(noteThree);
                break;
            case 4:
                Instantiate(noteFour);
                break;
        }
        currentNote++;
    }
	
	// Update is called once per frame
	void Update () {
		
        
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Note") || collider.gameObject.CompareTag("emptyNote"))
        {
            time[currentNote] = stopwatch.ElapsedMilliseconds;
            if (currentNote > 2) Debug.Log(time[currentNote] - time[currentNote - 1]);

            if (notes.Length <= currentNote)
            {
                Destroy(noteGenerator);
            }
            else if (notes[currentNote] == 0)
            {
                Instantiate(emptyNote);
            }
            else if (notes[currentNote] == 1)
            {
                Instantiate(noteOne);
            }
            else if(notes[currentNote] == 2)
            {
                Instantiate(noteTwo);
            }
            else if (notes[currentNote] == 3)
            {
                Instantiate(noteThree);
            }
            else if (notes[currentNote] == 4)
            {
                Instantiate(noteFour);
            }
            //Debug.Log(currentNote);
            currentNote++;
        }
    }

    public string[] Load_song(string fileName)
    {
        try
        {
            string[] file = new string[2];
            string line;
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            using (theReader)
            {
                int iterator = 0;
                do
                {
                    line = theReader.ReadLine();

                    if (line != null)
                    {
                        file[iterator] = line;
                    }
                    ++iterator;
                }
                while (line != null);
                theReader.Close();
                return file;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            return null;
        }
    }
}
