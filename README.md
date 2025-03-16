# 2D platformer
- Move using "A"/"D" and jump using "space"
- There are 3 levels and menu for level selection
- Player has to collect all the stars to complete level and move to another.
- Collected stars add to your score in the top right corner
- There is also reseet and exit button in the top left corner

## Approach

### Player
- Player has 2 hitboxes, first for collisions and second for ground check as trigger
- Movement is made using rigidbody2D and its velocity based on player inputs.

### Environment
- Platforms have only sprite and simple collider for player movement
- Collectible stars have trigger collider that when activated by player adds score and destroys the star
-  Since player has 2 colliders there was a bug that coused star to add score twice, this was mitigated by disabling collider and cheking if the collider is enabled when the addition of score should happen

### Managers
- Managers like "ScoreManager", "AudioManager" and "SceneChanger" use singleton approach for easier access to these scripts.
 - "ScoreManager" uses UnityEvent for updating score, which updates UI.
 - "AudioManager" loads all audioclips from /Assets/Resources/ and stores them in dictionary with their file names as keys
 - "SceneChanger" called by all buttons to either LoadScene, ReloadScene, go to next level or quit game.
  - Since "SceneManager" class already exists in "UnityEngine.SceneManagement", i had to use different name for this manager.
  - When the player collects all the stars "SceneChanger" loads next level or menu if there is none.

### Animations
- Animations are all made using unity animators keyframes for moving, rescaling and rotating sprites Transforms.

### Menu
- Menu is made as level selector with 3 simple levels.
