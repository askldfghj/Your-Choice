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
        //이벤트 오브젝트 읽기 ******************************************************************
        //몬스터 정보
        textAsset = (TextAsset)Resources.Load("Xml/" + "monsterInfo");
        xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("MonsterSet/Monster");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._eventObjDic["Monster"].Add(new ObjectInfo(nodes[i].SelectSingleNode("Name").InnerText,
                                    int.Parse(nodes[i].SelectSingleNode("HP").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("STR").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("DEX").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("INT").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("WEP").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("ARM").InnerText)));
            yield return null;
        }

        nodes = xmldoc.SelectNodes("MonsterSet/Mimic");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._eventObjDic["Mimic"].Add(new ObjectInfo(nodes[i].SelectSingleNode("Name").InnerText,
                                    int.Parse(nodes[i].SelectSingleNode("HP").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("STR").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("DEX").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("INT").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("WEP").InnerText),
                                    int.Parse(nodes[i].SelectSingleNode("ARM").InnerText)));
            yield return null;
        }


        //스크립트 읽기 *************************************************************************
        //던전 환경
        textAsset = (TextAsset)Resources.Load("Xml/" + "DungeonScription");

        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("Scription/DungeonNarration/DungeonStart");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["DungeonStart"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }

        //몬스터 조우 관련
        textAsset = (TextAsset)Resources.Load("Xml/" + "EnCounterScription");

        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/EncounterMessage");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["EncounterMessage"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/PlayerAttack");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["PlayerAttack"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/MonsterAttack");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["MonsterAttack"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/Miss");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["Miss"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/RunSuccess");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["RunSuccess"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/RunFail");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["RunFail"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/PlayerSurprise");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["PlayerSurprise"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/MonsterSurprise");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["MonsterSurprise"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("EncounterScription/AttackEncounter/MonsterDown");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["MonsterDown"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }

        //보물상자 관련
        textAsset = (TextAsset)Resources.Load("Xml/" + "TresureScription");
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("TreasureScription/FindBox");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["FindBox"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("TreasureScription/FindTresure");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["FindTresure"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("TreasureScription/NotTresure");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["NotTresure"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("TreasureScription/Mimic");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["Mimic"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("TreasureScription/BoxSkip");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["BoxSkip"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        textAsset = (TextAsset)Resources.Load("Xml/" + "TresureScription");
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("TreasureScription/Broken");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["Broken"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }
        textAsset = (TextAsset)Resources.Load("Xml/" + "TresureScription");
        xmldoc.LoadXml(textAsset.text);
        nodes = xmldoc.SelectNodes("TreasureScription/BrokenMimic");
        for (int i = 0; i < nodes.Count; i++)
        {
            DataPool._current._ScriptionDic["BrokenMimic"].Add(nodes[i].SelectSingleNode("Text").InnerText);
            yield return null;
        }


        _gm.SendMessage("FileLoadingEnd");
    }
}
