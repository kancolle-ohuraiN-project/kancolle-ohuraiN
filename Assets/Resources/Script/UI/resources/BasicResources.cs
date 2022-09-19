using System.Collections;
using UnityEngine;
using Text = UnityEngine.UI.Text;

public class BasicResources : MonoBehaviour, IDataPersistence
{
    [Tooltip("弹药UI文字")]
    public Text ammunition_text;

    [Tooltip("燃料UI文字")]
    public Text fuel_text;

    [Tooltip("铝UI文字")]
    public Text aluminium_text;

    [Tooltip("钢材UI文字")]
    public Text steel_text;

    //定义数据
    private int ammunition = 0;
    private int fuel = 0;
    private int aluminium = 0;
    private int steel = 0;

    //司令部等级
    private int player_level = 11;

    //最大恢复量
    private int MaxNaturalRecovery = 0;

    // Start is called before the first frame update
    private void Start()
    {
        ammunition_text.text = "0";
        fuel_text.text = "0";
        aluminium_text.text = "0";
        steel_text.text = "0";
        //使用协程来计算最大存储量与给予自然恢复
        StartCoroutine(NaturalRecovery());
    }

    public void LoadData(GameData data)
    {
        //获取数据
        this.ammunition = data.ammunition;
        this.fuel = data.fuel;
        this.aluminium = data.aluminium;
        this.steel = data.steel;
    }

    public void SaveData(GameData data)
    {
        //保存数据
        data.ammunition = this.ammunition;
        data.fuel = this.fuel;
        data.aluminium = this.aluminium;
        data.steel = this.steel;
    }

    // Update is called once per frame
    private void Update()
    {
        //打印数据
        ammunition_text.text = ammunition.ToString();
        fuel_text.text = fuel.ToString();
        aluminium_text.text = aluminium.ToString();
        steel_text.text = steel.ToString();
    }

    private IEnumerator NaturalRecovery()
    {
        while (true) // 暂且应该没有暂停的理由，防止数据更新不及时
        {
            //以下公式均为萌娘百科中获取 https://zh.moegirl.org.cn/%E8%88%B0%E9%98%9FCollection/%E8%B5%84%E6%BA%90

            //每3分钟(180秒)更新一次资源(测试时是15秒更新一次)
            yield return new WaitForSeconds(15.0f);
            //测试时可以将上部分180改为合适数值
            //资源最大自然回复量=(司令部等级+3)*250
            MaxNaturalRecovery = (player_level + 3) * 250;
            Debug.Log(MaxNaturalRecovery);
            //判断是否大于最大自然回复量
            if (ammunition < MaxNaturalRecovery)
            {
                //油弹钢每3分钟回复3点（每24小时回复1440点），铝每3分钟回复1点（每24小时回复480点）
                ammunition += 3;
                //防止超出
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