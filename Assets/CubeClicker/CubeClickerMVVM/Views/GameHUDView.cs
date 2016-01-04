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
    
    public class GameHUDView : GameHUDViewBase
    {
        public UnityEngine.UI.Text score;
        public UnityEngine.UI.Text time;
        private float _gameStartSinceTime;

        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model)
        {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as GameCoreViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
        }
        
        public override void Bind()
        {
            base.Bind();
            // Use this.GameCore to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.
        }
    
        public override void ScoreChanged(Int32 arg1)
        {
            score.text = string.Format("SCORE:{0}", arg1);
        }

        public override void TimeLimitChanged(Single arg1)
        {
            time.text = string.Format("TIME:{0:00.00}", arg1);
        }

    }
}
