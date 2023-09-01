using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject defenderPrefab;

    public int deathCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateEasyMode();
        }
    }

    public void RespawnPlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefab, new Vector2(0,0), Quaternion.identity);
        newPlayer.name = "Player";
        GameObject.Find("PlayerCam").GetComponent<CinemachineVirtualCamera>().Follow = newPlayer.transform;

    }

    public void ActivateEasyMode()
    {
        GameObject newDefender = Instantiate(defenderPrefab, new Vector2(0,0), Quaternion.identity);
    }
}
