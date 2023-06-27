namespace NorbitTask_2.UserClasses
{
    public interface IOwnerInterface
    {
        List<Owner> GetAll();

        Owner? GetByID(long id);

        Owner Create(Owner owner);

        Owner? Update(Owner owner);

        Owner? Delete(long id);

        List<Owner> DeleteAll();

    }
}
