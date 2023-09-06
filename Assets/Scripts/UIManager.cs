using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    public TMP_Text lifeCountText;

    public GameObject easyModeButton;
    public GameObject veryEasyModeButton;
    public GameObject extremelyEasyModeButton;

    public GameObject surveyPt1;
    public GameObject surveyPt2;
    public GameObject surveyPt3;
    public GameObject surveyPt4;
    public GameObject surveyPt5;
    public GameObject surveyPt6;

    public GameObject donPt1;
    public GameObject donPt2;
    public GameObject donPt3;
    public GameObject donPt4;

    public GameObject finalPanel;

    public TMP_Text donPt4Text;

    public GameObject veryEasy;
    public GameObject extremelyEasy;

    public TMP_Text wrongInputWarning;

    public TMP_InputField inputField;

    public bool wobble;

    public void Start()
    {
        inputField.onEndEdit.AddListener(HandleInputValueChanged);
    }

    public void Update()
    {
        if (wobble)
        {
            WobbleText();
        }
    }

    public void OpenSurveyPt1()
    {
        surveyPt1.SetActive(true);
    }

    public void OpenSurveyPt2()
    {
        surveyPt2.SetActive(true);
    }

    public void OpenSurveyPt3()
    {
        surveyPt3.SetActive(true);
    }

    public void OpenSurveyPt4()
    {
        surveyPt4.SetActive(true);
    }

    public void OpenSurveyPt5()
    {
        surveyPt5.SetActive(true);
    }

    public void OpenSurveyPt6()
    {
        surveyPt6.SetActive(true);
    }

    public void OpenDonPt1()
    {
        donPt1.SetActive(true);
    }
    
    public void OpenDonPt2()
    {
        donPt2.SetActive(true);
    }
    
    public void OpenDonPt3()
    {
        donPt3.SetActive(true);
    }
    
    public void OpenDonPt4()
    {
        donPt4.SetActive(true);
        wobble = true;
    }

    public void OpenVeryEasyMessage()
    {
        veryEasy.SetActive(true); 
    }

    public void CloseVeryEasyMessage()
    {
        gameManager.ActivateVeryEasyMode();
        veryEasy.SetActive(false);
        veryEasyModeButton.SetActive(false);
        extremelyEasyModeButton.SetActive(true);
    }

    public void OpenExtremelyEasy()
    {
        extremelyEasy.SetActive(true);
    }

    public void CloseExtremelyEasyMessage()
    {
        gameManager.ActivateExtremelyEasyMode();
        extremelyEasyModeButton.SetActive(false);
        extremelyEasy.SetActive(false);
    }

    public void CloseSurveys()
    {
        surveyPt1.SetActive(false);
        surveyPt2.SetActive(false);
        surveyPt3.SetActive(false);
        surveyPt4.SetActive(false);
        surveyPt5.SetActive(false);
        surveyPt6.SetActive(false);
    }

    public void CloseDons()
    {
        donPt1.SetActive(false);
        donPt2.SetActive(false);
        donPt3.SetActive(false);
        donPt4.SetActive(false);
        wobble = false;
    }

    public void HandleInputValueChanged(string newValue)
    {
        if (newValue.ToLower() == "i am a big baby and i need help")
        {
            easyModeButton.SetActive(false);
            veryEasyModeButton.SetActive(true);
            CloseSurveys();
            gameManager.ActivateEasyMode();
        }
        else
        {
            wrongInputWarning.gameObject.SetActive(true);
        }
    }

    public void WobbleText()
    {
        donPt4Text.ForceMeshUpdate();
        var textInfo = donPt4Text.textInfo;

        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
            }

            Color newColor = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));

            var colors = textInfo.meshInfo[charInfo.materialReferenceIndex].colors32;
            for (int j = 0; j < 4; ++j)
            {
                colors[charInfo.vertexIndex + j] = newColor;
            }

            for (int x = 0; x < textInfo.meshInfo.Length; ++x)
            {
                var meshInfo = textInfo.meshInfo[x];
                meshInfo.mesh.vertices = meshInfo.vertices;

                meshInfo.mesh.colors32 = colors;

                donPt4Text.UpdateGeometry(meshInfo.mesh, x);
            }
        }
    }

    public void NeverGonnagiveYouUp()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley");
    }
}
