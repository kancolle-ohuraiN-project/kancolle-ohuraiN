using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("�ļ��洢����")]
    [Tooltip("ǰ��Ҫ����б��")]
    [SerializeField] private string FolderName;

    [Tooltip("���������ļ���׺��Ĭ��Ϊcolle�ļ�")]
    [SerializeField] private string fileName;

    [SerializeField] private bool useEncryption = true;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Start()
    {
        //Application.persistentDataPath�������ݴ���unityĬ�ϵĳ־û�Ŀ¼
        this.dataHandler = new FileDataHandler(Application.persistentDataPath + FolderName, fileName, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("�ڳ������ҵ����DataPersistenceManager");
        }
        instance = this;
    }

    public void NewGame()
    {
        //�½��浵���ʼ����¼�Ƿ�浵
        PlayerPrefs.SetInt("IsSaved", 0);
        //����ҳ�ʼ��Դ
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //ʹ�����ݴ��������ļ������κα��������
        this.gameData = dataHandler.Load();
        //�����Ϸ�浵��ʧ�������½��浵
        if (this.gameData == null)
        {
            Debug.Log("δ�ҵ��κ����ݣ������ݳ�ʼ��ΪĬ��ֵ");
            NewGame();
        }
        //�����ص��������͵���Ҫ�������������ű�
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        //�����ص��������͵���Ҫ�������������ű�
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        dataHandler.Save(gameData);
        //���ڼ��浵��ʧ
        PlayerPrefs.SetInt("IsSaved", 1);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    public bool hasGameData()
    {
        return gameData != null;
    }
}