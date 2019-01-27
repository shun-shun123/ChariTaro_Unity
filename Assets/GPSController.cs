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
    [SerializeField] Text gpsTextView;
    [SerializeField] Text debugTextView;
    [Header("GPS Accuracy Parameters")]
    [Tooltip("This value will be the accuracyInMeter of GPS")]
    [SerializeField]
    float accuraceInMeter = 10.0f;
    [Tooltip("This value will be the updateDistanceInMeters of GPS")]
    [SerializeField]
    float updateDistanceInMeter = 5.0f;
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
            debugTextView.text = "Location: " +
                  Input.location.lastData.latitude + " " +
                  Input.location.lastData.longitude + " " +
                  Input.location.lastData.altitude + " " +
                  Input.location.lastData.horizontalAccuracy + " " +
                  Input.location.lastData.timestamp;
        }
        instance = this;
    }

    private void Update()
    {
        gpsTextView.text = Input.location.lastData.longitude.ToString() + " : " + Input.location.lastData.latitude.ToString();
        debugTextView.text = "Location: " +
              Input.location.lastData.latitude + " " +
              Input.location.lastData.longitude + " " +
              Input.location.lastData.altitude + " " +
              Input.location.lastData.horizontalAccuracy + " " +
              Input.location.lastData.timestamp;
    }

    public static float GetLongitude()
    {
        return Input.location.lastData.longitude;
    }

    public static float GetLatitude()
    {
        return Input.location.lastData.latitude;
    }
}
