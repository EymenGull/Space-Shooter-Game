using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score_text;
    [SerializeField]
    private Image _lives;
    [SerializeField]
    private Sprite[] _lives_sprite;
    [SerializeField]
    private Text _game_over;
    // Start is called before the first frame update
    void Start()
    {
        _score_text.text = "Score: " + 0;
    }


    public void UpdateScore(int Score)
    {
        _score_text.text = "Score: " + Score;
    }

    public void UpdateLives(int live)
    {
        _lives.sprite = _lives_sprite[live];
    }
    public void GameOver()
    {
        _game_over.gameObject.SetActive(true);
    }
}
