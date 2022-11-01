using UnityEngine;
using System;
using GoogleMobileAds.Api;
using System.Collections;
using UnityEngine.UI;

public enum AdType
{
    INTERSTITIAL,
    INTERSTITIAL2,
    REWARDEDLETTER,
    REWARDEDCHANGE,
}

public class Ads : MonoBehaviour
{
    [HideInInspector]
    public string interstitialId, interstitialId2, rewardedAdIdChange, rewardedAdIdLetter;


    private InterstitialAd interstitialAd;
    private InterstitialAd interstitialAd2;
    private RewardedAd rewardedAdChange;
    private RewardedAd rewardedAdLetter;

    public static Ads instance;
    private IAPManager iapManager;

    [SerializeField] private GameObject noAdsButton;
   
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) instance = this;
        else Destroy(gameObject);

        iapManager = new IAPManager();
        NoAdsButtonAktifligi();
        // ctrl + k + c
        if (Application.platform == RuntimePlatform.Android)
        {
            interstitialId = "ca-app-pub-1131363594533119/1272297373";

            interstitialId2 = "ca-app-pub-1131363594533119/1496762304";

            rewardedAdIdChange = "ca-app-pub-1131363594533119/1305190617";

            rewardedAdIdLetter = "ca-app-pub-1131363594533119/3515317334";
        }
        else
        {
            interstitialId = "ca-app-pub-1131363594533119/8168878217";

            interstitialId2 = "ca-app-pub-1131363594533119/5491847639";

            rewardedAdIdChange = "ca-app-pub-1131363594533119/1552602620";

            rewardedAdIdLetter = "ca-app-pub-1131363594533119/7785734830";
        }

        //#region TestId

        //interstitialId = "ca-app-pub-3940256099942544/1033173712";

        //interstitialId2 = "ca-app-pub-3940256099942544/1033173712";

        //rewardedAdIdLetter = "ca-app-pub-3940256099942544/5224354917";

        //rewardedAdIdChange = "ca-app-pub-3940256099942544/5224354917";

        //#endregion
    }

    void Start()
    {
        MobileAds.Initialize(reklamDurumu => { });

        requestAds(AdType.INTERSTITIAL);
        requestAds(AdType.INTERSTITIAL2);
        requestAds(AdType.REWARDEDLETTER);
        requestAds(AdType.REWARDEDCHANGE);


        this.rewardedAdLetter.OnUserEarnedReward += RewardLetter;
        this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        this.rewardedAdLetter.OnAdClosed += RequestRewardedLetter;
        this.rewardedAdChange.OnAdClosed += RequestRewardedChange;
        this.interstitialAd.OnAdClosed += RequestInterstitial;
        this.interstitialAd2.OnAdClosed += RequestInterstitial2;

    }

    #region CallBacks

    #region Load & Show

    void RewardLetter(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");
        
        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        yonetici.OyuncuyaOdulVer();

    }
    void RewardChange(object sender, Reward args)
    {
        Debug.Log("Change Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        yonetici.OyuncuyaOdulVer2();

        
    }
    #endregion

    private void RequestRewardedLetter(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDLETTER);
    }
    private void RequestRewardedChange(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDCHANGE);
    }
    private void RequestInterstitial(object sender, EventArgs args)
    {
        requestAds(AdType.INTERSTITIAL);
    }
    private void RequestInterstitial2(object sender, EventArgs args)
    {
        requestAds(AdType.INTERSTITIAL2);
    }

    //Show
    public void ShowRewardedLetter()
    {
        this.rewardedAdLetter.OnUserEarnedReward -= RewardLetter;
        this.rewardedAdLetter.OnUserEarnedReward += RewardLetter;

        this.rewardedAdLetter.OnAdClosed -= RequestRewardedLetter;
        this.rewardedAdLetter.OnAdClosed += RequestRewardedLetter;


        if (rewardedAdLetter.IsLoaded())
            rewardedAdLetter.Show();
    }
    public void ShowRewardedChange()
    {
        this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAdChange.IsLoaded())
            rewardedAdChange.Show();
    }
    public void ShowInter()
    {
        if (iapManager.ReklamEngellendimi()) return; //REKLAM ENGELLENDÝ

        this.interstitialAd.OnAdClosed -= RequestInterstitial;
        this.interstitialAd.OnAdClosed += RequestInterstitial;

        if (interstitialAd.IsLoaded())// REKLAM ÇALIÞTI
            interstitialAd.Show();
    }
    public void ShowInter2()
    {
        if (iapManager.ReklamEngellendimi()) return; //REKLAM ENGELLENDÝ

        this.interstitialAd2.OnAdClosed -= RequestInterstitial2;
        this.interstitialAd2.OnAdClosed += RequestInterstitial2;

        if (interstitialAd2.IsLoaded())// REKLAM ÇALIÞTI
            interstitialAd2.Show();
    }

    #endregion

    #region  Request&Load
    public void requestAds(AdType type)
    {
        switch (type)
        {
            case AdType.INTERSTITIAL:
                {
                    if (interstitialAd != null) interstitialAd.Destroy();
                    interstitialAd = new InterstitialAd(interstitialId);
                    interstitialAd.LoadAd(new AdRequest.Builder().Build());
                    break;

                }
            case AdType.INTERSTITIAL2:
                {
                    if (interstitialAd2 != null) interstitialAd2.Destroy();
                    interstitialAd2 = new InterstitialAd(interstitialId2);
                    interstitialAd2.LoadAd(new AdRequest.Builder().Build());
                    break;

                }
            case AdType.REWARDEDCHANGE:
                {
                    if (rewardedAdChange != null) rewardedAdChange.Destroy();
                    rewardedAdChange = new RewardedAd(rewardedAdIdChange);
                    rewardedAdChange.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDEDLETTER:
                {
                    if (rewardedAdLetter != null) rewardedAdLetter.Destroy();
                    rewardedAdLetter = new RewardedAd(rewardedAdIdLetter);
                    rewardedAdLetter.LoadAd(new AdRequest.Builder().Build());
                    break;
                }

        }
    }
    #endregion
    public void NoAdsButtonAktifligi()
    {
        //SATIN ALMA ÝÞLEMÝ BÝTTÝKTEN SONRA BUTON AKTÝFLÝÐÝ SORGULAMA
        noAdsButton.SetActive(!iapManager.ReklamEngellendimi());
    }
    public void NoAdsButton()
    {
        // REKLAMI ENGELLEMEK ÝÇÝN BUTON ATAMASI
        iapManager.OnPurchaseClicked();
    }
}