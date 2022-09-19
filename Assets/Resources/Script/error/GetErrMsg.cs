using TMPro;
using UnityEngine;

public class GetErrMsg : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("������Ϣ�ı�")]
    [Tooltip("���Ǳ�Ҫ")]
    public string ErrorText;
    [Header("��ʾ�İ�ť")]
    [Tooltip("���Ǳ�Ҫ")]
    public GameObject Button;

    private bool ShowNewSavebutton = false;

    private void Start()
    {
        //��ȡ����
        //string ErrorCode = SendErrMsg.Instance.param;
        //��װ����
        string ErrorCode = "3.1";
        ErrMsgJudge(ErrorCode);
    }

    private void ErrMsgJudge(string param)
    {
        //���û�д��κβ�������������Ϣ
        if (param == null)
        {
            param = "����Ҳ��֪��������ʲô������\n����������Ϸ���ԣ�";
        }
        //�ж��Ƿ�Ϊ�����룬�粻�Ǿ�ֱ�������������
        switch (param)
        {
            case "1.1":
                ErrorText = "������ƺ���������\n����ϵ�����߻��߸�������";
                break;

            case "1.2":
                ErrorText = "�ͻ��˴�������״̬\nΪ�˱�֤�����������������";
                break;

            case "1.3":
                ErrorText = "�ӷ������з��ص���Ϣ�ƺ��Ǳ���\n�������ͻ��˲���֤��������";
                break;

            case "2.1":
                ErrorText = "�޷���ȡ�ͻ��˰汾\n�����Ƿ�ӹٷ���������)";
                break;

            case "2.2":
                ErrorText = "�ͻ��˰汾����Ϊ����˰汾\n����¿ͻ���";
                break;

            case "3.1":
                ErrorText = "�ͻ��˴浵��ʧ��\n�뽫�浵�ƶ���Ĭ��λ��\n���ߵ���·���ť���´����浵";
                ShowNewSavebutton = true;
                break;

            case "3.2":
                ErrorText = "�ͻ��˴浵�𻵣�\n�뽫���ݴ浵�ƶ���Ĭ��λ��\n���ߵ���·���ť���´����浵";
                ShowNewSavebutton = true;
                break;

            case "99.99":
                ErrorText = "��ϲ�������ʵ��ˣ�\n�������ͻ��˰ɣ�\n(δ������ȿ��ܻᶪʧŶqwq)";
                break;

            default:
                ErrorText = param;
                break;
        }
        //��ӡ�ַ�
        this.GetComponent<TMP_Text>().text = ErrorText;
        //�Ƿ���ʾ��ť
        if(ShowNewSavebutton == true)
        {
            Button.SetActive(true);
        }
    }
}