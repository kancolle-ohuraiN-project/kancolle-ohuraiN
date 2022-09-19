using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class FileDataHandler
{
    //申明文件存储位置
    private string dataDirPath = null;
    private string dataFileName = null;

    //是否进行加密(默认为开启)
    private bool useEncryption = true;

    //!加密的key（长度32位），支持任何标点符号(maybe)
    private readonly string encryptionCodeWord = "Mgs.KoAd9y^O&VKFcI2_3v<NRY07&S?%";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName + ".colle";    //设置存档文件后缀
        this.useEncryption = useEncryption;
    }

    public GameData Load()
    {
        //使用Path.Combine以说明具有不同路径分隔符的不同操作系统
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                //从文件中加载序列化数据
                string dataToLoad = null;
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //可选地解密数据
                if (useEncryption)
                {
                    dataToLoad = RijndaelDecrypt(dataToLoad, encryptionCodeWord);
                }
                //将Json中的数据反序列化回C#对象
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("尝试从文件加载数据时出错: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        //使用Path.Combine以说明具有不同路径分隔符的不同操作系统
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //创建文件将写入的目录（如果该目录不存在）
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //将C#游戏数据对象序列化为Json
            string dataToStore = JsonUtility.ToJson(data, true);

            //可选地加密数据
            if (useEncryption)
            {
                dataToStore = RijndaelEncrypt(dataToStore, encryptionCodeWord);
            }

            //将序列化数据写入文件
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("尝试将数据保存到文件时出错: " + fullPath + "\n" + e);
        }
    }

    /***********************
    / Rijndael加密算法使用
    / 加密：RijndaelEncrypt(dataToStore, encryptionCodeWord);
    / 解密：RijndaelDecrypt(dataToLoad, encryptionCodeWord);
    / 密钥,长度可以为:64位(8字节),128位(16字节),192位(24字节),256位(32字节)
    ***********************/

    private static string RijndaelEncrypt(string pString, string pKey)
    {
        //密钥
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
        //待加密明文数组
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(pString);

        //Rijndael解密算法
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateEncryptor();

        //返回加密后的密文
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    private static String RijndaelDecrypt(string pString, string pKey)
    {
        //解密密钥
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
        //待解密密文数组
        byte[] toEncryptArray = Convert.FromBase64String(pString);

        //Rijndael解密算法
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateDecryptor();

        //返回解密后的明文
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
}