using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCdata data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話間隔")]
    public float interval = 0.1f;
    [Header("對話者名稱")]
    public Text textName;

    public bool playerInArea;

    public enum NPCState
    {
        FirstDialog,Mission,Finish
    }

    public NPCState state=NPCState.FirstDialog;
    /*private void Start()
    {
        StartCoroutine(Test());
    }

    private IEnumerator Test()
    {
        print("泥好~~");
        yield return new WaitForSeconds(1.5f);
        print("我是1.5秒後的啦哈哈哈哈");

    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "小名")
        {
            playerInArea = true;
         StartCoroutine(Dialog());
        }
    }
    private void OnTriggerExit(Collider other)
    {  if(other.name=="小名")
        playerInArea=false;
      }
    //private void Dialog()
    //{
    //    for (int i = 0; i < 65; i++)
    //    {
    //        print("我是迴圈：" + i);
    //    }
    //}

    private void StopDialog()
    {
        dialog.SetActive(false);
        StopAllCoroutines();
    }

   
    
    private IEnumerator Dialog()
    {
        dialog.SetActive(true);
        textContent.text = "";
        textName.text = name;
        string dialogString = data.dialogB;

        switch (state)
        {
            case NPCState.FirstDialog:
                dialogString = data.dialogA;
                break;
            case NPCState.Mission:
                dialogString = data.dialogB;
                break;
            case NPCState.Finish:
                dialogString = data.dialogC;
                break;
           
        }

        for (int i = 0; i < dialogString.Length; i++)
        {
            textContent.text+=dialogString[i]+"";
            yield return new WaitForSeconds(interval);
        }
    }
}
