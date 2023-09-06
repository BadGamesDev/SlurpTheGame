using UnityEngine;
using System.Collections.Generic;
using Cinemachine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
    public UIManager uiManager;

    public GameObject playerPrefab;
    public GameObject defenderPrefab;

    public List<Defender> defenders; 
    public int targetDefenderCount;
    public float defenderRemainingCooldown;
    public float defenderCooldown;

    public long remainingLives;

    public bool gamePaused;

    public int defenderBonusHP;
    public float defenderBonusSize;

    public List<string> defenderNames = new List<string>
    {
        "Cndk99", "OneViolence", "Cobalt_Velvet", "Uber_Markus", "bigfishguy17",
        "AGiraffeTRH", "JackedRussell", "Digi63", "Rejid", "redzepper",
        "gold_comedy", "cadrethree", "itsAaMee", "GetBooped", "punknblack69",
        "pharophs", "Leofwine", "tictictoby", "Relaxitsjules", "JiveForceOne",
        "ANT3_CLIMACUS", "Kirbomas1",
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
        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector2(0, -8);

        defenderRemainingCooldown = 1.5f;
    }

    public void ActivateEasyMode()
    {
        targetDefenderCount = 2;
        defenderCooldown = 4.5f;
    }

    public void ActivateVeryEasyMode()
    {
        targetDefenderCount = 4;
        defenderCooldown = 3.0f;
    }

    public void ActivateExtremelyEasyMode()
    {
        targetDefenderCount = 4;
        defenderCooldown = 3.0f;
        defenderBonusHP = 5;
        defenderBonusSize = 1.0f;

        foreach (Defender defender in defenders)
        {
            defenderNames.Add(defender.defenderName);
            Destroy(defender.gameObject);
        }

        defenders.Clear();
    }

    public void DonDonationEvent()
    {
        StartCoroutine(OpenDonStepsWithDelay());
    }

    public IEnumerator<UnityEngine.WaitForSeconds> OpenDonStepsWithDelay()
    {
        gamePaused = true;
        audioManager.PauseUltimateShowdown();
        audioManager.PlayRecordScratch();

        yield return new WaitForSeconds(2.0f);
        uiManager.OpenDonPt1();

        yield return new WaitForSeconds(4.5f);
        uiManager.OpenDonPt2();
        audioManager.PlayTwitchAlert();

        yield return new WaitForSeconds(2.5f);
        uiManager.OpenDonPt3();

        yield return new WaitForSeconds(3.0f);
        uiManager.OpenDonPt4();
        audioManager.PlayJohnCena();


        yield return new WaitForSeconds(10.0f);
        uiManager.CloseDons();

        remainingLives += 100000000000000;
        uiManager.easyModeButton.SetActive(true);

        gamePaused = false;
        yield return new WaitForSeconds(2.0f);
        audioManager.PlayUltimateShowdown();
    }

    public void SpawnDefender()
    {
        if (defenders.Count < targetDefenderCount)
        {
            defenderRemainingCooldown -= Time.deltaTime;

            if (defenderRemainingCooldown <= 0)
            {
                List<float> availablePlacements = new List<float> { 1.5f, -1.5f, 3.0f, -3.0f };

                if (defenderBonusSize != 0)
                {
                    availablePlacements = new List<float> { 1.5f + defenderBonusSize, -1.5f - defenderBonusSize, 3.0f + defenderBonusSize * 2, -3.0f - defenderBonusSize * 2};
                }
                
                foreach (Defender defender in defenders)
                {
                    if (availablePlacements.Contains(defender.placement))
                    {
                        availablePlacements.Remove(defender.placement);
                    }
                }
                
                GameObject newDefender = Instantiate(defenderPrefab, new Vector2(0, 0), Quaternion.identity);
                newDefender.transform.localScale = newDefender.transform.localScale * (1 + defenderBonusSize);
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
