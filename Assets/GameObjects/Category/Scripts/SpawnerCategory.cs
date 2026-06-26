using Cysharp.Threading.Tasks;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerCategory : MonoBehaviour
{
    [SerializeField]
    private GameObject firstCategory;
    [SerializeField]
    private GameObject secondCategory;

    private ReaderJson<CategotyDataList> reader;
    private CategotyDataList categoryDataList;

   

    private void Awake()
    {
       reader = new ReaderJson<CategotyDataList>("category.json");
    }

    private async UniTaskVoid Start()
    {
        categoryDataList = await reader.ReaderJsonDataAsync();
        SeeCategories(1);
    }

    private void SeeCategories(int levelid)
    {
        var matches = categoryDataList.Categories.Where(x => x.LevelId.Contains(levelid)).ToList();

        if (matches.Count < 2)
        {
            Debug.LogError($"Нужно минимум 2 категории с LevelId= {levelid}, а найдено: {matches.Count}");
            return;
        }

        SetPropertyToCategory(firstCategory, matches[0]);
        SetPropertyToCategory(secondCategory, matches[1]);
    }

    private void SetPropertyToCategory(GameObject catObj, CategotyData match)
    {
        var catSpr = catObj.GetComponent<SpriteRenderer>();
        var fCatModel = catObj.GetComponent<Category>();
        fCatModel.SetTags(match.Tag);
        catSpr.sprite = Resources.Load<Sprite>($"Image/Categories/{match.ImageName}");
    }


}
