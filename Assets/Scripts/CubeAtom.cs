using UnityEngine;
using System.Collections;

public class CubeAtom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetCubeColor(Color c)
    {
        this.GetComponent<MeshRenderer>().material.color = c;
    }

    public void SetCubeMaterial(Material m) {
        this.GetComponent<MeshRenderer>().material = m;
    }
}
