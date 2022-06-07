using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class shootXR : MonoBehaviour
{

    private InputDevice targetDevice;

    public GameObject projectile;
    float timer = 10f;
    bool start = false;
    public float shootRate = 3f;
    public int ShootForce = 75;
    private GameObject barrelEnd;
    public AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        audioSource = GetComponent<AudioSource>();

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if (devices.Count > 0)
        {
            targetDevice = devices[2];
        }


    }
        

    // Update is called once per frame
    void Update()
    {
        barrelEnd = GameObject.FindGameObjectWithTag("BarrelEnd");
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if (devices.Count > 0)
        {
            targetDevice = devices[2];
        }

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float primaryButtonValue);

            if (primaryButtonValue > 0.1f)
            {
                Debug.Log("button is pressed");


            if (timer >= shootRate)//shoot{
            {
                GameObject newProjectile = Instantiate(projectile, barrelEnd.transform.position, barrelEnd.transform.localRotation);
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * ShootForce, ForceMode.VelocityChange);
                start = true;
                timer = 0f;
                targetDevice.SendHapticImpulse(1, 0.70f, 0.25f);
                audioSource.Play();
            }

            if (start)
            {
                if (timer < shootRate)
                    timer += Time.deltaTime;
                else
                {
                    timer = shootRate;
                    start = false;
                }


            }
        }
        
    }
}
