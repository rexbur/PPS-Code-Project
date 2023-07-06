using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    // Ссылка на куб, что будет областью выделения
    public GameObject cube;
    // Ссылка на камеру, чтобы создавать область с положения камеры
    private Camera _cam;
    // Ссылка на слой, чтобы создавать исключительно на данном слое
    public LayerMask layer;
    // Переменная для создания объекта выделения
    private GameObject _cubeselection;
    // Переменная луч, для определения положения мышк
    private RaycastHit _hit;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // Если нажимаем ЛКМ, то ставим объект
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out _hit, 1000f, layer))
            {
                _cubeselection = Instantiate(cube, new Vector3(_hit.point.x, 1, _hit.point.z), Quaternion.identity);
            }            
        }

        // Если объект создан и мышь зажата, то меняем скейл куба ( его размер по осям х и у)
        if (_cubeselection)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitdrag, 1000f, layer))
            {
                _cubeselection.transform.localScale = new Vector3((_hit.point.x - hitdrag.point.x)*-1, 1, (_hit.point.z - hitdrag.point.z));
            }
        }

        // убираем область выделения, если опускаем левую кнопку мыши и, если отсутствует куб - начало области выделения
        if (Input.GetMouseButtonUp(0) && _cubeselection)
        {
            Destroy(_cubeselection);
        }
    }

}
