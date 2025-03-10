﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class UsandoExpandObject : IAulaItem
    {
        public void Executar()
        {
            //mensagem em json
            string json = "{\"De\": \"Paulo Silveira\"," +
                "\"Para\": \"Guilherme Silveira\"}";
            
            //convertendo
            //para criar uma propriedade dinamicamente, o variável deve ser dynamic
            dynamic mensagem = JsonConvert.DeserializeObject<ExpandoObject>(json);

            //criando uma propriedade - .texto - dinamica para uma variável - mensagem -
            mensagem.Texto = "Olá, " + mensagem.Para;

            EnviarMensagem(mensagem);

            mensagem.Inverter = new Action(() =>
            {
                var aux = mensagem.De;
                mensagem.De = mensagem.Para;
                mensagem.Para = aux;
                mensagem.Texto = "Olá, " + mensagem.Para;
            });

            mensagem.Inverter();
            EnviarMensagem(mensagem);
        }

        private void EnviarMensagem(dynamic msg)
        {
            Console.WriteLine($"De: {msg.De}");
            Console.WriteLine($"Para: {msg.Para}");
            Console.WriteLine($"Texto: {msg.Texto}");
            Console.WriteLine();
       
    }
}
}
