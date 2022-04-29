using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in the Inspector")]
    public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge;

    public float chanceToChangeDirection = 0.1f;

    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DroppApple", 2f);
    }

    void DroppApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DroppApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        float edge = Camera.main.ViewportToWorldPoint(Vector3.right).x - 2;

        if (pos.x < -edge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > edge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
    }
}
