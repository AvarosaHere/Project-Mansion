﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMasion
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [Header("Fisica")]
        public Rigidbody rb;
        public Animator animator;
        public float speed = 0;
        public float jumpSpeed = 0;
        public float rotationSpeed = 0;

        [HideInInspector]
        public Vector3 moveDirX;
        [HideInInspector]
        public Vector3 moveDirY;
        [HideInInspector]
        public Vector3 positionCamara;

        ConstructorController control;
        MovementConstructor movement;

        [Header("Punto donde mira Luigi")]
        public int xCam;
        public int zCam;

        [Header("Raycast")]
        public bool noWall = true;
        public LayerMask _layerMask;
        [HideInInspector]
        public bool Jump = false;

        void Start()
        {
            movement = new MovementConstructor(this);
            control = new ConstructorController(movement);
        }

        void Update()
        {
            control.OnUpdate();
        }
    }
}