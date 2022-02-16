# Unity-workshop

##### Sommaire

- Environement
- Player object
  - Physics
  - Movement script
  - Gun script
- Camera
  - Following player script
- target
  - Collision detector
- Post processing

### 1/ Environnement

Dans la "Hierarchy" de votre projet vous pouvez créer un nouvel objet en faisant un clique droit->3D Object->Cube. Ensuite jouez avec le cube pour lui donner la taille souhaitée.

### 2/ Player Object

Créer un objet vide `Create empty` dans la hierarchy, Et appelé le "Player"

### 3/ Movement

Creer un script C# et mettez le sur votre objet "Player"
Commencez par mettre les variable minimum pour le deplacement :

```c#
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    private float movementMultiplier = 1f;
    private float airMultiplier = 1f;

    [Header("Movement")]
    public float speed = 5f;
    public Transform groundPosition;
    public LayerMask groundMask;
    [SerializeField] Transform orientation;

    Vector3 direction;
    bool isGrounded;
    float horizontal;
    float vertical;
}
```

## Quelques méthodes pour commencer

Lié un composant de votre object à votre script :

```c#
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
```

Deplacez la physic `FixedUpdate()` de preference.

```c#
private void FixedUpdate() 
{
    // 
}
```
