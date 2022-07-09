using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropAreaScript : MonoBehaviour, IDropHandler {
    void Start() {
        
    }

    void Update() {
        
    }

    public void OnDrop(PointerEventData  e) {
        if (e.pointerDrag != null) {
            Debug.Log(e.pointerDrag.gameObject.name);
            e.pointerDrag.gameObject.transform.position = this.transform.position;
        }
    }
}
