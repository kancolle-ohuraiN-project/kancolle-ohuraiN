[System.Serializable]
public class GameData
{
    public int ammunition; //弹药
    public int fuel; //燃料
    public int aluminium; //铝
    public int steel; //钢材

    // 此构造函数中定义的值将是默认值 可以修改参数来实现初始资源
    public GameData()
    {
        this.ammunition = 0;
        this.fuel = 0;
        this.aluminium = 0;
        this.steel = 0;
    }
}