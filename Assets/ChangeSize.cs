using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour {

    public float increaseAmount;
    public float increaseAmountPC = 0.01F;
    public static float raioEsfera;

	void Update () {

        //Input para AUMENTAR ou DIMINUIR o tamanho da esfera - PC
        float X = Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(1))
            transform.localScale += new Vector3(increaseAmountPC * X, increaseAmountPC * X, increaseAmountPC * X);

        //Input para AUMENTAR ou DIMINUIR o tamanho da esfera - Touch
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x > Screen.width / 2)
            {
                X = Input.touches[0].deltaPosition.y;
                transform.localScale += new Vector3(increaseAmount * X, increaseAmount * X, increaseAmount * X);
            }
        }

        //Determina o Raio da Esfera, através da componente X
        raioEsfera = GetComponent<Collider>().bounds.size.x;
    }

}


