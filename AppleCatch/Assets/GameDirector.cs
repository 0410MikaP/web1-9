﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

    GameObject timerText;
    GameObject pointText;
    float time = 45.0f;
    int point = 0;
    GameObject generator;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

	// Use this for initialization
	void Start () {
        this.generator = GameObject.Find("ItemGenerator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
	}
	
	// Update is called once per frame
	void Update () {
        this.time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(
                10000.0f, 0, 0);
        }else if (0 <= this.time && this.time < 10)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(
                0.3f, -0.09f, 6);
        }else if (10 <= this.time && this.time < 20)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(
                0.5f, -0.05f, 4);
        }else if (20 <= this.time && this.time < 35)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(
               0.6f, -0.04f, 3);
        }else if (35 <= this.time && this.time < 45)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(
               0.7f, -0.03f, 2);
        }

        this.timerText.GetComponent<Text>().text =
            this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text =
            this.point.ToString() + "point";
	}
}
