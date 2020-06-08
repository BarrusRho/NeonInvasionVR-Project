using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootIfGrabbed : MonoBehaviour
{
    private SimpleShoot simpleShoot;

    private OVRGrabbable ovrGrabbable;

    public OVRInput.Button shootingButton;

    public int maxNumberOfBullets = 10;

    public Text bulletText;

    public AudioClip shootingAudio;

    // Start is called before the first frame update
    void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();

        ovrGrabbable = GetComponent<OVRGrabbable>();

        bulletText.text = maxNumberOfBullets.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()) && maxNumberOfBullets > 0)
        {
            VibrationManager.singleton.TriggerVibration(40, 2, 255, ovrGrabbable.grabbedBy.GetController());

            GetComponent<AudioSource>().PlayOneShot(shootingAudio);

            simpleShoot.TriggerShoot();

            maxNumberOfBullets--;

            bulletText.text = maxNumberOfBullets.ToString();
        }
    }
}
