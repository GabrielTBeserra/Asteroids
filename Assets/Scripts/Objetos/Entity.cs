using Assets.Scripts.Interface;
using System;
using UnityEngine;

namespace Assets.Scripts.Objetos
{
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        protected Vida vida;
        [SerializeField]
        protected Pontos pontos;
    }
}