using System;
using System.Text;

namespace MercadoEletronico.Loja.Api.Logging
{
    public static class LogBuilder
    {
        public static string Registrar(System.Exception exception)
        {
            if (exception == null)
                return string.Empty;

            StringBuilder stringLog = new StringBuilder();
            stringLog.AppendLine("Log MercadoEletronico Loja API");
            stringLog.AppendLine($"Data: {DateTime.Now.ToShortDateString()}, Horário: {DateTime.Now.ToShortTimeString()} ");
            stringLog.AppendLine("Mensagem: ");
            stringLog.AppendLine(exception.Message);
            stringLog.AppendLine("Rastreio: ");
            stringLog.AppendLine(exception.StackTrace);

            return stringLog.ToString();
        }
    }
}