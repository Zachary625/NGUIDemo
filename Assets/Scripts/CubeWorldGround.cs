using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CubeWorldGround : MonoBehaviour {
    private GameObject _cubeAtomPrefab;
    private int _size = 0;
    public List<Material> OptionalMaterials = new List<Material>();
    public List<string> OptionalMaterialNames = new List<string>();
    private GameObject[, ,] _groundCubes;
    private Color _groundColor;
    private Material _groundMaterial;

    private delegate void _GroundAtomOperation(Vector3 coordinate);
    private GameObject this[Vector3 coordinate] {
        get {
            return this._groundCubes[(int)coordinate.x + this._size, 0, (int)coordinate.z + this._size];
        }
        set {
            this._groundCubes[(int)coordinate.x + this._size, 0, (int)coordinate.z + this._size] = value;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InitializeGround(int size, GameObject cubeAtomPrefab) {
        this._size = size;
        this._cubeAtomPrefab = cubeAtomPrefab;
        this._groundCubes = new GameObject[2 * size + 1, 1, 2 * size + 1];

        _GroundAtomOperation operation = (Vector3 coordinate) => {
            GameObject newGroundCube = Instantiate(this._cubeAtomPrefab);
            newGroundCube.transform.SetParent(this.transform);
            newGroundCube.transform.position = coordinate;
            this[coordinate] = newGroundCube;
        };
        this.StartCoroutine("_groundOperationCoroutine", operation);
    }

    private IEnumerator _groundOperationCoroutine(_GroundAtomOperation operation) {
        long timeCost_100ns = 0;
        long timeLimit_100ns = 30 * 10000;
        for (int x = -this._size; x <= this._size; x++)
        {
            for (int z = -this._size; z <= this._size; z++)
            {
                long tick = System.DateTime.Now.Ticks;
                operation(new Vector3(x, 0, z));
                long tock = System.DateTime.Now.Ticks;

                timeCost_100ns += (tock - tick);
                if (timeCost_100ns > timeLimit_100ns)
                {
                    timeCost_100ns = 0;
                    yield return 0;
                }
            }
        }
    }

    public void SetGroundColor() {
        if (UIColorPicker.current != null) {
            this._groundColor = UIColorPicker.current.value;
            _GroundAtomOperation operation = (Vector3 coordinate) => {
                GameObject cube = this[coordinate];
                if (cube != null) {
                    cube.SendMessage("SetCubeColor", this._groundColor, SendMessageOptions.RequireReceiver);
                }
            };
            this.StartCoroutine("_groundOperationCoroutine", operation);
        }
    }

    public void SetGroundMaterial() {
        if (UIPopupList.current != null) {
            this._groundMaterial = this.OptionalMaterials[this.OptionalMaterialNames.IndexOf(UIPopupList.current.value)];
            _GroundAtomOperation operation = (Vector3 coordinate) =>
            {
                GameObject cube = this[coordinate];
                if (cube != null) {
                    cube.SendMessage("SetCubeMaterial", this._groundMaterial, SendMessageOptions.RequireReceiver);
                }
            };
            this.StartCoroutine("_groundOperationCoroutine", operation);
        }
    }
}
