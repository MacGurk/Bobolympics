using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHazard : MonoBehaviour
{
    [SerializeField]
    private Vector2 startPosition;
    [SerializeField]
    private Vector2 endPosition;
    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private Vector2 newVeolicity;
    private bool directionRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(startPosition, endPosition, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
