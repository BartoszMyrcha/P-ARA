using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class GenerateNote : MonoBehaviour {

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

    string[] file_content;
    string song_name = "song1";
    public static int[] notes;
    public static int bps;
    public static int note_counter;

    int currentNote = 0;

    //int[] notes = { 4, 1, 4, 3, 2, 2, 2, 2, 1, 1, 2, 3, 4, 1};

    // Use this for initialization
    void Start () {

        file_content = Load_song("songs/" + song_name + ".txt");

        //This worked in VB:
        notes = Array.ConvertAll<string, int>(file_content[0].Split(' '), int.Parse);
        bps = Int32.Parse(file_content[1]);

        switch (notes[0])
        {
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
        if (collider.gameObject.CompareTag("Note"))
        {
            if (notes.Length <= currentNote)
            {
                Destroy(noteGenerator);
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
            Debug.Log(currentNote);
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
