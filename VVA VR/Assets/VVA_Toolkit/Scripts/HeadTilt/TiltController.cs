using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using InputTracking = UnityEngine.XR.InputTracking;

public class TiltController : MonoBehaviour
{

    public Camera childCamera;
    public Vector3 RotateAmount;
    public UdpSignal UDPdata; //from WiFi Arduino
    public float rawTiltValue;
    public float dc_offset = 2565f;
    public float tiltValue;
    public float Gain_voltage_to_angle = 0.0366f;
    public float UDP_counter;

    UnityEngine.XR.InputDevice ViveHMD;

    //Low Pass Filter
    protected Queue<float> filterDataQueue = new Queue<float>();
    public int filterLength = 50;
    public float filteredTiltValue = 0;

    //Current
    UnityEngine.Vector3 ViveHMDPosition;
    UnityEngine.Quaternion ViveHMDRotation;
    UnityEngine.Vector3 ViveHMDVelocity;
    UnityEngine.Vector3 ViveHMDAngularVelocity;

    //Previous
    UnityEngine.Vector3 preViveHMDPosition;
    UnityEngine.Quaternion preViveHMDRotation;
    UnityEngine.Vector3 preViveHMDVelocity;
    UnityEngine.Vector3 preViveHMDAngularVelocity;

    private void Awake()
    {
        XRDevice.DisableAutoXRCameraTracking(childCamera, true);
    }

    // Start is called before the first frame update
    void Start()
    {

        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));
            if (device.name == "Vive DVT")
            {
                ViveHMD = device;
                Debug.Log(string.Format("Found the Vive! it'd called '{0}'", ViveHMD.name));

                var inputFeatures = new List<UnityEngine.XR.InputFeatureUsage>();
                if (device.TryGetFeatureUsages(inputFeatures))
                {
                    foreach (var feature in inputFeatures)
                    {
                        Debug.Log(string.Format(" feature {0}'s type is {1}, other data {2}", feature.name,feature.type, feature.ToString()));
                    }
                }

                UpdateCoordinates();
                PrintCoordinates();
            }
            break;
        }


    }

    

    // Update is called once per frame
    void Update()
    {
        UpdateCoordinates();

        //if changed print
        if (preViveHMDPosition != ViveHMDPosition || 
            preViveHMDRotation != ViveHMDRotation || 
            preViveHMDVelocity != ViveHMDVelocity ||
            preViveHMDAngularVelocity != ViveHMDAngularVelocity)
        { PrintCoordinates(); }


        if (UDPdata.signalData[0] != 0)
        {
            rawTiltValue = UDPdata.signalData[1];
            print(UDPdata.signalData[0]);
            UDP_counter = UDPdata.signalData[0];
            UDPdata.signalData[0] = 0;
        }


        // Arduino Uno 1 bit is ..4.9mV. Home is about 2.5V.
        tiltValue = (rawTiltValue * 4.9f - dc_offset) * Gain_voltage_to_angle;

        //Low pass filter
        filterDataQueue.Enqueue(tiltValue);
        if (filterDataQueue.Count > filterLength)
        { filterDataQueue.Dequeue(); }
        foreach (float f in filterDataQueue)
            filteredTiltValue += f;
        filteredTiltValue /= filterLength;

        transform.eulerAngles = new Vector3(0, 0, filteredTiltValue);
        
        //Inverse Kinematics - negate HMD tracking - may be useful later.
        //transform.rotation = Quaternion.Inverse(ViveHMDRotation);
        //transform.position = -(transform.rotation * ViveHMDPosition);
 
    }





    void PrintCoordinates()
    {
        //Debug.Log("Position " + ViveHMDPosition.ToString("F8") + 
        //         " Rotaton " + ViveHMDRotation.ToString("F8") +  
        //         " Velocity " + ViveHMDVelocity.ToString("F8") +
        //         " Angular Velocity" + ViveHMDAngularVelocity.ToString("F8"));
    }

    void UpdateCoordinates()
    {
        //Previous
        preViveHMDPosition = ViveHMDPosition;
        preViveHMDRotation = ViveHMDRotation;
        preViveHMDVelocity = ViveHMDVelocity;
        preViveHMDAngularVelocity = ViveHMDAngularVelocity;


        //ViveHMD.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out ViveHMDPosition);
        //ViveHMD.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out ViveHMDRotation);
        //ViveHMD.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceVelocity, out ViveHMDVelocity);
        //ViveHMD.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAngularVelocity, out ViveHMDAngularVelocity);
        ViveHMD.TryGetFeatureValue(UnityEngine.XR.CommonUsages.centerEyePosition, out ViveHMDPosition);
        ViveHMD.TryGetFeatureValue(UnityEngine.XR.CommonUsages.centerEyeRotation, out ViveHMDRotation);
        ViveHMD.TryGetFeatureValue(UnityEngine.XR.CommonUsages.centerEyeVelocity, out ViveHMDVelocity);
        ViveHMD.TryGetFeatureValue(UnityEngine.XR.CommonUsages.centerEyeAngularVelocity, out ViveHMDAngularVelocity);

    }
}
