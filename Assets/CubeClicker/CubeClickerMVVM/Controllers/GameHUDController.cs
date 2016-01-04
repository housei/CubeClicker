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
    
    public class GameHUDController : GameHUDControllerBase
    {
        
        public override void InitializeGameHUD(GameHUDViewModel viewModel)
        {
            base.InitializeGameHUD(viewModel);
            // This is called when a GameCoreViewModel is created
        }
    }
}
