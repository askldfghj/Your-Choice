using UnityEngine;
using System.Collections;
using System.Xml;

public class XmlReader : MonoBehaviour {

    public static XmlReader _current;

    GameObject _gm;

    void Awake()
    {
        _current = this;
        _gm = transform.parent.gameObject;
    }

    public void FileRead()
    {
        StartCoroutine("ReadCoroutine");
    }

    IEnumerator ReadCoroutine()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Xml/" + "monsterInfo");
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        XmlNodeList nodes = xmldoc.SelectNodes("MonsterSet/Monster");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._objectDic.Add(int.Parse(nodes[i].SelectSingleNode("ID").InnerText),
                        new ObjectInfo(nodes[i].SelectSingleNode("Name").InnerText,
                                    int.Parse(nodes[i].SelectSingleNode("HP").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("STR").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("DEX").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("INT").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("WEP").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("ARM").InnerText)));
            yield return null;
        }
        _gm.SendMessage("FileLoadingEnd");
    }
}
