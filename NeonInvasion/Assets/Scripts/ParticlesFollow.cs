using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesFollow : MonoBehaviour
{
    public string pathName;

    public float time;
         
    void Start()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "easetype", iTween.EaseType.easeInOutSine, "time", time));
    }

}
