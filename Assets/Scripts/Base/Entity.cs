using Assets.Scripts.Interface;
using System;
using UnityEngine;

namespace Assets.Scripts.Objetos
{
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        public Vida vida;
        [SerializeField]
        public Pontos pontos;
    }
}