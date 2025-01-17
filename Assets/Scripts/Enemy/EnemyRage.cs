﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRage : UnitEnemy
{
    IEnemyAdvance _enemyCurrentStrategy = null;
    IEnemyAdvance[] _currentStrategy = new IEnemyAdvance[2];

    [Header("Raycast")]
    [SerializeField] private int _distanceRaycast = 0;
    [SerializeField] private GameObject _pointsRaycast = null;
    [SerializeField] private LayerMask _layerMask = 0;
    [SerializeField] private bool activeRaycast = false;

    [Header("Hammer Instancia")]
    [SerializeField] private GameObject hammerPrefab = null;
    [SerializeField] private Transform hammerPoint = null;

    private void Start()
    {
        _currentStrategy[0] = new NormalAdvance(speed, _transform, currentWaypoint, dir, allWaiPoint, meshCollider, BoxCollider);
        _currentStrategy[1] = new AttackAdavance(animator);
        _enemyCurrentStrategy = _currentStrategy[0];
    }

    void Update()
    {
        if (_enemyCurrentStrategy !=null)
        {
            _enemyCurrentStrategy.EnemyAdvance();
        }
        Raycast();
    }

    void Raycast()
    {
        if (Physics.Raycast(_pointsRaycast.transform.position, _pointsRaycast.transform.forward, _distanceRaycast, _layerMask))
        {
            _enemyCurrentStrategy = _currentStrategy[1];
            activeRaycast = true;
            hammerPoint.rotation = Quaternion.Euler(-90, 0, 0);
        }
        else if (Physics.Raycast(_pointsRaycast.transform.position, -_pointsRaycast.transform.forward, _distanceRaycast, _layerMask))
        {
            _enemyCurrentStrategy = _currentStrategy[1];
            activeRaycast = true;
            hammerPoint.rotation = Quaternion.Euler(90, 0, 0);
        }
        else
        {
            activeRaycast = false;
        }
    }

    void Attack()
    {
        Instantiate(hammerPrefab, hammerPoint.position, hammerPoint.rotation);
    }

    void ResetMove()
    {
        if (activeRaycast == false)
            _enemyCurrentStrategy = _currentStrategy[0];
            animator.SetBool("ResetIdle", true);
    }
}
