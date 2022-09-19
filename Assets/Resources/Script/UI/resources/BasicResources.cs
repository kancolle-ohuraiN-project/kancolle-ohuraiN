using System.Collections;
using UnityEngine;
using Text = UnityEngine.UI.Text;

public class BasicResources : MonoBehaviour, IDataPersistence
{
    [Tooltip("��ҩUI����")]
    public Text ammunition_text;

    [Tooltip("ȼ��UI����")]
    public Text fuel_text;

    [Tooltip("��UI����")]
    public Text aluminium_text;

    [Tooltip("�ֲ�UI����")]
    public Text steel_text;

    //��������
    private int ammunition = 0;
    private int fuel = 0;
    private int aluminium = 0;
    private int steel = 0;

    //˾��ȼ�
    private int player_level = 11;

    //���ָ���
    private int MaxNaturalRecovery = 0;

    // Start is called before the first frame update
    private void Start()
    {
        ammunition_text.text = "0";
        fuel_text.text = "0";
        aluminium_text.text = "0";
        steel_text.text = "0";
        //ʹ��Э�����������洢���������Ȼ�ָ�
        StartCoroutine(NaturalRecovery());
    }

    public void LoadData(GameData data)
    {
        //��ȡ����
        this.ammunition = data.ammunition;
        this.fuel = data.fuel;
        this.aluminium = data.aluminium;
        this.steel = data.steel;
    }

    public void SaveData(GameData data)
    {
        //��������
        data.ammunition = this.ammunition;
        data.fuel = this.fuel;
        data.aluminium = this.aluminium;
        data.steel = this.steel;
    }

    // Update is called once per frame
    private void Update()
    {
        //��ӡ����
        ammunition_text.text = ammunition.ToString();
        fuel_text.text = fuel.ToString();
        aluminium_text.text = aluminium.ToString();
        steel_text.text = steel.ToString();
    }

    private IEnumerator NaturalRecovery()
    {
        while (true) // ����Ӧ��û����ͣ�����ɣ���ֹ���ݸ��²���ʱ
        {
            //���¹�ʽ��Ϊ����ٿ��л�ȡ https://zh.moegirl.org.cn/%E8%88%B0%E9%98%9FCollection/%E8%B5%84%E6%BA%90

            //ÿ3����(180��)����һ����Դ(����ʱ��15�����һ��)
            yield return new WaitForSeconds(15.0f);
            //����ʱ���Խ��ϲ���180��Ϊ������ֵ
            //��Դ�����Ȼ�ظ���=(˾��ȼ�+3)*250
            MaxNaturalRecovery = (player_level + 3) * 250;
            Debug.Log(MaxNaturalRecovery);
            //�ж��Ƿ���������Ȼ�ظ���
            if (ammunition < MaxNaturalRecovery)
            {
                //�͵���ÿ3���ӻظ�3�㣨ÿ24Сʱ�ظ�1440�㣩����ÿ3���ӻظ�1�㣨ÿ24Сʱ�ظ�480�㣩
                ammunition += 3;
                //��ֹ����
                if (ammunition > MaxNaturalRecovery)
                {
                    ammunition = MaxNaturalRecovery;
                }
            }
            if (fuel < MaxNaturalRecovery)
            {
                fuel += 3;
                if (fuel > MaxNaturalRecovery)
                {
                    fuel = MaxNaturalRecovery;
                }
            }
            if (aluminium < MaxNaturalRecovery)
            {
                aluminium += 3;
                if (aluminium > MaxNaturalRecovery)
                {
                    aluminium = MaxNaturalRecovery;
                }
            }
            if (steel < MaxNaturalRecovery)
            {
                steel += 1;
                if (steel > MaxNaturalRecovery)
                {
                    steel = MaxNaturalRecovery;
                }
            }
        }
    }
}