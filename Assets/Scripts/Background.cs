using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    public float Speed = 0.1f;

    void Update()
    {
        // Time * 0.1 then repeat for y axis
        float y = Mathf.Repeat(Time.time * Speed, 1);

        // creating an offset vaule of y to shift smoothly
        Vector2 offset = new Vector2(0, y);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

}
