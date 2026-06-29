using Cysharp.Threading.Tasks;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerCategory : MonoBehaviour, IRestartable
{
    [SerializeField]
    private GameObject firstCategory;
    [SerializeField]
    private GameObject secondCategory;
    [SerializeField]
    private Camera cam;

    private ReaderJson<CategotyDataList> reader;
    private CategotyDataList categoryDataList;
    private float leftEdge;
    private float rightEdge;
    public float padding = 0.5f;

    private void Awake()
    {
       reader = new ReaderJson<CategotyDataList>("category.json");
    }

    private async UniTaskVoid Start()
    {
        CameraBoundaries();
        categoryDataList = await reader.ReaderJsonDataAsync();
        SeeCategories(UserProfile.GetNumberCurrentLevel());
    }

    private void SeeCategories(int levelid)
    {
        var matches = categoryDataList.Categories.Where(x => x.LevelId.Contains(levelid)).ToList();

        if (matches.Count < 2)
        {
            Debug.LogError($"Нужно минимум 2 категории с LevelId= {levelid}, а найдено: {matches.Count}");
            return;
        }

        SetPropertyToCategory(firstCategory, matches[0], true);
        SetPropertyToCategory(secondCategory, matches[1], false);
    }

    private void SetPropertyToCategory(GameObject catObj, CategotyData match,bool isLeft)
    {
        var catSpr = catObj.GetComponent<SpriteRenderer>();
        var fCatModel = catObj.GetComponent<Category>();
        fCatModel.SetTags(match.Tag);

        float halfWidth = catSpr.bounds.extents.x;

        if (isLeft)
        {
            catObj.transform.position = new Vector3(leftEdge + halfWidth + padding,
                catObj.transform.position.y, catObj.transform.position.z);
        }
        else 
        {
            catObj.transform.position = new Vector3(rightEdge - halfWidth - padding,
                 catObj.transform.position.y, catObj.transform.position.z);
        }


        catSpr.sprite = Resources.Load<Sprite>($"Image/Categories/{match.ImageName}");
    }


     private void CameraBoundaries()
    {
        float camHeight = cam.orthographicSize * 2f;
        float camWidth = camHeight * cam.aspect;

         leftEdge = cam.transform.position.x - camWidth / 2f;
         rightEdge = cam.transform.position.x + camWidth / 2f;
    }

    public void RestartLevel()
    {
        Debug.Log("RestartLevel SpawnerCategory");
        SeeCategories(UserProfile.GetNumberCurrentLevel());
    }
}
