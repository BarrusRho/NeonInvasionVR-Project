using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberCubesBlue : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;
       
    private Vector3 previousPosition;

    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private GameObject floatingText;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if(Vector3.Angle(transform.position - previousPosition, hit.transform.forward)>130)
            {
                uiManager.IncreaseScoreForSwords();

                Instantiate(effectPrefab, transform.position, transform.rotation);

                ShowFloatingText();

                Destroy(hit.transform.gameObject);
            }
        }
        previousPosition = transform.position;
    }

    void ShowFloatingText()
    {
        Instantiate(floatingText, transform.position, Quaternion.identity);
    }
}
