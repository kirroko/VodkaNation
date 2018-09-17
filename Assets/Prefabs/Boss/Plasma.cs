using UnityEngine;
using System.Collections;

public class Plasma : MonoBehaviour
    {

    public int speed = 10;

    public float lifeTime = 5f;

    public int power = 1;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed * -1;
    }

    void Update()
    {

    }
}
