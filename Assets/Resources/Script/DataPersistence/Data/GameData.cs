[System.Serializable]
public class GameData
{
    public int ammunition; //��ҩ
    public int fuel; //ȼ��
    public int aluminium; //��
    public int steel; //�ֲ�

    // �˹��캯���ж����ֵ����Ĭ��ֵ �����޸Ĳ�����ʵ�ֳ�ʼ��Դ
    public GameData()
    {
        this.ammunition = 0;
        this.fuel = 0;
        this.aluminium = 0;
        this.steel = 0;
    }
}