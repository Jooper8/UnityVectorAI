using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Definição de variáveis
    [SerializeField] float speed = 2f;
    [SerializeField] float accuracy = 0.01f;
    [SerializeField] Transform target;
    private void Update()
    {
        //Vira ao ponto definido
        transform.LookAt(target.position);
        Vector3 direction = target.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);
        //Move até o ponto definido, desde que esteja até um certo "accuracy" longe do ponot em questão
        if (direction.magnitude > accuracy)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
