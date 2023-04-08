using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPointMover : MonoBehaviour
{
    //Definição de variáveis
    [SerializeField] float speed = 2.5f;
    public List<Transform> list;
    Vector3 trueTarget;
    int i;
    bool done = false;
    private void Start()
    {
        //Define o primeiro ponto para o gameObject se mover a ser o primeiro ponto da lista
        trueTarget = list[0].position;
    }
    private void Update()
    {
        if (i != list.Capacity -1)
        {
            //Caso não seja o ponto final e esteja no lugar requisitado e não esteja finalizando o caminho no penúltimo ponto, aumenta o valor do próximo ponto a ser seguido em 1
            if (transform.position == trueTarget && !done)
            {
                i++;
            }
        }
        else
        {
            //Caso tenha chegado no destino, desabilita o script
            if (transform.position == trueTarget && done)
            {
                Debug.Log("Zurugma");
                this.enabled = false;
            }
            //Caso seja o ponto final, marca o próximo ponto como último e diminui um no ponto da lista, para marcar o penúltimo
            else if (transform.position == trueTarget)
            {
                done = true;
                i--;
            }
        }
        //Define, de acordo com os argumentos acima, qual o próximo ponto da lista
        trueTarget = list[i].position;
        //Vira ao ponto definido e move-se até ele
        transform.LookAt(trueTarget);
        Vector3 direction = trueTarget - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
