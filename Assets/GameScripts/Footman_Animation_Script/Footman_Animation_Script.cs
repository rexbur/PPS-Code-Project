using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman_Animation_Script : MonoBehaviour
{
    // Точка следования
    public Transform TargetPoint;
    // Получение ссылки для анимации в инспекторе
    public Animator Animations;
    // Слайдер регулирования скорости
    [Range(0, 10)]
    public float Speed;
    // Переменная для указания передвежения и текущего положения
    private Transform _Selftransform;

    private void Start()
    {
        // Получение текущего положения объекта
        _Selftransform = GetComponent<Transform>();
    }

    
    private void Update()
    {
        // Смена положения на таргет поинт ( точка куда идти )
        Vector3 _newposition = Vector3.MoveTowards(_Selftransform.position, TargetPoint.position, Speed * Time.deltaTime);

        Vector3 between = _newposition - _Selftransform.position;

        Animations.SetFloat("Speed", between.magnitude * 10);

        _Selftransform.position = _newposition;
    }
}
