using UnityEngine;
using System.Collections;

public class BossMovements : MonoBehaviour
{
    public float firstSpeed;
    public GameObject explosion;
    private Animator animator;
    public GameObject Core;
    public GameObject Defense;
    public GameObject Blasters;
    private float moveTime = 20.0f;
    public float sideSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Defense.GetComponent<BossDefense>().canHit == false)
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * firstSpeed * -1;
        }
        else if (Defense.GetComponent<BossDefense>().canHit == true)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * sideSpeed;
        }
        if (transform.position.x >= 3)
        {
            sideSpeed = -1;
        }
        if (transform.position.x <= -3)
        {
            sideSpeed = 1;
        }
        if (transform.position.y < 1.5)
        {
            Defense.GetComponent<BossDefense>().canHit = true;
        }
        if (Core.GetComponent<BossDefense>().hp <= 0)
        {
            // hide the boss //
            gameObject.SetActive(false);
        }
    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
