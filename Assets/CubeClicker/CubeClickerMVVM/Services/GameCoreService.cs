namespace CubeClicker
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using UniRx;
    using UnityEngine;
    using uFrame.MVVM;
    
    using UniRx.Triggers;
    
    public class GameCoreService : GameCoreServiceBase
    {
        [Inject]
        public CubeClicker.Logic.CubeClicker _cubeClicker;
        [Inject]
        public IViewModelManager<GameHUDViewModel> _gameHUDViewModels;
        [Inject]
        public IViewModelManager<CubeSpawnViewModel> _cubeSpawnViewModels;

        private GameHUDViewModel GameHUD {
            // GameHUDViewModelは１つか存在しない前提
            get{ return _gameHUDViewModels.FirstOrDefault () as GameHUDViewModel; }
        }
        
        private CubeSpawnViewModel CubeSpawn {
            // CubeSpawnViewModelは１つか存在しない前提
            get{ return _cubeSpawnViewModels.FirstOrDefault () as CubeSpawnViewModel; } 
        }

        /// <summary>
        // ゲーム開始イベントハンドリング
        /// </summary>
        public override void GameStartEventHandler (GameStartEvent data)
        {
            base.GameStartEventHandler (data);
            // Process the commands information.  Also, you can publish new events by using the line below.
            // this.Publish(new AnotherEvent())

            // ゲームロジッククラスの初期化
            _cubeClicker.Init ();
            // スコアとタイムリミットの更新
            UpdateHUD ();
            // キューブを生成させる
            SpawnCube ();

            // UpdateAsObservableは毎フレーム処理させることができる
            // TimeLimitの更新処理
            this.UpdateAsObservable ().Subscribe (_ => {
                UpdateTimeLimit (Time.deltaTime);
            }).DisposeWith (GameHUD);

            // Observable.Intervalは指定時間の間隔で処理を実行させられる
            // 指定時間の間隔でキューブ生成処理を実行する
            Observable.Interval (TimeSpan.FromSeconds (1.0)).Subscribe (_ => {
                SpawnCube ();
            }).DisposeWith (CubeSpawn);
        }

        public override void GameEndEventHandler (GameEndEvent data)
        {
            base.GameEndEventHandler (data);
        }

        public override void ClickCubeEventHandler (ClickCubeEvent data)
        {
            base.ClickCubeEventHandler (data);
            _cubeClicker.ClickCube (data.Target.Id);
            CubeSpawn.Cubes.Remove (data.Target);
            UpdateHUD ();
        }

        public override void ExpireCubeEventHandler (ExpireCubeEvent data)
        {
            base.ExpireCubeEventHandler (data);
            _cubeClicker.ExpireCube (data.Target.Id);
            CubeSpawn.Cubes.Remove (data.Target);
        }

        private void UpdateTimeLimit (float deltaTime)
        {
            _cubeClicker.UpdateTimeLimit (Time.deltaTime);
            UpdateHUD ();
        }

        private void SpawnCube ()
        {
            CubeClicker.Logic.Cube[] cubes = _cubeClicker.SpawnCube ();
            foreach (var cube in cubes) {
                var cubeVM = CreateCubeViewModel (cube);
                CubeSpawn.Cubes.Add (cubeVM);
            }
        }

        private CubeViewModel CreateCubeViewModel (CubeClicker.Logic.Cube cube)
        {
            var cubeVM = this.CreateViewModel<CubeViewModel> ();
            cubeVM.Id = cube.Id;
            cubeVM.Type = cube.Type;
            cubeVM.Point = cube.Point;
            cubeVM.AddTime = cube.AddTime;
            cubeVM.Expire = cube.Expire;
            return cubeVM;
        }

        private void UpdateHUD ()
        {
            GameHUD.TimeLimit = _cubeClicker.TimeLimit;
            GameHUD.Score = _cubeClicker.Score;
        }
    }
}
