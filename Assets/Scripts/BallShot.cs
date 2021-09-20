using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    public GameObject normalBall;
    public GameObject changeBall;

    public float power;

    private float time;

    private float shotInterval = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        time = shotInterval;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= shotInterval)
        {
            var isLeftClick = Input.GetMouseButtonDown(0);
            var isRightClick = Input.GetMouseButtonDown(1);
            if (isLeftClick || isRightClick)
            {
                var ball = GameObject.Instantiate(isLeftClick ? normalBall: changeBall) as GameObject;
                ball.GetComponent<BallDelete>().IsChangeBall = isRightClick;
                ball.transform.position = transform.position;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var target = ray.direction;
                var rigidBody = ball.GetComponent<Rigidbody>();
                rigidBody.velocity = target * power;
                time = 0f;
            }
        }
    }
}
