using UnityEngine;
using Zenject;


public class PickUpItem : MonoBehaviour
{
    [Inject] private IRegistrator dataReg;//получим данные управления в структуре
    public PickSettings PickSettings;
    [SerializeField] private GameObject objectImg;
    [SerializeField] private GameObject objectGrid;

    private Collider collaider;

    void Start()
    {
        collaider = gameObject.GetComponent<Collider>();
        collaider.isTrigger=true;

    }
    private void OnTriggerEnter(Collider other)
    {

            ExecutorCollision(other);

            collaider.enabled = false;

            Destroy(gameObject,1);

    }
    private void ExecutorCollision(Collider hit)
    {
        int tempHsh = hit.gameObject.GetHashCode();
        RegistratorConstruction tempList = dataReg.GetData(tempHsh);
        //Healt
        if (tempList.Hash==tempHsh)
        {
            Debug.Log("Yes Script");
            GameObject.Instantiate(objectImg, objectGrid.transform);

        }
        else
        {
            Debug.Log("No Script");
        }
    }
}
