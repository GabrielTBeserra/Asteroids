

namespace Assets.Scripts.Interface
{
    public interface IBullet
    {
        int damage();

        void damage(int damage);

        string originalTagName();
        void originalTagName(string nome);
    }
}
