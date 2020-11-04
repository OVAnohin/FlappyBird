using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container; // место где будут наши объекты
    [SerializeField] private int _capacity; // 

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    protected GameObject Container => _container;

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main; // лучше сразу записать и найти нашу камеру, не забыть, что бы на камеры был тег MainCamera

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform); // создаем нужное в _container
            spawned.SetActive(false); // сразу выключаем созданый обьект

            _pool.Add(spawned);
        }
    }

    protected void DisableObjectAbroadScreen()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                Vector3 point = _camera.WorldToViewportPoint(item.transform.position);
                if (point.x < 0)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }
}
