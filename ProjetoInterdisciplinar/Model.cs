using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInterdisciplinar {
    public class Model {
        private readonly string tableName = "";

        public Model(int id = 0) {
            this.tableName = this.GetType().GetField("nomeTabela") == null ? this.GetType().Name : this.GetType().GetField("nomeTabela").GetValue(this).ToString();
            if (id > 0) {
                this.Consultar(id);
            }
        }

        public bool Inserir() {
            List<PropertyInfo> propList = this.GetType().GetProperties().ToList();
            string fieldList = string.Join(", ", propList.FindAll(prop => prop.Name != "Id").Select(prop => prop.Name)), paramList = string.Join(", ", propList.FindAll(prop => prop.Name != "Id").Select(prop => $"@{prop.Name}"));
            int result = Convert.ToInt32(Banco.ExecuteScalar($"INSERT INTO {this.tableName}({fieldList}) VALUES({paramList}); SELECT LAST_INSERT_ID();",
                propList.Select(prop => new MySqlParameter(prop.Name, prop.GetValue(this))).ToList()));
            propList.Find(value => value.Name == "Id").SetValue(this, result);
            return result > 0;
        }
        public bool Consultar(int id = 0) {
            bool result = false;
            MySqlDataReader reader;
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            List<PropertyInfo> propList = this.GetType().GetProperties().ToList();
            string fieldList = string.Join(", ", propList.Select(prop => $"{prop.Name}"));
            if (id > 0) {
                parameters.Add(new MySqlParameter("@id", id));
                using (reader = Banco.ExecuteReader($"SELECT {fieldList} FROM {this.tableName} WHERE id = @id", parameters)) {
                    if (reader.HasRows) {
                        reader.Read();
                        propList.ForEach(value => value.SetValue(this, reader.GetValue(propList.IndexOf(value))));
                        result = true;
                    }
                }
            }
            return result;
        }
        public List<object> ConsultarTodos() {
            List<object> result = new List<object>();
            MySqlDataReader reader;
            List<PropertyInfo> propList = this.GetType().GetProperties().ToList();
            string fieldList = string.Join(", ", propList.Select(prop => $"{prop.Name}"));
            using (reader = Banco.ExecuteReader($"SELECT {fieldList} FROM {this.tableName}")) {
                while (reader.Read()) {
                    var temp = Activator.CreateInstance(this.GetType());
                    propList.ForEach(value => value.SetValue(temp, reader.GetValue(propList.IndexOf(value))));
                    result.Add(temp);
                }
            }
            return result;
        }
        public bool Atualizar() {
            List<PropertyInfo> propList = this.GetType().GetProperties().ToList();
            string paramList = string.Join(", ", propList.Select(prop => $"{prop.Name} = @{prop.Name}"));
            bool result = Banco.ExecuteNonQuery($"UPDATE {this.tableName} SET {paramList} WHERE id = @id",
                propList.Select(prop => new MySqlParameter(prop.Name, prop.GetValue(this))).ToList());
            return result;
        }
        public bool Excluir(int id = 0) {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            bool result = false;
            if (id > 0) {
                parameters.Add(new MySqlParameter("@id", id));
                result = Banco.ExecuteNonQuery($"DELETE FROM {this.tableName} WHERE id = @id", parameters.ToList());
            }
            return result;
        }
    }
}
