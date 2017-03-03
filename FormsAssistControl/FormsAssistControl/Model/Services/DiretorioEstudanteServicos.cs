using FormsAssistControl.Model.Entities;
using FormsAssistControl.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAssistControl.Model.Services
{
    public class DiretorioEstudanteServicos
    {
        public static DiretorioEstudantes CarregarDiretorioEstudante()
        {
            // instancia do Context
            DataBaseManager dbManager = new DataBaseManager();

            // obter a os estudantes 
            ObservableCollection<Estudante> estudantes = new ObservableCollection<Estudante>(dbManager.GetAllItems<Estudante>());
            DiretorioEstudantes diretorioEstudante = new DiretorioEstudantes();

            // verificar se a lista contem elementos (ALUNOS)
            if (estudantes.Any())
            {
                diretorioEstudante.Estudantes = estudantes;
                return diretorioEstudante;  // Estou interrompendo aqui o fluxo ja que ele encontrou os elementos
            }
            
            //caso nao encontre nenhum elemento estancio a lista para adionar novos elementos
            estudantes = new ObservableCollection<Estudante>();

            string[] nomes = { "José Luis", "Miguel Ángel", "José Francisco", "Jesús Antonio",
                                "Sofía", "Camila", "Valentina", "Isabella", "Ximena"};
            string[] sobrenomes = { "Hernández", "García", "Martínez", "López", "González" };

            Random rdn = new Random(DateTime.Now.Millisecond);

            estudantes = new ObservableCollection<Estudante>();

            for (int i = 0; i < 20; i++)
            {
                Estudante estudante = new Estudante();
                estudante.Name = nomes[rdn.Next(0, 8)];
                estudante.LastName = $"{sobrenomes[rdn.Next(0, 5)]} {sobrenomes[rdn.Next(0, 5)]}";
                string turma = rdn.Next(456, 458).ToString();
                estudante.Turma = turma;
                estudante.NumeroAluno = rdn.Next(12384748, 32384748).ToString();
                estudante.Media = rdn.Next(100, 1000)/ 10;
                estudante.Key = estudante.NumeroAluno;

                dbManager.SaveValue<Estudante>(estudante); // adicionando estudantes a lista
                estudantes.Add(estudante);
            }

            diretorioEstudante.Estudantes = estudantes;
            return diretorioEstudante;

        }
    }
}
