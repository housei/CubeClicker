namespace CubeClicker
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    
    public class CubeClickerSystemLoader : CubeClickerSystemLoaderBase
    {
        
        public override void Load ()
        {
            base.Load ();
            Container.RegisterInstance (new CubeClicker.Logic.CubeClicker ());
        }
    }
}
