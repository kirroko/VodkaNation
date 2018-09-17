using System.Collections;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    // Wave prefab
    public GameObject[] waves;

    public float waveDelay;

    private int currentWave;

    private Manager manager;

    private Score score;

    private int waveCounter = 1;

    IEnumerator Start()
    {
        // Stop the coroutine if Wave prefab is 0
        if(waves.Length == 0)
        {
            yield break;
        }

        manager = FindObjectOfType<Manager>();

        while (true)
        {
            while(manager.IsPlaying() == false)
            {
                yield return new WaitForEndOfFrame();
            }

            // Updating the GUIText to show wave
            FindObjectOfType<Score>().AddWave(waveCounter);
            // Creates wave by instantiate
            GameObject g = (GameObject)Instantiate(waves[currentWave], transform.position, transform.rotation);
            // ^ wave to gameObject transform location.
            g.transform.parent = transform;
            // Check if enemy are all dead
            while (g.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }
            // Destroy wave after while loop
            Destroy(g);
            waveCounter++;
            // Go back to the beginning of the array(Wave element)
            // if waveArray has 2 element. 2 is lesser or equal then currentWave + 1
            
            // Loop back to wave 1

            if (waves.Length <= ++currentWave)
            {
                FindObjectOfType<Manager>().endGame = true;
            }

            yield return new WaitForSeconds(waveDelay);
            // While loop always remain true. 
            // gameobject G repersent the instantiation
            // While gameobject G has not all it's child (enemy inside the wave) dead, WaitForEndOfFrame. Loop again.
            // once all child in gameobject G is dead, Destroy gameobject(Wave with enemy)
            // the while loop goes back again.
        }
    }
}
