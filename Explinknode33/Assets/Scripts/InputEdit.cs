using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputEdit : MonoBehaviour {
                                                //控件变量
    public InputField IDInputField;
    public InputField NameInputField;
    public InputField AddressInputField;

    public string StrID;
    public string StrName;
    public string StrAddress;

    public bool flagID;                         //ID的输入是否合法
    public bool flagAddress;                    //Address输入是否合法

    void Start()
    {
        StrID = "";
        StrName = "";
        StrAddress = "";
        flagID = false;
    }
	
    public void GetIDInput()
    {
        
        StrID = IDInputField.text.ToString();
        if(StrID.Length!=6)
        {
            IDInputField.text = "";
            flagID = false;
        }
        else
        {
            flagID = true;
        }
    }

    public void GetNameInput()
    {
        StrName = NameInputField.text.ToString();
    }

    public void GetAddressInput()
    {
        StrAddress = AddressInputField.text.ToString().ToLower();       //转换为小写
        if (StrAddress.Length != 10)
        {
            AddressInputField.text = "";
            flagAddress = false;
        }
        else
        {
            flagAddress = true;
        }
    }


}
