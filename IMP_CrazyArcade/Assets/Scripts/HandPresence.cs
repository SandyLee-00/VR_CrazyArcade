using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;

  //  [SerializeField]
   // private List<GameObject> controllerPrefabs;

    [SerializeField]
    private InputDeviceCharacteristics controllerCharacteristics;

    private GameObject spawnedController;

    [SerializeField]
    private bool showController = false;

    [SerializeField]
    private GameObject handModelPrefab;

    private GameObject spawnedHand;

    private Animator handanimator;

    // Start is called before the first frame update
    void Start()
    {
        List <InputDevice> devices= new List<InputDevice>();

       // InputDeviceCharacteristics chars = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (InputDevice dev in devices)
        {
            Debug.Log(dev.name + " " + dev.characteristics);
        }

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
        }

        // spawn the hand
        spawnedHand = Instantiate(handModelPrefab,transform);

        // get an animator
        handanimator = spawnedHand.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // TestInputs();
        spawnedHand.SetActive(!showController);
        //  spawnedController.SetActive(showController);

        if (!showController)
        {
            UpdateHandAnimation();
        }
    }

    private void UpdateHandAnimation()
    {
        // trigger pressed
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handanimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handanimator.SetFloat("Trigger", 0);
        }

        // grip pressed
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handanimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handanimator.SetFloat("Grip", 0);
        }
    }

    private void TestInputs()
    {
        if (targetDevice == null) return;

        if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed))
        {
            Debug.Log("Primary pressed: " + pressed);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            Debug.Log("Trigger value: " + triggerValue);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed))
        {
            Debug.Log("Trigger pressed: " + triggerPressed);
        }
        /*
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out bool gripValue))
        {
            Debug.Log("Grip value: " + gribValue);
        }
        */
    }
}
