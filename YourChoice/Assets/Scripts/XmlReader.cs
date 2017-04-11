using UnityEngine;
using System.Collections;
using System.Xml;

public class XmlReader : MonoBehaviour {

    public static XmlReader _current;

    GameObject _gm;

    TextAsset textAsset;
    XmlDocument xmldoc;
    XmlNodeList nodes;

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
        textAsset = (TextAsset)Resources.Load("Xml/" + "monsterInfo");
        xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("MonsterSet/Monster");
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

        textAsset = (TextAsset)Resources.Load("Xml/" + "DungeonScription");

        xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("Scription/DungeonNarration/DungeonStart");
        for (int i = 0; i < nodes.Count; i++)
        {
            //DataPool._current._DungeonStartDic.Add(int.Parse(nodes[i].SelectSingleNode("ID").InnerText),
            //                                        (nodes[i].SelectSingleNode("Text").InnerText));
            DataPool._current._ScriptionDic["DungeonStart"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }

        textAsset = (TextAsset)Resources.Load("Xml/" + "EnCounterScription");

        xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/EncounterMessage");
        for (int i = 0; i < nodes.Count; i++)
        {
            //DataPool._current._DungeonStartDic.Add(int.Parse(nodes[i].SelectSingleNode("ID").InnerText),
            //                                        (nodes[i].SelectSingleNode("Text").InnerText));
            DataPool._current._ScriptionDic["EncounterMessage"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }

        xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/PlayerAttack");
        for (int i = 0; i < nodes.Count; i++)
        {
            //DataPool._current._DungeonStartDic.Add(int.Parse(nodes[i].SelectSingleNode("ID").InnerText),
            //                                        (nodes[i].SelectSingleNode("Text").InnerText));
            DataPool._current._ScriptionDic["PlayerAttack"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }

        xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/MonsterAttack");
        for (int i = 0; i < nodes.Count; i++)
        {
            //DataPool._current._DungeonStartDic.Add(int.Parse(nodes[i].SelectSingleNode("ID").InnerText),
            //                                        (nodes[i].SelectSingleNode("Text").InnerText));
            DataPool._current._ScriptionDic["MonsterAttack"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }

        xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/Miss");
        for (int i = 0; i < nodes.Count; i++)
        {
            //DataPool._current._DungeonStartDic.Add(int.Parse(nodes[i].SelectSingleNode("ID").InnerText),
            //                                        (nodes[i].SelectSingleNode("Text").InnerText));
            DataPool._current._ScriptionDic["Miss"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }

        _gm.SendMessage("FileLoadingEnd");
    }
}
