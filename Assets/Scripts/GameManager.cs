using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetArray;

    private float time;

    private int count;

    public Text timeUp;

    private float lastTime = 8f;

    public GameObject retryButton;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        retryButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (count == targetArray.Length)
        {
            lastTime -= Time.deltaTime;
            if (lastTime <= 0)
            {
                timeUp.text = "TIME UP";
                GetComponent<BallShot>().enabled = false;
                retryButton.SetActive(true);
            }
        }
        else
        {
            time -= Time.deltaTime;
            if (time <= 0f)
            {
                var vectorY = Random.Range(0, 12);
                Instantiate(targetArray[count], new Vector3(-40, vectorY, 30), Quaternion.identity);
                time = 5f;
                count++;
            }
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}