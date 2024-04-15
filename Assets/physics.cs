using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class physics : MonoBehaviour {

    private float pi = 3.14F;
    private float k = 8987551787.3681764F;
    private float raioCampo;
    private float p = 0.000000002F; //densidade da carga
    private float E; //campo Eletrico
    private float E0 = 0.00000000000885F;

    public static float raioEsfera;
    public float increaseAmount = 0.1F;

    public Text textoCampo;
    public Text textoRaioEsfera;
    public Text textoRaioCampo;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        //Pega o raio da Esfera pelo script ChangeSize
        raioEsfera = ChangeSize.raioEsfera;

        //Determina o Raio do Campo, através da componente X
        raioCampo = GetComponent<Collider>().bounds.size.x;

        //Calcula o Campo Eletrico para r < R
        if (raioCampo < raioEsfera)
        {
            //E = (4 * p * pi * k * raioCampo) / 3;
            E = (p * raioCampo) / (3 * E0);
        }

        //Calcula o Campo Eletrico para r > R
        else
        {
            E = (p * raioEsfera * raioEsfera * raioEsfera) / (3 * E0 * raioCampo * raioCampo);
        }

        //Input para AUMENTAR ou DIMINUIR o tamanho da esfera
        if (Input.GetMouseButton(0))
        {
            float X = Input.GetAxis("Mouse X");
            transform.localScale += new Vector3(increaseAmount * X, increaseAmount * X, increaseAmount * X);
        }

        //Exibe os textos na tela
        textoCampo.text = "Campo Eletrico: " + E.ToString("#.0000");
        textoRaioCampo.text = "Raio do Campo: " + raioCampo.ToString("#.0000");
        textoRaioEsfera.text = "Raio da Esfera: " + raioEsfera.ToString("#.0000");

        //Debugs
        Debug.Log(" Campo Eletrico: " + E + " N/C | R=" + raioEsfera + "m | r=" + raioCampo + "m");


    }


}