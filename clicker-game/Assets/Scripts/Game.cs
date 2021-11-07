using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Text moneyText;
    public Text powerText;
    public Text minersText;
    public Text timeText;
    public Text levelText;
    public GameObject floatingPoints;
    public GameObject dwarfFloatingPoints;
    public GameObject stone;
    public int currentProfile;
    public string currentProfileData;
    public static PlayerData playerData = new PlayerData();

    void Start()
    {
        currentProfile = PlayerPrefs.GetInt("currentProfile");
        currentProfileData = PlayerPrefs.GetString("jsonGameData" + currentProfile);
        if (currentProfileData == "")
        {

            playerData.power = 1;
            playerData.money = 0;
            playerData.miner = 1;
            playerData.time = 120;
            playerData.level = 1;
            playerData.timeMiner = 1;
            playerData.baseTimeMiner = 1;
        }
        else {

            PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(currentProfileData);
            playerData.power = loadedPlayerData.power;
            playerData.money = loadedPlayerData.money;
            playerData.miner = loadedPlayerData.miner;
            playerData.time  = loadedPlayerData.time;
            playerData.level = loadedPlayerData.level;
            playerData.timeMiner = loadedPlayerData.timeMiner;
            playerData.baseTimeMiner = loadedPlayerData.baseTimeMiner;
        }
               
    }

    public class PlayerData {
        public int money;
        public int level;//miner level
        public int power;//power
        public int miner;//another multiplier for dwarf
        public float time;//expedition time 
        public float timeMiner; //time for dwarf action
        public float baseTimeMiner; //base time for dwarf action
    }

    
    public void toMine() {
        //playerData.money += playerData.power;
        playerData.money += playerData.power;
        Instantiate(floatingPoints, stone.transform.position,Quaternion.identity);
    }

    public void Buy(int num) {
        if (num == 1 && playerData.money >= 10) {
            playerData.power += 1;
            playerData.money -= 10;     
        }
        if (num == 2 && playerData.money >= 100)
        {
            playerData.power += 10;
            playerData.money -= 100;
        }
        if (num == 3 && playerData.money >= 250)
        {
            playerData.power += 25;
            playerData.money -= 250;
        }
        if (num == 4 && playerData.money >= 2500)
        {
            playerData.miner += 1;
            playerData.money -= 2500;
        }
        if (num == 5 && playerData.money >= 5000)
        {
            playerData.time += 60;
            playerData.money -= 5000;
        }
    }

    void Update() {
        moneyText.text = "" + playerData.money;     
        powerText.text = "" + playerData.power;
        minersText.text = "" + playerData.miner;
        //level calc
        levelText.text = "" + playerData.level;
        //time lapse
        if (playerData.time > 0) {
            playerData.time -= Time.deltaTime;
        }
        //dwarf action time
        if (playerData.timeMiner > 0)
        {
            playerData.timeMiner -= Time.deltaTime;
        }
        else {
            playerData.money += 1 * playerData.miner;
            playerData.timeMiner = playerData.baseTimeMiner;
            Instantiate(dwarfFloatingPoints, stone.transform.position, Quaternion.identity);
        }
        //timeText.text = "" + playerData.time;
        timeText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(playerData.time / 60), Mathf.FloorToInt(playerData.time % 60));
        string json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("jsonGameData"+currentProfile, json);
    }
}
