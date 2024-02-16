using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Controlador
{
    internal class Encriptador
    {
        public  string EncriptarTexto(string texto, string clave)
        {
            byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
            byte[] vectorInicializacion = new byte[8];
            byte[] textoEncriptado;

            using (DESCryptoServiceProvider algoritmo = new DESCryptoServiceProvider())
            {
                algoritmo.Key = claveBytes;
                algoritmo.IV = vectorInicializacion;

                using (MemoryStream memoria = new MemoryStream())
                {
                    using (CryptoStream flujoCifrado = new CryptoStream(memoria, algoritmo.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
                        flujoCifrado.Write(textoBytes, 0, textoBytes.Length);
                        flujoCifrado.FlushFinalBlock();
                        textoEncriptado = memoria.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(textoEncriptado);
        }

        public string DesencriptarTexto(string textoEncriptado, string clave)
        {
            try
            {
                byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
                byte[] vectorInicializacion = new byte[8];
                byte[] textoEncriptadoBytes = Convert.FromBase64String(textoEncriptado);

                using (DESCryptoServiceProvider algoritmo = new DESCryptoServiceProvider())
                {
                    algoritmo.Key = claveBytes;
                    algoritmo.IV = vectorInicializacion;

                    using (MemoryStream memoria = new MemoryStream(textoEncriptadoBytes))
                    {
                        using (CryptoStream flujoCifrado = new CryptoStream(memoria, algoritmo.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (StreamReader lector = new StreamReader(flujoCifrado))
                            {
                                return lector.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (CryptographicException ex)
            {
                // Manejar la excepción de datos incorrectos
                return "Error al desencriptar: " + ex.Message;
            }
        }
        public string DesencriptarArchivo1(string archivoEntrada, string clave)
        {
            byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
            byte[] vectorInicializacion = new byte[8];

            using (DESCryptoServiceProvider algoritmo = new DESCryptoServiceProvider())
            {
                algoritmo.Key = claveBytes;
                algoritmo.IV = vectorInicializacion;

                using (FileStream flujoEntrada = new FileStream(archivoEntrada, FileMode.Open))
                {
                    using (CryptoStream flujoCifrado = new CryptoStream(flujoEntrada, algoritmo.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader lector = new StreamReader(flujoCifrado))
                        {
                            return lector.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
