using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class main_new : MonoBehaviour
{

    public Text testText;
    private float count = 0;

    private float gpsAccuracy = 1.0f;
    private float gpsUpdateInterval = 1.0f;

    IEnumerator Start()
    {
        Input.compass.enabled = true;
        Input.location.Start(gpsAccuracy, gpsUpdateInterval);
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        

        
    }

    void Update()
    {
        // Start service before querying location
        
        Debug.Log("Latitude : " + Input.location.lastData.latitude);
        Debug.Log("Timestamp : " + Input.location.lastData.timestamp);
        testText.text = "Latitude: " + Input.location.lastData.latitude + " Longitude: " + Input.location.lastData.longitude + " Altitude: " + Input.location.lastData.altitude + " HorizontalAccuracy: " + Input.location.lastData.horizontalAccuracy + " Timestamp: " + Input.location.lastData.timestamp;
        count++;
    }



}