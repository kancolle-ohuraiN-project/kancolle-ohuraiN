using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
public class GetErrMsg : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("������Ϣ�ı�")]
    public string ErrorText;
    void Start()
    {
        double param = SendErrMsg.Instance.param;
        string ErrorCode = param.ToString("G");
        ErrMsgJudge(ErrorCode);
    }
    private void ErrMsgJudge(string param)
    {
        
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
            default:
                ErrorText = "����Ҳ��֪��������ʲô������\n����������Ϸ���ԣ�";
                break;
        }
        //��ӡ�ַ�
        this.GetComponent<TMP_Text>().text = ErrorText;
    }
}