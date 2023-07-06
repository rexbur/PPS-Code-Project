using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Buttonplacebuild : MonoBehaviour
{
    // ёнит
    public GameObject unit;
    // ѕеременна€ - ссылка на площадь расстановки. Ќужна дл€ контрол€ видимости площади
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
        // ѕо€вление площади расстановки
        UnitPlacingPos.GetComponent<MeshRenderer>().enabled = true;
    }

    // ѕроверка на нахождение курсора в площади размещени€
    private void UnitVisibilityDuringPlacement()
    {        
        // Ћуч из центра камеры
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // ѕеременна€ дл€ спавна луча
        RaycastHit hit;
        // ≈сли луч пересекает площадь расстановки, получаем координаты точки в пространстве
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
