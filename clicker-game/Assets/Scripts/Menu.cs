using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{    
    public GameObject panel01;
    public GameObject panel02;
    public GameObject panel03;
    public GameObject panel04;
    public GameObject panel05;
    public GameObject panel06;
    public Text input;
    public Text profile01;
    public Text profile02;
    public Text profile03;
    public Text selectedProfile;

    void Start(){
        //PlayerPrefs.DeleteAll();
        Debug.Log("data 1: "+PlayerPrefs.GetString("jsonGameData1"));
        Debug.Log("data 2: "+PlayerPrefs.GetString("jsonGameData2"));
        Debug.Log("data 3: "+PlayerPrefs.GetString("jsonGameData3"));
             

        OpenPanel01();

        if (PlayerPrefs.GetString("profile01") != ""){
            profile01.text = PlayerPrefs.GetString("profile01");
        }
        if (PlayerPrefs.GetString("profile02") != "") {
            profile02.text = PlayerPrefs.GetString("profile02");
        }
        if (PlayerPrefs.GetString("profile03") != "")
        {
            profile03.text = PlayerPrefs.GetString("profile03");
        }        
    }

    public void OpenPanel01() {
        panel01.SetActive(true);
        panel02.SetActive(false);
        panel03.SetActive(false);
        panel04.SetActive(false);
        panel05.SetActive(false);
        panel06.SetActive(false);
    }

        public void OpenPanel02(){
        panel01.SetActive(false);
        panel02.SetActive(true);
        panel03.SetActive(false);
        panel04.SetActive(false);
        panel05.SetActive(false);
        panel06.SetActive(false);
    }

    public void SaveProfilePanel02(){
        panel01.SetActive(true);
        panel02.SetActive(false);
        panel03.SetActive(false);
        panel04.SetActive(false);
        panel05.SetActive(false);
        panel06.SetActive(false);
        //--------
        if (PlayerPrefs.GetString("profile01") == ""){
            PlayerPrefs.SetString("profile01", input.text);
            profile01.text = PlayerPrefs.GetString("profile01");
        } else if (PlayerPrefs.GetString("profile02") == ""){
            PlayerPrefs.SetString("profile02", input.text);
            profile02.text = PlayerPrefs.GetString("profile02");
        }
        else if (PlayerPrefs.GetString("profile03") == ""){
            PlayerPrefs.SetString("profile03", input.text);
            profile03.text = PlayerPrefs.GetString("profile03");
        }
        else {
            OpenPanel06();
        }
    }

    public void OpenPanel03(){
        panel01.SetActive(false);
        panel02.SetActive(false);
        panel03.SetActive(true);
        panel04.SetActive(false);
        panel05.SetActive(false);
        panel06.SetActive(false);
    }
    public void OpenPanel04()
    {
        panel01.SetActive(false);
        panel02.SetActive(false);
        panel03.SetActive(false);
        panel04.SetActive(true);
        panel05.SetActive(false);
        panel06.SetActive(false);
    }
    public void OpenPanel06()
    {
        panel01.SetActive(false);
        panel02.SetActive(false);
        panel03.SetActive(false);
        panel04.SetActive(false);
        panel05.SetActive(false);
        panel06.SetActive(true);
    }

    public void LoadProfile(int num) {
        //load profile and redirect to player city scene
        Debug.Log("profile loaded: " + num);
        PlayerPrefs.SetInt("currentProfile", num);
        switch (PlayerPrefs.GetInt("currentProfile")) {
            case 1:
                selectedProfile.text = PlayerPrefs.GetString("profile01");
                if (PlayerPrefs.GetString("profile01") == ""){
                    OpenPanel02();
                }
                else{
                    OpenPanel04();
                }
                break;
            case 2:
                selectedProfile.text = PlayerPrefs.GetString("profile02");
                if (PlayerPrefs.GetString("profile02") == ""){                    
                    OpenPanel02();
                }
                else{
                    OpenPanel04();
                }
                break;
            case 3:
                selectedProfile.text = PlayerPrefs.GetString("profile03");
                // Debug.Log("data 3: "+PlayerPrefs.GetString("jsonGameData3"));

                if (PlayerPrefs.GetString("profile03") == "")
                {
                    Debug.Log(PlayerPrefs.GetString("profile03"));
                    OpenPanel02();
                }
                else {
                    OpenPanel04();
                 }

                break;            
        }

    }

    public void DelProfilePanel() {
        panel01.SetActive(false);
        panel02.SetActive(false);
        panel03.SetActive(false);
        panel04.SetActive(false);
        panel05.SetActive(true);
        panel06.SetActive(false);
    }

    public void DeleteProfile()
    {
        
        switch (PlayerPrefs.GetInt("currentProfile"))
        {
            case 1:
                PlayerPrefs.DeleteKey("profile01");
                profile01.text = "Empty";
                break;
            case 2:
                PlayerPrefs.DeleteKey("profile02");
                profile02.text = "Empty";
                break;
            case 3:
                PlayerPrefs.DeleteKey("profile03");
                profile03.text = "Empty";
                break;
        }
        PlayerPrefs.DeleteKey("currentProfile");
        OpenPanel01();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
