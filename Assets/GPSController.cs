using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This class controls GPS inputs.
/// This class is singlton, sot can't copy twice.
/// </summary>
public class GPSController : MonoBehaviour
{
    #region Static Fields
    static GPSController instance;
    #endregion

    #region Private Serialize Fields
    [Header("GPS Accuracy Parameters")]
    [Tooltip("This value will be the accuracyInMeter of GPS")]
    [SerializeField]
    float accuraceInMeter = 10.0f;
    [Tooltip("This value will be the updateDistanceInMeters of GPS")]
    [SerializeField]
    float updateDistanceInMeter = 5.0f;
    #endregion

    #region Private Fields
    private LocationInfo lastLocationInfo;
    #endregion
    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        Input.location.Start(accuraceInMeter, updateDistanceInMeter);
        int maxWait = 120;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            lastLocationInfo = Input.location.lastData;
            Debug.LogFormat("Location: {0}:{1}\nAltitude(高度): {2}\nHorizontalAccuracy: {3}\nTimeStamp: {4}", lastLocationInfo.latitude, lastLocationInfo.longitude, lastLocationInfo.altitude, lastLocationInfo.horizontalAccuracy, lastLocationInfo.timestamp);
        }
        instance = this;
    }

    private void Update()
    {
        lastLocationInfo = Input.location.lastData;
        Debug.LogFormat("Latitude: {0}\nLongitude: {1}", lastLocationInfo.latitude, lastLocationInfo.longitude);
        Debug.LogFormat("Location: {0}:{1}\nAltitude(高度): {2}\nHorizontalAccuracy: {3}\nTimeStamp: {4}", lastLocationInfo.latitude, lastLocationInfo.longitude, lastLocationInfo.altitude, lastLocationInfo.horizontalAccuracy, lastLocationInfo.timestamp);
    }

    public static float GetLatitude()
    {
        bool canGetAccurateRes = false;
        float getLatitude = 0f;
        while (canGetAccurateRes){
            LocationInfo locationInfo = Input.location.lastData;
            // 正確な値が取れたとき
            if (locationInfo.horizontalAccuracy <= 3.0f) 
            {
                canGetAccurateRes = true;
                getLatitude = locationInfo.latitude;
            }
        }
        return getLatitude;
    }

    public static float GetLongitude()
    {
        bool canGetAccurateRes = false;
        float getLongitude = 0f;
        while (canGetAccurateRes)
        {
            LocationInfo locationInfo = Input.location.lastData;
            // 正確な値が取れたとき
            if (locationInfo.horizontalAccuracy <= 3.0f)
            {
                canGetAccurateRes = true;
                getLongitude = locationInfo.longitude;
            }
        }
        return getLongitude;
    }

}
