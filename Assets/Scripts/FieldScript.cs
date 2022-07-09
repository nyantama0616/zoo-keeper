using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour {
    public GameObject BlockPrefab;
    GameObject[,] field;
    const int H = 8;
    const int W = 8;
    // Vector3? selectedPos;
    // public SelectorScript selector;

    void setBlock() {
        field = new GameObject[H, W];
        float offsetX = 8f / W;
        float offsetY = 8f / H;
        for (int i = 0; i < H; i++) {
            for (int j = 0; j < W; j++) {
                float  x = -W + 2*j + offsetX;
                float  y = H  - 2*i - offsetY;
                field[i, j] = Instantiate(BlockPrefab, new Vector3(x, y, 0), transform.rotation);
                (int x, int y) p = (x: j, y: i);
                field[i, j].GetComponent<BlockScript>().Initialize(p);
            }
        }
    }
    
    void Start() {
        setBlock();
    }

    void Update() {

    }

    public void ChangeSelectorPos(Vector3? pos) {
        Debug.Log("Click! from FieldScript");
    }
}
