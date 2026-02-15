using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject poisionPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 2f;
    public float poisionDropDelay = 2f;
    public RoundCounter roundCounter; 

    
    void Start () {
        GameObject roundGO = GameObject.Find("RoundCounter");
        roundCounter = roundGO.GetComponent<RoundCounter>();
        Invoke("DropApple", 2f);
        Invoke("DropPoision", 2f);
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
        
    }

    void DropPoision() {
        GameObject poision = Instantiate<GameObject>(poisionPrefab);
        poision.transform.position = transform.position;
        Invoke("DropPoision", poisionDropDelay);
    }

    void Update () {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); 
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); 
        }
        if(roundCounter.round_num > 4) {
            StopApples();
            StopPoision();
        }
    }

    void FixedUpdate () { 
    if (Random.value < changeDirChance) {
        speed *= -1; 
    }
    }

    public void StopApples () {
            CancelInvoke("DropApple");
    }

    public void StopPoision () {
            CancelInvoke("DropPoision");
    }

}
