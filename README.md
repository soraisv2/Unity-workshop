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

Creer un script C# et mettez le sur votre Player
Votre Player est maintenant prés à etre configuré.

Votre Objet "Player" va devoir posséder certaines références comme la position de la camera, le position du sol etc... Pour cela vous pouvez creer des objets vides en tant qu'enfant de votre Player pour qu'ils puissent en hériter. (Ils vo)

### 3/ Camera
La camera doit être utilisé en dehors de l'objet "Player", elle doit le suivre indépendament. Mais également doit permettre au player de s'orienter.
> Les enfants d'un objet heritent de toutes les variables de ce dernier.


## Quelques méthodes pour commencer

La fonction `Start` s'excute une fois au lancement pour l'initialisation :

```c#
   private void Start()
   {
       // initialisation
   }
```

La fonction `Update` est appelé à chaque frame et fontionne indépendament de la physique :

```c#
   private vois Update()
   {
       // calculation
   }
```

Update les objets physiques dans `FixedUpdate()` de preference.

```c#
private void FixedUpdate() 
{
    // Physics engine
}
```

Lié un composant de votre objet à votre script :

```c#
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
```
