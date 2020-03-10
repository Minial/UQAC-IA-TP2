namespace UQAC_IA_TP2.core
{
    /// <summary>
    /// Nous avons considéré les CSP à contraintes binaires (relation entre deux variables). Une telle contraintes est
    /// représenté par la classe BinaryConstraint qui possède les deux variables impliquées dans la contraintes.
    /// BinaryConstraint est une classe abstraite et ne défini pas concrètement la contrainte entre les deux variables.
    ///
    /// La méthode à implémenter dans les implémentation est SatisfyConstraint(T value) -> bool qui permet de vérifier
    /// si l’assignement d’une valeur à la première variable de la contrainte est autorisée.
    /// </summary>
    public abstract class BinaryConstraint<T>
    {
        public readonly Variable<T> Var1, Var2;

        public BinaryConstraint(Variable<T> var1, Variable<T> var2)
        {
            Var1 = var1;
            Var2 = var2;
        }

        public abstract bool SatisfyConstraint(T valueI);

        public abstract bool WillReduceDomainOfTheSecondVariable(T valueI);
    }
}