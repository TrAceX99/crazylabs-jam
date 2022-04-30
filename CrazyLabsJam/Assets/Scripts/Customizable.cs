using UnityEngine;

public class Customizable : MonoBehaviour {
    public CustomizationSet[] CustomizationSets { get; protected set; }

    public bool customizationUnlocked = false;
    
    [SerializeField] int customFeatures = 0;
    [SerializeField] Transform cameraPos;
    [SerializeField] int maxFeatures;
    [SerializeField] GameObject[] featurePrefabs;
    [SerializeField] LayerMask noSpawn;
    [SerializeField] float raycastRadius = 2f;
    [SerializeField] Collider featureSpawnCollider;

    Monster monster;
    CameraController cameraController;
    bool selected;
    int featuresLeft;

    private void Awake() {
        monster = GetComponentInParent<Monster>();
        cameraController = Camera.main.GetComponent<CameraController>();
        CustomizationSets = GetComponents<CustomizationSet>();
        selected = false;
    }

    private void Start() {
        SpawnFeatures();
    }

    public void Select() {
        cameraController.ZoomIn(cameraPos);
        monster.touchRotate.LockRotation(cameraPos.position);
        selected = true;
        if (this.customizationUnlocked)     UIManager.Instance.ShowMenu(CustomizationSets);
        else                                UIManager.Instance.ShowMenu();

    }

    public void Deselect() {
        selected = false;
        monster.touchRotate.UnlockRotation();
        cameraController.ZoomOut();
        UIManager.Instance.HideMenu();
    }

    void SpawnFeatures() {
        if (maxFeatures == 0) return;
        int featureCount = Random.Range(1, maxFeatures + 1);
        featuresLeft = featureCount + customFeatures;

        for (int i = 0; i < featureCount; i++) {
            Spawn();
        }
    }

    void Spawn() {
        RaycastHit hit;
        Vector3 rayOrigin;
        int failCount = 0;
        bool isHit;
        do {
            rayOrigin = cameraPos.TransformPoint(Random.insideUnitCircle * raycastRadius);
            isHit = featureSpawnCollider.Raycast(new Ray(rayOrigin, cameraPos.forward), out hit, 20f);
            failCount++;
            if (failCount > 1000) throw new System.Exception("Cannot find suitable feature spawn location");
        } while (!isHit || Physics.CheckSphere(hit.point, 0.1f, noSpawn));

        GameObject go = Instantiate(featurePrefabs[Random.Range(0, featurePrefabs.Length)], hit.point, Quaternion.LookRotation(hit.normal, transform.up), transform);
        Feature feature = go.GetComponent<Feature>();
        feature.segment = this;
    }

    public void FeatureDone() {
        featuresLeft--;

        if (featuresLeft == 0) {
            customizationUnlocked = true;
            monster.animationController.PlaySuccess();
            GameManager.Instance.player.inputEnabled = false;
            UIManager.Instance.ShowMenu(CustomizationSets);
            UIManager.Instance.ShowNextMonsterButton();
        }
    }
}