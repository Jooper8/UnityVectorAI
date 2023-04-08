using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPoint : MonoBehaviour
{
    //Declara��o de vari�veis
    [SerializeField] float speed = 2.5f;
    [SerializeField] Transform[] targets = new Transform[2];
    Vector3 trueTarget;
    private void Update()
    {
        //Caso o objeto esteja na posi��o 0, � definido para que v� at� a 1, e vice-versa
        if (transform.position == targets[0].position)
        {
            trueTarget = targets[1].position;
        }
        else if (transform.position == targets[1].position)
        {
            trueTarget = targets[0].position;
        }
        //Vira � dire��o do ponto definido e move-se para tal ponto.
        transform.LookAt(trueTarget);
        Vector3 direction = trueTarget - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
