
using Microsoft.AspNetCore.Identity;
using NorbitTask_2.UserClasses;

namespace NorbitTask_2.Routes
{
    public static class OwnerRoute
    {
        public static WebApplication AddOwners(this WebApplication application)
        {
            
            var owners = application.MapGroup("/api/owners");

            owners.MapGet(pattern: "/", handler: GetAllOwner);
            owners.MapGet(pattern: "/{id:long}", handler: GetOwnerById);
            owners.MapPost(pattern: "/", handler: CreateOwner);
            owners.MapPut(pattern: "/", handler: UpdateOwner);
            owners.MapDelete(pattern: "/{id:long}", handler: DeleteOwner);
            owners.MapDelete(pattern: "/", handler: DeleteAllOwners);

            return application;
        }
        private static IResult GetAllOwner(IOwnerInterface ownerManager)
        {
            var owners = ownerManager.GetAll();
            return Results.Ok(owners);
        }
        private static IResult GetOwnerById(long id, IOwnerInterface ownerManager)
        {
            var owner = ownerManager.GetByID(id);
            return owner is null ? Results.NotFound() : Results.Ok(owner);
        }
        private static IResult CreateOwner(Owner owner, IOwnerInterface ownerManager)
        {
            var newOwner= ownerManager.Create(owner);
            return Results.Ok(newOwner);
        }
        private static IResult UpdateOwner(Owner owner, IOwnerInterface ownerManager)
        {
            var updOwner = ownerManager.Update(owner);
            return updOwner is null ? Results.NotFound() : Results.Ok(updOwner);
        }
        private static IResult DeleteOwner(long id, IOwnerInterface ownerManager)
        {
            var delOwner = ownerManager.Delete(id);
            return delOwner is null ? Results.NotFound() : Results.Ok(delOwner);
        }
        private static IResult DeleteAllOwners(IOwnerInterface ownerManager)
        {
            var delAllOwners = ownerManager.DeleteAll();
            return Results.Ok(delAllOwners);
        }
    }
}
