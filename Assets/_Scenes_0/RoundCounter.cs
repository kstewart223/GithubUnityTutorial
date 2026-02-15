using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    
    [Header("Dynamic")]
    public Text round;
    public int round_num  = 1; 
    
    // Start is called before the first frame update
    void Start()
    {
        round = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        round.text = "Round: " + round_num;
        if (round_num > 4) {
            ChangeText();
        }
    }

    public void ChangeText() {
        round.text = "Game Over";
    }

}
