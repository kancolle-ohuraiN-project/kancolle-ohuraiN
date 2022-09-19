using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("文件存储配置")]
    [Tooltip("前后都要输入斜杠")]
    [SerializeField] private string FolderName;

    [Tooltip("无需输入文件后缀，默认为colle文件")]
    [SerializeField] private string fileName;

    [SerializeField] private bool useEncryption = true;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Start()
    {
        //Application.persistentDataPath：将数据存入unity默认的持久化目录
        this.dataHandler = new FileDataHandler(Application.persistentDataPath + FolderName, fileName, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("在场景中找到多个DataPersistenceManager");
        }
        instance = this;
    }

    public void NewGame()
    {
        //新建存档后初始化记录是否存档
        PlayerPrefs.SetInt("IsSaved", 0);
        //给玩家初始资源
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //使用数据处理程序从文件加载任何保存的数据
        this.gameData = dataHandler.Load();
        //如果游戏存档丢失，触发新建存档
        if (this.gameData == null)
        {
            Debug.Log("未找到任何数据，将数据初始化为默认值");
            NewGame();
        }
        //将加载的数据推送到需要它的所有其他脚本
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        //将加载的数据推送到需要它的所有其他脚本
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        dataHandler.Save(gameData);
        //用于检测存档丢失
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