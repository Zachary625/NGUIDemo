using UnityEngine;
using System.Collections;

public class CubeGod : MonoBehaviour {
    public int WorldSize = 50;
    public GameObject WorldTreeRoot;
    public GameObject CubePrefab;

	// Use this for initialization
	void Start () {
        this.StartCoroutine("_createGround");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator _createGround() {
        long timeCost_100ns = 0;
        long timeLimit_100ns = 40 * 10000;
        CubeWorldGround ground = WorldTreeRoot.transform.FindChild("Ground").GetComponent<CubeWorldGround>();
        for (int x = -this.WorldSize; x <= this.WorldSize; x++)
        {
            for (int z = -this.WorldSize; z <= this.WorldSize; z++)
            {
                long tick = System.DateTime.Now.Ticks;
                GameObject newGroundCube = Instantiate(CubePrefab);
                newGroundCube.transform.SetParent(ground.transform);
                newGroundCube.transform.position = new Vector3(x, 0, z);
                long tock = System.DateTime.Now.Ticks;

                timeCost_100ns += (tock - tick);
                if (timeCost_100ns > timeLimit_100ns) {
                    timeCost_100ns = 0;
                    yield return 0;
                }
            }
        }
    }
}
