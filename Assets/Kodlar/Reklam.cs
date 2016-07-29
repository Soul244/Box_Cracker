﻿using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Reklam : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BannerView reklamObjesi = new BannerView(
            "ca-app-pub-2207285899275971/8901820447", AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest reklamiAl = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamiAl);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        InterstitialAd interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }
}
