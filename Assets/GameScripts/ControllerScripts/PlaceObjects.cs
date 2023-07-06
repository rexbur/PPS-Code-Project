using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{
    // Переменная - ссылка на площадь расстановки
    public LayerMask layer;
    // Переменная - ссылка на площадь расстановки. Нужна для контроля видимости площади
    private GameObject UnitPlacingPos;
    // Для вращения юнита
    public float rotatespeed = 60f;

    private void Start()
    {
        // Вызов метода управления
        PositionObject();
        UnitPlacingPos = GameObject.Find("UnitPlacingPosition");
    }

    private void Update()
    {
        // Вызов метода управления
        PositionObject();
        // При нажатии ПКМ ставим объект на позицию точки пересечения луча и лэйера
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject.GetComponent<PlaceObjects>());
            // Исчезновение площади расстановки
            UnitPlacingPos.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Метод управления
    private void PositionObject()
    {
        // Луч из центра камеры
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Переменная для спавна луча
        RaycastHit hit;
        // Если луч пересекает площадь расстановки, получаем координаты точки в пространстве
        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            // Получение точки в пространстве
            transform.position = hit.point;
        }

        // При зажатии левого шифта крутим объект вокруг оси Y
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotatespeed);                        
        }
    }
}
