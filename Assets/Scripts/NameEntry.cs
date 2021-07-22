using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NameEntry : MonoBehaviour
{
    TMP_InputField nameinput;
    // Start is called before the first frame update
    void Start()
    {
        nameinput = GetComponent<TMP_InputField>();
        nameinput.onEndEdit.AddListener(ChangeName);
        ScoreManager.Instance.Name("(no name)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeName(string namein)
    {
        ScoreManager.Instance.Name(namein);
    }
}
