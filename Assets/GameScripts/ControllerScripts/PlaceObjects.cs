using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{
    // ���������� - ������ �� ������� �����������
    public LayerMask layer;
    // ���������� - ������ �� ������� �����������. ����� ��� �������� ��������� �������
    private GameObject UnitPlacingPos;
    // ��� �������� �����
    public float rotatespeed = 60f;

    private void Start()
    {
        // ����� ������ ����������
        PositionObject();
        UnitPlacingPos = GameObject.Find("UnitPlacingPosition");
    }

    private void Update()
    {
        // ����� ������ ����������
        PositionObject();
        // ��� ������� ��� ������ ������ �� ������� ����� ����������� ���� � ������
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject.GetComponent<PlaceObjects>());
            // ������������ ������� �����������
            UnitPlacingPos.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // ����� ����������
    private void PositionObject()
    {
        // ��� �� ������ ������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // ���������� ��� ������ ����
        RaycastHit hit;
        // ���� ��� ���������� ������� �����������, �������� ���������� ����� � ������������
        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            // ��������� ����� � ������������
            transform.position = hit.point;
        }

        // ��� ������� ������ ����� ������ ������ ������ ��� Y
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotatespeed);                        
        }
    }
}
