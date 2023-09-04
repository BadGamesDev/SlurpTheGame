using UnityEngine;
using System.Collections.Generic;
using Cinemachine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
    public UIManager uiManager;
    public CameraShake cameraShake;

    public GameObject playerPrefab;
    public GameObject defenderPrefab;

    public List<Defender> defenders; 
    public int targetDefenderCount;
    public float defenderRemainingCooldown;
    public float defenderCooldown;

    public long remainingLives;

    public bool gamePaused;

    public List<string> defenderNames = new List<string>
    {
        "Cndk99", "OneViolence", "Cobalt_Velvet", "Uber_Markus", "bigfishguy17", "AGiraffeTRH", "JackedRussell", "Digi63", "Rejid",
        "redzepper", "gold_comedy", "cadrethree", "itsAaMee", "GetBooped", "punknblack69", "pharophs", "Leofwine", "tictictoby", "Relaxitsjules", "JiveForceOne"
    };

    public List<string> deadDefenderNames = new List<string>
    {
        
    };

    private void Update()
    {
        uiManager.lifeCountText.text = "Slurps left:" + remainingLives.ToString();

        SpawnDefender();
    }

    public void RespawnPlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefab, new Vector2(0,-8), Quaternion.identity);
        newPlayer.name = "Player";
        GameObject.Find("PlayerCam").GetComponent<CinemachineVirtualCamera>().Follow = newPlayer.transform;
        defenderRemainingCooldown = 1.5f;
    }

    public void ActivateEasyMode()
    {
        targetDefenderCount = 2;
        defenderCooldown = 5;
    }

    public void ActivateVeryEasyMode()
    {
        targetDefenderCount = 4;
        defenderCooldown = 3.5f;
    }

    public void DonDonationEvent()
    {
        StartCoroutine(OpenDonStepsWithDelay());
    }

    public IEnumerator<UnityEngine.WaitForSeconds> OpenDonStepsWithDelay()
    {
        gamePaused = true;

        yield return new WaitForSeconds(2.0f); // Wait for 3 seconds before starting
        uiManager.OpenDonPt1();

        yield return new WaitForSeconds(4.5f); // Wait for 3 seconds
        uiManager.OpenDonPt2();
        audioManager.PlayTwitchAlert();

        yield return new WaitForSeconds(2.5f); // Wait for 3 seconds
        uiManager.OpenDonPt3();

        yield return new WaitForSeconds(3.0f); // Wait for 3 seconds
        uiManager.OpenDonPt4();
        audioManager.PlayJohnCena();


        yield return new WaitForSeconds(10.0f);
        uiManager.CloseDons();

        remainingLives += 100000000000000;
        uiManager.easyModeButton.SetActive(true);

        gamePaused = false;
    }

    public void SpawnDefender()
    {
        if (defenders.Count < targetDefenderCount)
        {
            defenderRemainingCooldown -= Time.deltaTime;

            if (defenderRemainingCooldown <= 0)
            {
                List<float> availablePlacements = new List<float> { 1.5f, -1.5f, 3.0f, -3.0f };

                foreach (Defender defender in defenders)
                {
                    if (availablePlacements.Contains(defender.placement))
                    {
                        availablePlacements.Remove(defender.placement);
                    }
                }
                
                GameObject newDefender = Instantiate(defenderPrefab, new Vector2(0, 0), Quaternion.identity);
                Defender defenderScript = newDefender.GetComponent<Defender>();
                defenderScript.placement = availablePlacements[0];
                
                if (defenderScript.placement < 0)
                {
                    newDefender.GetComponent<SpriteRenderer>().flipX = true;
                }
                
                string newName = defenderNames[Random.Range(0, defenderNames.Count - 1)];
                defenderScript.defenderName = newName;
                newDefender.GetComponentInChildren<TMP_Text>().text = newName;
                
                if (deadDefenderNames.Contains(newName))
                {
                    newDefender.GetComponent<SpriteRenderer>().sprite = defenderScript.defenderSprites[1];
                }

                defenderNames.Remove(newName);
                defenders.Add(defenderScript);

                defenderRemainingCooldown = defenderCooldown;
            }
        }
    }
}
