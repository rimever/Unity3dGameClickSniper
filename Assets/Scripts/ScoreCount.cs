using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public int score = 0;

    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = $"SCORE:{score}";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ScorePoint"))
        {
            Destroy(collision.gameObject);
            score++;
        }

        if (collision.gameObject.CompareTag("Delete"))
        {
            Destroy(collision.gameObject);
        }
    }
}
