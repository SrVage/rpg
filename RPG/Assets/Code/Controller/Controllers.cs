using System;
using System.Collections.Generic;
using Code.Interface;
using UnityEngine;

namespace Code.Controller
{
    public class Controllers:IInit, IRun
    {
        private List<IInit> _initList = new List<IInit>();
        private List<IRun> _runList = new List<IRun>();

        public Controllers Add(IController controller)
        {
            if (controller is IInit init)
            {
                _initList.Add(init);
            }

            if (controller is IRun run)
            {
                _runList.Add(run);
            }
            return this;
        }
        
        public void Init()
        {
            foreach (var init in _initList)
            {
                init.Init();
            }
        }

        public void Run(float deltaTime)
        {
            foreach (var run in _runList)
            {
                run.Run(deltaTime);
            }
        }
    }
}