using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neck : MonoBehaviour {

    public Material frontPlane;

    // Use this for initialization
    void Start () {
        // Create the Plane
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        // Load the Image from somewhere on disk
        var filePath = "Assets/Resources/Textures/bg.jpg";
        if (System.IO.File.Exists(filePath))
        {
            // Image file exists - load bytes into texture
            var bytes = System.IO.File.ReadAllBytes(filePath);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(bytes);
            frontPlane.mainTexture = tex;

            // Apply to Plane
            MeshRenderer mr = plane.GetComponent<MeshRenderer>();
            mr.material = frontPlane;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
