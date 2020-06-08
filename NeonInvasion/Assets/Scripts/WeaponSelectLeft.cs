using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectLeft : MonoBehaviour
{
    [SerializeField]
    private OVRInput.Button weaponSelectButtonUp;

    [SerializeField]
    private OVRInput.Button weaponSelectButtonDown;

    [SerializeField]
    private GameObject swordWeapon;

    [SerializeField]
    private GameObject gunWeapon;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        swordWeapon.SetActive(true);

        gunWeapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(weaponSelectButtonUp))
        {
            swordWeapon.SetActive(false);

            gunWeapon.SetActive(true);
        }

        if (OVRInput.GetDown(weaponSelectButtonDown))
        {
            swordWeapon.SetActive(true);

            gunWeapon.SetActive(false);

            uiManager.ReloadLeftWarningDisable();

            uiManager.ReloadRightWarningDisable();
        }
    }       
}
