public interface IVida 
{
    void aumentarVida(int v);

    void diminuirVida(int v);

    bool isEmpty();

    int vidaAtual();
    int vidaMaxima();
    void restart();
}
