// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace CubeClicker {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    
    
    public class TitleSystemLoaderBase : uFrame.Kernel.SystemLoader {
        
        private TitleController _TitleController;
        
        [uFrame.IOC.InjectAttribute()]
        public virtual TitleController TitleController {
            get {
                if (_TitleController==null) {
                    _TitleController = Container.CreateInstance(typeof(TitleController)) as TitleController;;
                }
                return _TitleController;
            }
            set {
                _TitleController = value;
            }
        }
        
        public override void Load() {
            Container.RegisterViewModelManager<TitleViewModel>(new ViewModelManager<TitleViewModel>());
            Container.RegisterController<TitleController>(TitleController);
        }
    }
    
    public class CubeClickerSystemLoaderBase : uFrame.Kernel.SystemLoader {
        
        private CubeController _CubeController;
        
        private GameHUDController _GameHUDController;
        
        private CubeSpawnController _CubeSpawnController;
        
        [uFrame.IOC.InjectAttribute()]
        public virtual CubeController CubeController {
            get {
                if (_CubeController==null) {
                    _CubeController = Container.CreateInstance(typeof(CubeController)) as CubeController;;
                }
                return _CubeController;
            }
            set {
                _CubeController = value;
            }
        }
        
        [uFrame.IOC.InjectAttribute()]
        public virtual GameHUDController GameHUDController {
            get {
                if (_GameHUDController==null) {
                    _GameHUDController = Container.CreateInstance(typeof(GameHUDController)) as GameHUDController;;
                }
                return _GameHUDController;
            }
            set {
                _GameHUDController = value;
            }
        }
        
        [uFrame.IOC.InjectAttribute()]
        public virtual CubeSpawnController CubeSpawnController {
            get {
                if (_CubeSpawnController==null) {
                    _CubeSpawnController = Container.CreateInstance(typeof(CubeSpawnController)) as CubeSpawnController;;
                }
                return _CubeSpawnController;
            }
            set {
                _CubeSpawnController = value;
            }
        }
        
        public override void Load() {
            Container.RegisterViewModelManager<CubeViewModel>(new ViewModelManager<CubeViewModel>());
            Container.RegisterController<CubeController>(CubeController);
            Container.RegisterViewModelManager<GameHUDViewModel>(new ViewModelManager<GameHUDViewModel>());
            Container.RegisterController<GameHUDController>(GameHUDController);
            Container.RegisterViewModelManager<CubeSpawnViewModel>(new ViewModelManager<CubeSpawnViewModel>());
            Container.RegisterController<CubeSpawnController>(CubeSpawnController);
        }
    }
}
