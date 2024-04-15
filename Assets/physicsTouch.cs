using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class physicsTouch : MonoBehaviour
{

    //private float pi = 3.14F;
    //private float k = 8987551787.3681764F;
    
    private float p = 0.000000002F; //densidade da carga
    private float E; //campo Eletrico
    private float E0 = 0.00000000000885F; //constante

    //public static Vector3 sizeCampo;
    public static float raioCampo;
    public static float raioEsfera;
    public float increaseAmount;
    public float increaseAmountPC = 0.01F;

    public Text textoCampo;
    public Text textoRaioEsfera;
    public Text textoRaioCampo;

    void Update()
    {

        //Pega o raio da Esfera pelo script ChangeSize
        raioEsfera = ChangeSize.raioEsfera;

        //Determina o Raio do Campo, através da componente X
        raioCampo = GetComponent<Collider>().bounds.size.x;

        //Calcula o Campo Eletrico para r < R
        if (raioCampo < raioEsfera)
            E = (p * raioCampo) / (3 * E0);

        //Calcula o Campo Eletrico para r > R
        else
            E = (p * raioEsfera * raioEsfera * raioEsfera) / (3 * E0 * raioCampo * raioCampo);

        //Input para AUMENTAR ou DIMINUIR o tamanho da esfera: PC
        float X = Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(0))
        {
            transform.localScale += new Vector3(increaseAmountPC * X, increaseAmountPC * X, increaseAmountPC * X);
        }

        //sizeCampo = transform.localScale;

        //Input para AUMENTAR ou DIMINUIR o tamanho da esfera: Touch
        foreach (Touch touch in Input.touches)
        {

            if (touch.position.x < Screen.width / 2)
            {
                X = Input.touches[0].deltaPosition.y;
                transform.localScale += new Vector3(increaseAmount * X, increaseAmount * X, increaseAmount * X);
            }

        }
        

        //Debugs
        Debug.Log(" Campo Eletrico: " + E + " N/C | R=" + raioEsfera + "m | r=" + raioCampo + "m");

        //Exibe os textos na tela
        textoCampo.text = "Campo Eletrico: " + E.ToString("#.000000") + " N/C";
        textoRaioCampo.text = "Raio do Campo: " + raioCampo.ToString("#.000000") + " m";
        textoRaioEsfera.text = "Raio da Esfera: " + raioEsfera.ToString("#.000000") + " m";
    }


}