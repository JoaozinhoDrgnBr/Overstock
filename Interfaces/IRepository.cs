namespace Overstock.Interfaces;

public interface IRepository<T>
{
    void Inserir(T entidade);
    void Atualizar(T entidade); 
    void Excluir(T entidade);
    T ObterPorId(int id);
    List<T> ObterTodos();
}