using FormsAssistControl.Model.Entities;
using FormsAssistControl.Storage.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsAssistControl.Storage
{
    public interface IKeyObject
    {
        string Key { get; set; }
    }

    public class DataBaseManager
    {
        // instancia de acesso a dados
        SQLiteConnection dataBase;

        public DataBaseManager()
        {
            // dependicia de Acesso especifica de cada plartaforma
            dataBase = DependencyService.Get<ISQLite>().GetConnection();

            // Gerar uma tabela para estudante 
            dataBase.CreateTable<Estudante>();
        }


        // metodos CRUD , devem implemetar a interface IKeyObject e um Construtor sem Parametros

        // Guardar ou Atualizar 
        public void SaveValue<TEntity>(TEntity value) where TEntity : IKeyObject, new()
        {
            var all = (from entry in dataBase.Table<TEntity>().AsEnumerable<TEntity>()
                       where entry.Key == value.Key
                       select entry).ToList();

            if (all.Count == 0)           
                dataBase.Insert(value);
            else
                dataBase.Update(value);
        }

        // deletar

        public void DeleteValue<T>(T value) where T : IKeyObject, new()
        {

            var all = (from entry in dataBase.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 1)
                dataBase.Delete(value);
            else
                throw new Exception("O db context nao contem etrada espeficicada 'key'");
        }


        // Buscar todos
        public List<TSource> GetAllItems<TSource>() where TSource : IKeyObject, new()
        {

            return dataBase.Table<TSource>().AsEnumerable<TSource>().ToList();

        }


        // Buscar especifico
        public TSource GetItem<TSource>(string key) where TSource : IKeyObject, new()
        {

            var result = (from entry in dataBase.Table<TSource>().AsEnumerable<TSource>()
                          where entry.Key == key
                          select entry).FirstOrDefault();
            return result;

        }
    }
}
