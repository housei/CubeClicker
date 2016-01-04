namespace CubeClicker.Logic
{
    public enum CubeType
    {
        RED,
        GREEN,
        MAGENTA,
        YELLOW,
    }

    public class Cube
    {
        public string Id{ get; private set; }
        
        public CubeType Type{ get; private set; }
        
        public int Point{ get; private set; }   // スコアに換算するポイント
        public float AddTime{ get; private set; } // 制限時間の加算値
        public float Expire{ get; private set; } // 消滅までの時間(秒）
        
        public Cube(string id, CubeType type, int point, float addTime, float expire)
        {
            Id = id;
            Type = type;
            Point = point;
            AddTime = addTime;
            Expire = expire;
        }
    }    
}