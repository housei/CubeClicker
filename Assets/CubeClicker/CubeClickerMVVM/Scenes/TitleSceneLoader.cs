namespace CubeClicker {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.Serialization;
    using UnityEngine;
    
    
    public class TitleSceneLoader : TitleSceneLoaderBase {
        
        protected override IEnumerator LoadScene(TitleScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
        
        protected override IEnumerator UnloadScene(TitleScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
    }
}
