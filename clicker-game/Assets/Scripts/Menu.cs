using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    
    public GameObject panel01;
    public GameObject panel02;
    public GameObject panel03;
    public Text input;

    void Start()
    {
       
        panel01.SetActive(false);
        panel02.SetActive(false);
        panel03.SetActive(false);
        OpenPanel01();
        //var input = gameObject.GetComponent<InputField>();
    }

    public void OpenPanel01() {

        
        panel01.SetActive(true);
        panel02.SetActive(false);
        panel03.SetActive(false);
    }

        public void OpenPanel02()
    {
       
        panel01.SetActive(false);
        panel02.SetActive(true);
        panel03.SetActive(false);
    }

    public void SaveProfilePanel02()
    {
        panel01.SetActive(true);
        panel02.SetActive(false);
        panel03.SetActive(false);
        Debug.Log("saved profile:" + input.text);
    }

    public void OpenPanel03()
    {
        panel01.SetActive(false);
        panel02.SetActive(false);
        panel03.SetActive(true);
    }

    public void LoadProfile(int num) {
        //load profile and change to player city scene
        Debug.Log("profile loaded: " + num);
    }

}
