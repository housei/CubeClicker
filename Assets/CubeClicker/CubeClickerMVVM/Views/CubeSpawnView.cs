namespace CubeClicker
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.MVVM.Services;
    using uFrame.MVVM.Bindings;
    using uFrame.Serialization;
    using UniRx;
    using UnityEngine;
    using CubeClicker;
    
    public class CubeSpawnView : CubeSpawnViewBase
    {
                
        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model)
        {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as CubeSpawnViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
        }

        public override void Bind()
        {
            base.Bind();
            // Use this.CubeSpawn to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.
        }

        public override void CubesOnAdd(CubeViewModel arg1)
        {
        }
        
        public override void CubesOnRemove(CubeViewModel arg1)
        {
        }
        
        public override uFrame.MVVM.ViewBase CubesCreateView(uFrame.MVVM.ViewModel viewModel)
        {
            // ResourcesフォルダにあるCube.prefabがロードされInstantiateされる
            return InstantiateView(viewModel);
        }

        public override void CubesAdded(uFrame.MVVM.ViewBase view)
        {
            // キューブの出現位置を設定
            float x = UnityEngine.Random.Range(0.25f, 0.75f);
            float y = UnityEngine.Random.Range(0.25f, 0.75f);
            Vector3 viewPort = new Vector3(x, y, 10);
            view.transform.position = Camera.main.ViewportToWorldPoint(viewPort);
        }
        
        public override void CubesRemoved(uFrame.MVVM.ViewBase view)
        {
            // キューブを削除
            Destroy(view.gameObject);
        }
    }
}
