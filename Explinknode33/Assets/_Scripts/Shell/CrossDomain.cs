using UnityEngine;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class CrossDomain : MonoBehaviour
{
    #region Variables
    #region Public
    public string pathname = "Xmls/crossDomainReg";
    #endregion Public

    #region Private
    XmlDocument XMLdoc;
    List<string> allDomainName;
    string expid;
    #endregion Private
    #endregion Variables

    #region Methods
    #region Public
    public bool ParseCrossDomain(string url)
    {
        if (XMLdoc == null)
        {
            XMLdoc = ReadAndLoadXml();
        }
        allDomainName = GetAllDomain();

        return checkURL(url);
    }

    public string getExperimentID()
    {
        if (XMLdoc == null)
        {
            XMLdoc = ReadAndLoadXml();
        }
        List<string> allExpID = parseExpID();
        expid = allExpID[0];
        
        return expid;
    }
    #endregion Public

    #region Private
    // Use this for initialization
    void Start ()
    {
        XMLdoc = null;
        expid = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    XmlDocument ReadAndLoadXml()
    {
        XmlDocument doc = new XmlDocument();
        TextAsset ta = Resources.Load<TextAsset>(pathname);
        doc.LoadXml(ta.text);

        return doc;
    }

    List<string> GetAllDomain()
    {
        List<string> allDomainName = new List<string>();

        //所有province节点  
        XmlNode xmlnodes = XMLdoc.SelectSingleNode("cross-domain-policy");

        foreach (XmlNode xmlnode in xmlnodes)
        {
            XmlElement xmlelement = (XmlElement)xmlnode;

            //所有provinceName添加到列表
            string temp = xmlelement.GetAttribute("domain");
            if (temp != "")
            {
                allDomainName.Add(temp);
            }  
        }

        return allDomainName;
    }

    List<string> parseExpID()
    {
        List<string> allExpID = new List<string>();

        //所有province节点  
        XmlNode xmlnodes = XMLdoc.SelectSingleNode("cross-domain-policy");

        foreach (XmlNode xmlnode in xmlnodes)
        {
            XmlElement xmlelement = (XmlElement)xmlnode;

            //所有provinceName添加到列表  
            string temp = xmlelement.GetAttribute("expid");
            if (temp != "")
            {
                allExpID.Add(temp);
            }
        }

        return allExpID;
    }

    bool checkURL(string url)
    {
        int numURL = allDomainName.Count;

        for (int i = 0; i < numURL; i++)
        {
            Regex rgx = new Regex(allDomainName[i]);
            if (rgx.IsMatch(url))
            {
                return true;
            }
        }
        return false;
    }
    #endregion Private
    #endregion Methods
}
