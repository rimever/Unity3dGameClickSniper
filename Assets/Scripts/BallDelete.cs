using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsChangeBall)
        {
            // 変化球
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.AddForce(new Vector3(100f, 0f, 0f));
        }

        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }

    public bool IsChangeBall { get; set; }
}