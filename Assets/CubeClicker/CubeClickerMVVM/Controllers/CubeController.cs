namespace CubeClicker
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    using uFrame.MVVM;
    using uFrame.Kernel;
    using uFrame.IOC;
    using uFrame.Serialization;
    
    public class CubeController : CubeControllerBase
    {
        public override void InitializeCube (CubeViewModel viewModel)
        {
            base.InitializeCube (viewModel);
            // This is called when a CubeViewModel is created
        }
    
        public override void ClickCube (CubeViewModel viewModel)
        {
            base.ClickCube (viewModel);
            this.Publish (new ClickCubeEvent (){ Target = viewModel});
        }
        
        public override void ExpireCube (CubeViewModel viewModel)
        {
            base.ExpireCube (viewModel);
            this.Publish (new ExpireCubeEvent (){ Target = viewModel});
        }
    }
}
