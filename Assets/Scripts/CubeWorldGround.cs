using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CubeWorldGround : MonoBehaviour {
    public List<Material> OptionalMaterials = new List<Material>();
    public List<string> OptionalMaterialNames = new List<string>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetGroundColor() {
        if (UIColorPicker.current != null) {
            for (int i = 0; i < this.transform.childCount; i++) {
                this.transform.GetChild(i).SendMessage("SetCubeColor", UIColorPicker.current.value, SendMessageOptions.RequireReceiver);
            }
        }
    }

    public void SetGroundMaterial() {
        if (UIPopupList.current != null) {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).SendMessage("SetCubeMaterial", this.OptionalMaterials[this.OptionalMaterialNames.IndexOf(UIPopupList.current.value)], SendMessageOptions.RequireReceiver);
            }
        }
    }
}
