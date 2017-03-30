using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLLayer;

/// <summary>
/// Summary description for PC_RolePRovider
/// </summary>
public class PC_RoleProvider: System.Web.Security.RoleProvider
{
    public PC_RoleProvider()
    {
    }

    #region No Implementadas
    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override string ApplicationName
    {
        get
        {
            throw new Exception("The method or operation is not implemented.");
        }
        set
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public override void CreateRole(string roleName)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override string[] GetAllRoles()
    {
        throw new Exception("The method or operation is not implemented.");
    }      

    public override string[] GetUsersInRole(string roleName)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override bool RoleExists(string roleName)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    #endregion

    #region Implementadas
    public override string[] GetRolesForUser(string login)
    {
        Usuario u = new Usuario();
        u.LoadByLogin(login);
        switch (u.Id_role)
        {
            case 1:
                return new string[] { "Administrador" };
            case 2:
                return new string[] { "Usuario" };            
            default:
                return new string[] { "not_user" };
        }
    }

    public override bool IsUserInRole(string login, string role)
    {
        int r = 0;
        switch (role)
        {
            case "Administrador":
                r = 1;
                break;
            case "Usuario":
                r = 2;
                break;
            default:
                r = 0;
                break;
        }
        Usuario u = new Usuario();
        u.LoadByLogin(login);
        return u.Id_role == r;
    }
    #endregion
}
