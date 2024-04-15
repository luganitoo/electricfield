using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorDust : MonoBehaviour {

    public static float raioCampo;
    public static float raioEsfera;

    void Update()
    {

        raioEsfera = ChangeSize.raioEsfera;
        raioCampo = physicsTouch.raioCampo;

        //Trocar a cor
        if (raioCampo < raioEsfera)
            this.GetComponent<ParticleSystem>().startColor = new Color(1, 0.3f, 0, 0.1f);
        if (raioEsfera < raioCampo)
            this.GetComponent<ParticleSystem>().startColor = new Color(0.1f, .5f, 1, 0.1f);

    }
}
