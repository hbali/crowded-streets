using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// First script to run
    /// Initializes game logic
    /// </summary>
    class Starter : MonoBehaviour
    {
        private void Awake()
        {
            
        }

        private void Start()
        {
            Logic.Instance.Initialize();
        }
    }
}
