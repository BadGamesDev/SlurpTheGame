using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text lifeCountText;

    public GameObject easyModeButton;
    public GameObject veryEasyModeButton;

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
    }
}
