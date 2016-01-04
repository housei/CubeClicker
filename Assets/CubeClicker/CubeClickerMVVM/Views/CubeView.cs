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
    
    public class CubeView : CubeViewBase, UnityEngine.EventSystems.IPointerClickHandler
    {
        private float rotateSpeed = 260.0f;

        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model)
        {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as CubeViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
        }
        
        public override void Bind()
        {
            base.Bind();

            Color color = Color.white;
            switch (this.Cube.Type) {
            case CubeClicker.Logic.CubeType.RED:
                color = Color.red;
                break;
            case CubeClicker.Logic.CubeType.GREEN:
                color = Color.green;
                break;
            case CubeClicker.Logic.CubeType.MAGENTA:
                color = Color.magenta;
                break;
            case CubeClicker.Logic.CubeType.YELLOW:
                color = Color.yellow;
                break;
            }
            gameObject.GetComponent<Renderer>().material.color = color;
            
            // UpdateAsObservableは毎フレーム処理させることができる
            // Y軸回転させる
            this.UpdateAsObservable().Subscribe(_ => {
                transform.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }).DisposeWith(gameObject);
            
            // Observable.Timerは指定時間後に１回のみ処理をさせることができる
            // 消滅までの時間を設定して、ExpireCubeコマンドを実行させるようにしている
            Observable.Timer(TimeSpan.FromSeconds(this.Cube.Expire)).Subscribe(_ => {
                ExecuteExpireCube();
            }).DisposeWith(gameObject);
        }

        // IPointerClickHandler
        // マウスボタンをクリックした時に呼び出されます
        public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
            // CubeViewModelのClickCubeコマンドを実行する
            ExecuteClickCube();
        }
    }
}
