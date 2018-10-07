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

    string[] file_content;
    string song_name = "Eye-of-the-Tiger";
    public static string[] notes_and_rythm;
    public static int[] notes;
    public static float[] notes_rythm;
    float note_time;
    public static float bpm;
    public static int note_counter;
    AudioClip song;
    AudioSource song_player;
    float timeDiff;
    static int currentNote = 0;
    public static bool play_enabled = false;

    void Start () {

        string[] temp;

        file_content = Load_song("Assets/songs/" + song_name + ".txt");

        notes_and_rythm = file_content[0].Split(' ');
        notes = new int[notes_and_rythm.Length];
        notes_rythm = new float[notes_and_rythm.Length];

        for (int i = 0; i<notes_and_rythm.Length; i++)
        {
            temp = notes_and_rythm[i].Split(';');
            notes[i] = int.Parse(temp[0]);
            notes_rythm[i] = float.Parse(temp[1]);
        }
        bpm = Int32.Parse(file_content[1]);

        song_player = gameObject.AddComponent<AudioSource>();

        Debug.Log("Reading resource: " + song_name);
        song = Resources.Load<AudioClip>(song_name);

        Debug.Log((song== null) ? "song is null" : "song is not null");

        song_player.clip = song;
        song_player.PlayDelayed(2);

        // Generate 1st note
        
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
        note_time = notes_rythm[currentNote] * 60 / bpm;
        currentNote++;
        play_enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        timeDiff += Time.deltaTime;
        if (timeDiff >= note_time && play_enabled)
        {
            timeDiff = 0;
            Generate();
        }
        
	}

    void Generate()
    {
        if (currentNote >= notes_and_rythm.Length - 1)
        {
            Debug.Log("End of notes.");
            play_enabled = false;
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
        note_time = notes_rythm[currentNote] * 60 / bpm;
        currentNote++;
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
