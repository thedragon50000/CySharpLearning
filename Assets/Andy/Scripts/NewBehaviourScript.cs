// ObservableCollections必要的命名空間

using System.Collections.Specialized;
using System.Collections.ObjectModel;
//
//
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public ObservableCollection<string> items;

    void Start()
    {
        items = new ObservableCollection<string>();

        // 订阅 CollectionChanged 事件
        items.CollectionChanged += OnCollectionChanged;

        // 添加一些初始数据
        items.Add("Item 1");
        items.Add("Item 2");
        items.RemoveAt(0);
    }

    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (string newItem in e.NewItems)
                {
                    Debug.Log("Added: " + newItem);
                }

                break;
            case NotifyCollectionChangedAction.Remove:
                foreach (string oldItem in e.OldItems)
                {
                    Debug.Log("Removed: " + oldItem);
                }

                break;
            // 处理其他操作...
        }
    }
}