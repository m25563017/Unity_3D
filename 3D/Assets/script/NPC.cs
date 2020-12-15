using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCdata data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;

    public bool playerInArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "小名")
        {
            playerInArea = true;
            Dialog();
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
    private void Dialog()
    {
        for (int i = 0; i < data.dialougA.Length; i++)
        {
            print(data.dialougA[i]);
        }
    }
}
