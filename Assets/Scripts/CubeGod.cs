using UnityEngine;
using System.Collections;

public class CubeGod : MonoBehaviour {
    public int WorldSize = 20;
    public GameObject WorldTreeRoot;
    public GameObject CubePrefab;

	// Use this for initialization
	void Start () {
        CubeWorldGround ground = WorldTreeRoot.transform.FindChild("Ground").GetComponent<CubeWorldGround>();
        ground.InitializeGround(this.WorldSize, this.CubePrefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
