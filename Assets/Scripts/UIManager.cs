using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score_text;
    // Start is called before the first frame update
    void Start()
    {
        _score_text.text = "Score: " + 0;
    }


    public void UpdateScore(int Score)
    {
        _score_text.text = "Score: " + Score;
    }
}
