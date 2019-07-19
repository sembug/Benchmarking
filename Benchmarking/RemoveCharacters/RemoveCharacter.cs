using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarking
{
    public class RemoveCharacter
    {
        public string RemoverCaracteresSimples(string valor, params string[] caract)
        {
            if (String.IsNullOrWhiteSpace(valor))
            {
                return String.Empty;
            }

            foreach (var s in caract)
            {
                valor = valor.Replace(s, "");
            }

            return valor;
        }

        public string RemoverCaracteresStringBuilder(string valor, params string[] caract)
        {
            if (String.IsNullOrWhiteSpace(valor))
            {
                return String.Empty;
            }

            var sb = new StringBuilder(valor);
            foreach (var s in caract)
            {
                sb.Replace(s, "");
            }

            return sb.ToString();
        }

        public string RemoverCaracteresStringBuilderChars(string valor, params char[] caract)
        {
            if (String.IsNullOrWhiteSpace(valor))
            {
                return String.Empty;
            }

            var sb = new StringBuilder(valor.Length);
            for (var i = 0; i < valor.Length; i++)
            {
                bool adicionar = true;
                for (var j = 0; j < caract.Length; j++)
                {
                    if (caract[j] == valor[i])
                    {
                        adicionar = false;
                        break;
                    }
                }
                if (adicionar)
                {
                    sb.Append(valor[i]);
                }
            }

            return sb.ToString();
        }

        public string RemoverCaracteresWithSpan(string valor, params char[] caract)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return string.Empty;

            var resultado = new Span<char>(new char[valor.Length]);

            var index = 0;

            foreach (var c in valor)
            {
                var add = true;
                foreach (var o in caract)
                {
                    if (o == c)
                    {
                        add = false;
                        break;
                    }

                }

                if (add)
                    resultado[index++] = c;
            }

            return resultado.Slice(0, index).ToString();
        }
    }
}
