using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{


    void onAnimationFinish()
    {
        Destroy(gameObject);
    }
	
}
