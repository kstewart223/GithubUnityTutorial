using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    
    public ScoreCounter scoreCounter;
    public RoundCounter roundCounter;

    // Start is called before the first frame update
    void Start()
    {
      GameObject scoreGO = GameObject.Find("ScoreCounter");
      scoreCounter = scoreGO.GetComponent<ScoreCounter>();
      GameObject roundGO = GameObject.Find("RoundCounter");
      roundCounter = roundGO.GetComponent<RoundCounter>(); 
    }

    // Update is called once per frame
    void Update() {
        //pos of mouse
        Vector3 mousePos2D = Input.mousePosition;
        // camera z pos
        mousePos2D.z = -Camera.main.transform.position.z;
        // 2d point -> 3d point
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        // Move basket with mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;        
    }
    
    void OnCollisionEnter(Collision coll) {
        // find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); 
        if (collidedWith.CompareTag("Apple")) {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        } else if (collidedWith.CompareTag("Poision")) {
            Destroy(collidedWith);
            apScript.AppleMissed();
            roundCounter.round_num = 5; 
            
        }
    } 
}
