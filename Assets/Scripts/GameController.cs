using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject Enemy;
    public Text textStartLose;

    public int pickUpCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public static bool life;


    void Start ()
    {
        StartCoroutine(SpawnPickUp());
        textStartLose.text = "GO";
        life = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!life)
        {
            textStartLose.text = "LOSE";
            StartCoroutine(Restart());
        }

	}


    IEnumerator SpawnPickUp()
    {
        yield return new WaitForSeconds(startWait);
        textStartLose.text = "";
        while (true)
        {
            for (int i = 0; i < pickUpCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(PlayerController.positionPlayer.x - 4, PlayerController.positionPlayer.x + 4), Random.Range(PlayerController.positionPlayer.y - 6, PlayerController.positionPlayer.y + 6), 0.0f);

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    IEnumerator Restart()
    {
            yield return new WaitForSeconds(startWait);
            SceneManager.LoadScene("PlayScene");
    }
}
