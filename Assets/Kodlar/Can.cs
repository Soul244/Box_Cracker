﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Can : MonoBehaviour {
    public Text can;
    public Text süre;
    float zaman = 0f;
    int cansayisi = 0;
    float süresayisi = 300f;
    int gecici = 0;
    int dk, sn = 0;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Can Sayısı", int.Parse(can.text));
        if (PlayerPrefs.GetInt("Süre")>0)
        {
            süresayisi = PlayerPrefs.GetInt("Süre");
        }
        süre.text = süresayisi.ToString();        
    }	
	// Update is called once per frame
	void Update () {
        cansayisi = PlayerPrefs.GetInt("Can Sayısı");
        if (cansayisi != 5)
        {
            zaman += Time.deltaTime;
            gecici = Convert.ToInt32(süresayisi - int.Parse(zaman.ToString().Split('.')[0]));
            if (gecici>59)
            {
                dk = gecici / 60;
                sn = gecici % 60;
            }
            else
            {
                dk = 00;
                sn = gecici;
            }
            if (sn == 0)
            {
                süre.text = dk.ToString() + ":" + sn.ToString()+"0";
                PlayerPrefs.SetInt("Süre", gecici);
            }
            else
            {
                süre.text = dk.ToString() + ":" + sn.ToString();
                PlayerPrefs.SetInt("Süre", gecici);
            }   
            if (zaman >= süresayisi)
            {
                cansayisi++;
                can.text = (cansayisi).ToString();
                PlayerPrefs.SetInt("Can Sayısı", cansayisi);
                süresayisi = 300f;
                zaman = 0;
            }
        }
        else
        {
            süre.text = "";
        }
    }
}