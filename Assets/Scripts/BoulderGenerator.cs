using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderGenerator : ObjectPool
{
    [SerializeField] private GameObject _templatePrefab; // наш шаблон. префаб
    [SerializeField] private float _secondsBetweenSpawn; // время между spawn
    [SerializeField] private float _maxSpawnPositionY; // по Y мы делаем разброс
    [SerializeField] private float _minSpawnPositionY; // 

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_templatePrefab); // создаем наш пул стен
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            GameObject boulder;
            if (TryGetObject(out boulder)) // есть препятсвия в пуле? 
            {
                _elapsedTime = 0;
                // !!!! тут проблемы с камерой и её по Z мещению. 
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY); // создаем рандомный Y 
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, Container.transform.position.z); //
                boulder.SetActive(true); // включаем нашу стену
                boulder.transform.position = spawnPoint; // устанавливаем

                DisableObjectAbroadScreen();
            }
        }
    }
}
