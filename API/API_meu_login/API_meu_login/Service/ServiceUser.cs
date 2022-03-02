using Newtonsoft.Json.Linq;
using API_meu_login.Dao;
using API_meu_login.Model;
using System.Data;

namespace API_meu_login.Service
{
    public class ServiceUser
    {

        DaoUser daoUser = new DaoUser();
        Usuario usuario = new Usuario();

        public DataTable GetUserByEmail(string json) {

            JObject jsonObject = JObject.Parse(json);

            usuario = jsonObject.ToObject<Usuario>();

            return daoUser.GetUserByEmail(usuario.email);

        }

    }
}
