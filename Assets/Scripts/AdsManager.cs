using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{

   #if UNITY_ANDROID
       string game_id = "4488333";
#endif


    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(game_id);
        Advertisement.AddListener(this);
       
        //Banner();
    }

   public void PlayAd()
    {
        if(Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    //public void Banner()
    //{
    //    if (Advertisement.IsReady("Banner_Android"))
    //    {

    //        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    //        Advertisement.Show("Interstitial_Android");
    //    }
    //    else
    //    {
    //        StartCoroutine(Repeatshowbanner());
    //    }
        
    //}



    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    //IEnumerator Repeatshowbanner()
    //{
    //    yield return new WaitForSeconds(1);
    //    Banner();
    //}

    public void RewardedAds(string RewardedAdId)
    {
        if (Advertisement.IsReady(RewardedAdId))
        {
            Advertisement.Show(RewardedAdId);
        }
        else
        {
            Debug.Log("Rewarded Ads is not ready");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId== "rewardedtime")
        {
            Blocks.instance.timeextend();
        }
    }
}
