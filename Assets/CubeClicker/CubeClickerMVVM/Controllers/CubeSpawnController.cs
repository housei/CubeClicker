namespace CubeClicker
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CubeClicker;
    using UniRx;
    using uFrame.MVVM;
    using uFrame.Kernel;
    using uFrame.IOC;
    using uFrame.Serialization;
    
    public class CubeSpawnController : CubeSpawnControllerBase
    {
        public override void InitializeCubeSpawn(CubeSpawnViewModel viewModel)
        {
            base.InitializeCubeSpawn(viewModel);
            // This is called when a CubeSpawnViewModel is created
        }
    }
}
