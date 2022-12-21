
namespace GDSCMobileApp.IServices;

/// <summary>
/// Interface d'ajout de donnée dynamique à une base de donnée suivant la configuration de la classe qui l'a implémenté
/// </summary>
/// <typeparam name="T"> Le type de donnée qu'il faut ajouter </typeparam>
public interface IDatabaseManager<T> where T : new()
{
    /// <summary>
    /// Méthode d'ajout d'un élement dans une base de donnée.
    /// </summary>
    /// <param name="element"> La donnée a ajouté.</param>
    /// <returns> vrai si l'ajout a bien été réalisé et faux dans le cas contraire.</returns>
    Task<bool> AddElement(T element);

    /// <summary>
    /// Méthode de suppression d'une donnée.
    /// </summary>
    /// <param name="Id"> L'id de la donnée à supprimer.</param>
    /// <param name="tablename">(Optionnel suivant la définition de la méthode dans la classe) La table dans laquelle la donnée doit être supprimée.</param>
    /// <returns> vrai si la suppression a bien été réalisé et faux dans le cas contraire.</returns>
    Task<bool> Delete(string Id, string tablename = "");

    /// <summary>
    /// Méthode de récupération d'une donnée.
    /// </summary>
    /// <param name="Id">L'id de la donnée à récupérer.</param>
    /// <param name="tablename">(Optionnel suivant la définition de la méthode dans la classe) La table dans laquelle la donnée doit être récupérée.</param>
    /// <returns> L'elément si il existe ou une new de l'élement.</returns>
    Task<T> Get(string Id, string tablename = "");

    /// <summary>
    /// Méthode de récupération de l'ensemble de donnée.
    /// </summary>
    /// <returns> Une liste d'élement T.</returns>
    Task<List<T>> GetAllElements();

    /// <summary>
    /// Méthode de mise à jour d"une donnée.
    /// </summary>
    /// <param name="element">L'élement qu'il faut mettre à jour.</param>
    /// <param name="Id">L'id de l'élément a mettre à jour.</param>
    /// <returns>Vrai si la modification a bien été réalisé et faux dans le cas contraire.</returns>
    Task<bool> UpdateElement(T element, string Id);
}
