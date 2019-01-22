using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSController : MonoBehaviour {

    [SerializeField] Text gpsTextView;
    [SerializeField] Text debugTextView;

    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        Input.location.Start();
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

}
