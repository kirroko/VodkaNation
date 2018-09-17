using UnityEngine;
using System.Collections;

public class PlasmaGunRight : MonoBehaviour {

    public GameObject bullet;
    public float TimeToShoot = 2.0f;

    private Quaternion startingRotation;
    private Quaternion target = Quaternion.Euler(0, 0, 125);

    void Start()
    {

        StartCoroutine(WaitAndShoot(TimeToShoot));

        startingRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(target, startingRotation, (Mathf.Cos(Time.time) + 1) * .5f);
    }

    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    private IEnumerator WaitAndShoot(float TimeToShoot)
    {
        while (true)
        {
            Transform shotPosition = transform.GetChild(0);
            Shot(shotPosition);
            yield return new WaitForSeconds(TimeToShoot);
        }
    }
}
