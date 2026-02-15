using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivity : MonoBehaviour
{    
public Button button;
public RoundCounter roundCounter;

void Start() {
    GameObject roundGO = GameObject.Find("RoundCounter");
    roundCounter = roundGO.GetComponent<RoundCounter>();
}   
    
    public void Update() {

        if(roundCounter.round_num > 4) {
            button.gameObject.SetActive(true);
        } else if (roundCounter.round_num <=4) {
            button.gameObject.SetActive(false);
        }
    }

}
