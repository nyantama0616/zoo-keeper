using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler {
    SpriteRenderer spriteRenderer;
    public Sprite[] animalSprites;
    private GameControllerScript gameController;
    public (int x, int y) p;
    static int[] x4 = {-1, 0, 1, 0};
    static int[] y4 = {0, 1, 0, -1};

    // 移動用変数
    bool isMoving = false;
    public float speed = 0.1f;
    Vector3 direction;
    Vector3 to;

    bool isNeighbor(BlockScript other) {
        Debug.Log(string.Format("me: {0}", p));
        Debug.Log(string.Format("other: {0}", other.p));
        for (int i = 0; i < 4; i++) {
            Debug.Log((this.p.x + BlockScript.x4[i], this.p.y + BlockScript.y4[i]));
            if (other.p.x == this.p.x + BlockScript.x4[i] && other.p.y == this.p.y + BlockScript.y4[i]) {
                return true;
            }
        }
        return false;
    }

    void move() {
        if (!isMoving) return;
        if (Mathf.Abs(transform.position.x - to.x) < speed && Mathf.Abs(transform.position.y - to.y) < speed) {
            isMoving = true;
            transform.position = to;
            return;
        }
        // Debug.Log("move");
        transform.position += direction * (speed);
        // Debug.Log(direction * (speed));
    }

    void Start() {
        gameController = GameObject
        .FindWithTag("GameController")
        .GetComponent<GameControllerScript>();

        int index = Random.Range(0, animalSprites.Length);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = animalSprites[index];
    }

    void Update() {
        move();
    }

    public void Initialize((int x, int y) point) {
        this.p = point;
    }

    public void Swap(BlockScript other) {
        MoveTo(other.transform.position);
        other.MoveTo(transform.position);
        (int x, int y) t = p;
        p = other.p;
        other.p = t;
    }

    public void MoveTo(Vector3 to) {
        // Debug.Log("MoveTo");
        isMoving = true;
        this.to = to;
        // direction = Vector3.zero;
        if (transform.position.y == to.y) {
            if (transform.position.x < to.x) {
                direction = new Vector3(1, 0, 0);
            } else {
                direction = new Vector3(-1, 0, 0);
            }
        } else {
            if (transform.position.y < to.y) {
                direction = new Vector3(0, 1, 0);
            } else {
                direction = new Vector3(0, -1, 0);
            }
        }

        // Debug.Log(direction);
        // Debug.Log(string.Format("me: {0}", transform.position));
        // Debug.Log(string.Format("to: {0}", to));
        // Debug.Log(direction);
        // Debug.Log(direction * 2f);
        // Debug.Log(direction * 0.1f);
    }
    
    // ドラッグ & ドロップ用
    public void OnBeginDrag(PointerEventData e) {
        // Debug.Log("begin");
    }
    public void OnDrag(PointerEventData e) {
        // Debug.Log("drag");

    }
    public void OnEndDrag(PointerEventData e) {
        // Debug.Log("end");
    }

    public void OnDrop(PointerEventData  e) {
        if (e.pointerDrag.gameObject.CompareTag("Block")) {
            BlockScript other = e.pointerDrag.gameObject.GetComponent<BlockScript>();
            Debug.Log("Drop!");
            // Debug.Log(this.p);
            // Debug.Log(other.p);
            // Debug.Log(GetInstanceID());
            if (isNeighbor(other)) {
                Debug.Log("Neighther!");
                Swap(other);
            }
        }
    }
}
