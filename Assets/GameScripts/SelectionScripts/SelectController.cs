using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    // ������ �� ���, ��� ����� �������� ���������
    public GameObject cube;
    // ������ �� ������, ����� ��������� ������� � ��������� ������
    private Camera _cam;
    // ������ �� ����, ����� ��������� ������������� �� ������ ����
    public LayerMask layer;
    // ���������� ��� �������� ������� ���������
    private GameObject _cubeselection;
    // ���������� ���, ��� ����������� ��������� ����
    private RaycastHit _hit;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // ���� �������� ���, �� ������ ������
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out _hit, 1000f, layer))
            {
                _cubeselection = Instantiate(cube, new Vector3(_hit.point.x, 1, _hit.point.z), Quaternion.identity);
            }            
        }

        // ���� ������ ������ � ���� ������, �� ������ ����� ���� ( ��� ������ �� ���� � � �)
        if (_cubeselection)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitdrag, 1000f, layer))
            {
                _cubeselection.transform.localScale = new Vector3((_hit.point.x - hitdrag.point.x)*-1, 1, (_hit.point.z - hitdrag.point.z));
            }
        }

        // ������� ������� ���������, ���� �������� ����� ������ ���� �, ���� ����������� ��� - ������ ������� ���������
        if (Input.GetMouseButtonUp(0) && _cubeselection)
        {
            Destroy(_cubeselection);
        }
    }

}
