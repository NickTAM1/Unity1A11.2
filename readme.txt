MyUnityGunHW1 is the entire project(without the Library folder)

How to open

- Open unity hub (project)
- Add project from disk
- Select MyUnityGunHW1
- Open project

Controls

- WASD: Move
- Mouse: Look around
- Left Click: Shoot bullet
- Right Click: Shoot grenade (explodes into 12 bullets)

Scripts

- PlayerController.cs - Player movement and shooting

- BulletMovement.cs - Makes bullets fly forward

- GrenadeMovement.cs - Grenade that explodes after 1.5 seconds

- TargetCube.cs - Destroys target when hit by bullet

- TargetSpawner.cs - Spawns targets in a random area

Important

- All bullets must have "Bullet" tag
- Spawn area must be a trigger collider

Setup(If need)

1. Add PlayerController to player with Rigidbody
2. Create bullet prefab with BulletMovement + Rigidbody + Collider (tag as "Bullet")
3. Create grenade prefab with GrenadeMovement + Rigidbody
4. Create target prefab with TargetCube + Collider
5. Add TargetSpawner with Box Collider (set as trigger)

GitHub: https://github.com/NickTAM1/Unity1A11.2.git
