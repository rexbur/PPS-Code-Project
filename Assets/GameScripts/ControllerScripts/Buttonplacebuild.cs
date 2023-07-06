using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Buttonplacebuild : MonoBehaviour
{
    // ����
    public GameObject unit;
    // ���������� - ������ �� ������� �����������. ����� ��� �������� ��������� �������
    private GameObject UnitPlacingPos;

    public LayerMask layer;

    private void Start()
    {
        UnitPlacingPos = GameObject.Find("UnitPlacingPosition");
        unit.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            UnitVisibilityDuringPlacement();
        }
    }

    public void Placebuild()
    {
        Instantiate(unit, Vector3.zero, Quaternion.identity);
        // ��������� ������� �����������
        UnitPlacingPos.GetComponent<MeshRenderer>().enabled = true;
    }

    // �������� �� ���������� ������� � ������� ����������
    private void UnitVisibilityDuringPlacement()
    {        
        // ��� �� ������ ������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // ���������� ��� ������ ����
        RaycastHit hit;
        // ���� ��� ���������� ������� �����������, �������� ���������� ����� � ������������
        /*if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            UnitPlacingPos.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            UnitPlacingPos.GetComponent<MeshRenderer>().enabled = false;
        }*/
    }
}
