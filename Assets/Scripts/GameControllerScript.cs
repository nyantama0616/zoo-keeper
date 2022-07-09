using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {
    public YouScript you;
    public FieldScript field;
    public Vector2 p;
    void Start() {
        Instantiate(you, Vector3.zero, transform.rotation);
        Instantiate(field, Vector3.zero, transform.rotation);
    }

    void Update() {
        
    }

    public void ChangeSelectorPos(Vector3? pos) {
        field.ChangeSelectorPos(pos);
        Debug.Log("Click! from GameControllerScript");
    }
}
