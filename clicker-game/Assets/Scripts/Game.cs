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

    public void toMine() {
        _GM.money += _GM.power;
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
        }
        //timeText.text = "" + _GM.time;
        timeText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(_GM.time / 60), Mathf.FloorToInt(_GM.time % 60));
    }
}
