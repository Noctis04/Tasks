using Microsoft.EntityFrameworkCore;

namespace NorbitTask_2.UserClasses
{
    public class OwnerManager : IOwnerInterface
    {
        private readonly OwnerContext _ownerContext;
        public OwnerManager(OwnerContext ownerContext)
        {
            _ownerContext = ownerContext;
        }
        public List<Owner> GetAll()
        {
            return _ownerContext.Owners.ToList();
        }
        public Owner? GetByID(long id)
        {
            return _ownerContext.Owners.FirstOrDefault(X => X.Id == id);
        }
        public Owner Create(Owner owner)
        {
            var entry = _ownerContext.Add(owner);
            _ownerContext.SaveChanges();
            return entry.Entity;
        }
        public Owner? Update(Owner owner)
        {
            var existingOwner = _ownerContext.Owners.FirstOrDefault(x => x.Id == owner.Id);
            if (existingOwner is null) 
            { 
                return null; 
            }
            existingOwner.Login = owner.Login;
            existingOwner.Password = owner.Password;
            existingOwner.NickName = owner.NickName;

            var entry = _ownerContext.Update(owner);
            _ownerContext.SaveChanges();
            return entry.Entity;
        }
        public  Owner? Delete(long id) 
        { 
            var existingOwner = _ownerContext.Owners.FirstOrDefault(y => y.Id == id);
            if (existingOwner is null)
            {
                return null;
            }
            var entry = _ownerContext.Remove(existingOwner);
            _ownerContext.SaveChanges();
            return entry.Entity;
        }
       public List<Owner> DeleteAll()
       {
            foreach (Owner existingUser in _ownerContext.Owners)
            {
                if (existingUser is not null)
                {
                    _ownerContext.Remove(existingUser);
                }
            }
            _ownerContext.SaveChanges();
            return _ownerContext.Owners.ToList();
       }
    }
}
