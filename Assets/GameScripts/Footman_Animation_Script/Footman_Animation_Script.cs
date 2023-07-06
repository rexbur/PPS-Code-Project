using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman_Animation_Script : MonoBehaviour
{
    // ����� ����������
    public Transform TargetPoint;
    // ��������� ������ ��� �������� � ����������
    public Animator Animations;
    // ������� ������������� ��������
    [Range(0, 10)]
    public float Speed;
    // ���������� ��� �������� ������������ � �������� ���������
    private Transform _Selftransform;

    private void Start()
    {
        // ��������� �������� ��������� �������
        _Selftransform = GetComponent<Transform>();
    }

    
    private void Update()
    {
        // ����� ��������� �� ������ ����� ( ����� ���� ���� )
        Vector3 _newposition = Vector3.MoveTowards(_Selftransform.position, TargetPoint.position, Speed * Time.deltaTime);

        Vector3 between = _newposition - _Selftransform.position;

        Animations.SetFloat("Speed", between.magnitude * 10);

        _Selftransform.position = _newposition;
    }
}
