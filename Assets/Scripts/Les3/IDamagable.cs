public interface IDamagable {
    void onDeath();

    bool TakeDamage(IDamager damager);
}