using System.Web.Mvc;

namespace BlogRealm.Web.Areas.AuthorRealm
{
    public class AuthorRealmAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AuthorRealm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AuthorRealm_default",
                "AuthorRealm/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}