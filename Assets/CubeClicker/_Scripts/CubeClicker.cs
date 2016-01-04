using UnityEngine;
using System.Collections;

namespace CubeClicker.Logic
{
    /// キューブクリッカーロジック
    public class CubeClicker
    {
        public float TimeLimit{ get; private set; }
        public int Score{ get; private set; }

        private CubeSpawn _cubeSpawn = new CubeSpawn();
        private static readonly float START_TIME_LIMIT = 30.0f;
        private static readonly float MAX_TIME_LIMIT = 99.99f;
        private static readonly int MAX_SPAWN_CUBE = 4;

        public bool IsTimeOver 
        {
            get{ return TimeLimit <= 0; }
        }

        public CubeClicker()
        {
            Init();
        }

        // 初期化処理
        public void Init()
        {
            TimeLimit = START_TIME_LIMIT;
            Score = 0;
            _cubeSpawn.Clear();
        }

        /// クリックしたキューブの処理
        public void ClickCube(string cubeId)
        {
            var cube = _cubeSpawn.Find(cubeId);
            if (cube != null) {
                AddScore(cube.Point);
                AddTimeLimit(cube.AddTime);
                _cubeSpawn.RemoveCube(cube.Id);
            }
        }

        /// キューブを生成する
        public Cube[] SpawnCube()
        {
            int num = MAX_SPAWN_CUBE - _cubeSpawn.Count;
            if (num <= 0) {
                return new Cube[0];
            }
            num = Random.Range(1, num + 1);
            return _cubeSpawn.CrateCube(num);
        }

        /// 制限時間切れになって消滅したキューブの処理
        public void ExpireCube(string cubeId)
        {
            _cubeSpawn.RemoveCube(cubeId);
        }

        /// 制限時間の更新処理
        public void UpdateTimeLimit(float deltaTime)
        {
            AddTimeLimit(-deltaTime);
        }

        private void AddTimeLimit(float addTime)
        {
            if (IsTimeOver) {
                return;
            }
            TimeLimit += addTime;
            TimeLimit = Mathf.Clamp(TimeLimit, 0.0f, MAX_TIME_LIMIT);
        }

        private void AddScore(int point)
        {
            if (IsTimeOver) {
                return;
            }
            Score += point;
        }
    }
}
