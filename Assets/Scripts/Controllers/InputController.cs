using Assets.Scripts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputController : MonoBehaviour
    {
        private Atirar atirar;

        void Start()
        {
            atirar = GameObject.FindGameObjectWithTag("Player").GetComponent<Atirar>();    
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                atirar.Atirar();        
            }
        }
    }
}
