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

    void Start()
    {
        currentProfile = PlayerPrefs.GetInt("currentProfile");
        PlayerData playerData = new PlayerData();
        playerData.power = 1;
        playerData.money = 0;
        playerData.miner = 1;
        playerData.time = 120;
        playerData.level = 1;
        playerData.timeMiner = 1;
        playerData.baseTimeMiner = 1;

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);
    }

    private class PlayerData {
        public int money;
        public int level;//miner level
        public int power;//power
        public int miner;//another multiplier for dwarf
        public float time;//expedition time 
        public float timeMiner; //time for dwarf action
        public float baseTimeMiner; //base time for dwarf action
    }

    public void toMine() {
        _GM.money += _GM.power;
        Instantiate(floatingPoints, stone.transform.position,Quaternion.identity);
    }

    public void Buy(int num) {
        if (num == 1 && _GM.money >= 10) {
            _GM.power += 1;
            _GM.money -= 10;     
        }
        if (num == 2 && _GM.money >= 100)
        {
            _GM.power += 10;
            _GM.money -= 100;
        }
        if (num == 3 && _GM.money >= 250)
        {
            _GM.power += 25;
            _GM.money -= 250;
        }
        if (num == 4 && _GM.money >= 2500)
        {
            _GM.miner += 1;
            _GM.money -= 2500;
        }
        if (num == 5 && _GM.money >= 5000)
        {
            _GM.time += 60;
            _GM.money -= 5000;
        }
    }

    void Update() {
        moneyText.text = "" + _GM.money;     
        powerText.text = "" + _GM.power;
        minersText.text = "" + _GM.miner;
        //level calc
        levelText.text = "" + _GM.level;
        //time lapse
        if (_GM.time > 0) {
            _GM.time -= Time.deltaTime;
        }
        //dwarf action time
        if (_GM.timeMiner > 0)
        {
            _GM.timeMiner -= Time.deltaTime;
        }
        else {
            _GM.money += 1 * _GM.miner;
            _GM.timeMiner = _GM.baseTimeMiner;
            Instantiate(dwarfFloatingPoints, stone.transform.position, Quaternion.identity);
        }
        //timeText.text = "" + _GM.time;
        timeText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(_GM.time / 60), Mathf.FloorToInt(_GM.time % 60));
    }
}
