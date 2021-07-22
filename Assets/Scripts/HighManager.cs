using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighManager : MonoBehaviour
{
    public Text HighText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.LoadScores();
        HighText.text = ScoreManager.Instance.ScoreTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
