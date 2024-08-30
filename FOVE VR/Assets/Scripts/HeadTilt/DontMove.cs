using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.VR;
using UnityEngine.XR;
using InputTracking = UnityEngine.XR.InputTracking;

public class DontMove : MonoBehaviour
{

    public Camera childCamera;
    public Vector3 RotateAmount;


    UnityEngine.XR.InputDevice ViveHMD;

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
                        Debug.Log(string.Format(" feature {0}'s type is {1}, other data {2}", feature.name, feature.type, feature.ToString()));
                    }
                }

                UpdateCoordinates();
                PrintCoordinates();
            }
            else if (device.name == "Vive. MV")
            {
                ViveHMD = device;
                Debug.Log(string.Format("Found the Vive! it'd called '{0}'", ViveHMD.name));

                var inputFeatures = new List<UnityEngine.XR.InputFeatureUsage>();
                if (device.TryGetFeatureUsages(inputFeatures))
                {
                    foreach (var feature in inputFeatures)
                    {
                        Debug.Log(string.Format(" feature {0}'s type is {1}, other data {2}", feature.name, feature.type, feature.ToString()));
                    }
                }

                UpdateCoordinates();
                PrintCoordinates();
            }
            else {
                Debug.Log(string.Format("Can't find Vive"));
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
